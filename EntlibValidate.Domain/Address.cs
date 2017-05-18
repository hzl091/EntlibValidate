using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace EntlibValidate.Domain
{
    /// <summary>
    /// 地址
    /// </summary>
    public class Address
    {
        /// <summary>
        /// 收货人名字
        /// </summary>
        [NotNullValidator(MessageTemplate = "收货人名字不能为空")]
        public string FullName { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street1 { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Street2 { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        //[PhoneValidator]  //自定义验证器
        [PhoneValidator(MessageTemplate = "错误的手机号，请检查")]
        public string Mobile { get; set; }

        /// <summary>
        /// 展示使用，不存储
        /// </summary>
        public string FullAddress
        {
            get
            {
                return string.Format("{0} {1} {2} {3} {4}",this.Province,this.City,this.County,this.Street1,this.Street2);
            }
        }

        public override bool Equals(object anthorAddress)
        {
            Address second = anthorAddress as Address;
            if (second == null)
            {
                return false;
            }
            if ((this.FullName != second.FullName) ||
                (this.Province != second.Province) ||
                (this.City != second.City) ||
                (this.Street1 != second.Street1) ||
                (this.Street2 != second.Street2) ||
                (this.Tel != second.Tel) ||
                (this.Mobile != second.Mobile))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ///// <summary>
        ///// 地址格式有效性验证
        ///// </summary>
        //public void Validation()
        //{
        //    //地址中的街道可为空
        //    if ((string.IsNullOrEmpty(this.Province)) ||
        //        string.IsNullOrEmpty(this.City) ||
        //        string.IsNullOrEmpty(this.Street2) ||
        //        (string.IsNullOrEmpty(this.Tel) && string.IsNullOrEmpty(this.Mobile)))
        //    {
        //        throw new Exception("地址信息不完整"); 
        //    }
        //}
    }
}
