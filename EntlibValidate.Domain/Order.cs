/****************************************************************************************
 * 文件名：Order
 * 作者：黄泽林
 * 创始时间：2017/5/17 9:38:08
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace EntlibValidate.Domain
{

    //entlibValidation参考：http://www.cnblogs.com/kyo-yo/archive/2010/07/19/Learning-EntLib-Fifth-Introduction-Validation-module-information-Part1.html
    //验证器使用：http://www.cnblogs.com/kyo-yo/archive/2010/07/21/Learning-EntLib-Fifth-Introduction-Validation-module-information-Part2.html
    //规则集合使用：http://www.cnblogs.com/shenfx318/archive/2007/01/07/613719.html
    //自定义验证器：http://www.cnblogs.com/kyo-yo/archive/2010/08/02/Learning-EntLib-Fifth-Introduction-Validation-module-information-Part3.html

    /// <summary>
    /// 订单
    /// </summary>
    public partial class Order : EntityBase<Order>
    {
        public Order()
        {
            Lines = new List<OrderLine>();
        }

        /// <summary>
        /// 订单号
        /// </summary>
        [NotNullValidator(MessageTemplate = "订单号不能为空")]  //非空【null】验证
        [StringLengthValidator(13,18, MessageTemplate = "订单号格式不正确")] //订单号限制长度13-18位
        [ContainsCharactersValidator("YG", ContainsCharacters.All, MessageTemplate = "订单号中必须包含YG字符")] //是否包含特定文本验证.注意：这里非全字匹配（比较坑）
        public string OrderNumebr { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        [TypeConversionValidator(typeof(int), MessageTemplate = "用户类型必须是数字")] //类型验证
        [DomainValidator("0","1", MessageTemplate = "用户类型只能选择0或1")]  //验证输入的值是否在指定域中存在
        public string UserType { get; set; }  //0=普通用户，1=VIP

        /// <summary>
        /// 订单明细
        /// </summary>
        [NotNullValidator(MessageTemplate = "订单明细不能为空")]  //非空【null】验证
        [ObjectCollectionValidator(typeof(OrderLine))] //集合对象验证：对象集合验证程序可用于检查集合中的每个对象是否属于指定的类型，以及对集合中的每个成员执行验证。  https://msdn.microsoft.com/zh-cn/library/hh315829(v=pandp.50).aspx
        public List<OrderLine> Lines{ get;set; }

        /// <summary>
        /// 运费
        /// </summary>
        [Range(1,100,ErrorMessage = "运费要大于0")]  //范围验证
        public decimal ShippingFee { get; set; }
       
        /// <summary>
        /// 订单折扣
        /// </summary>
        public decimal DiscountTotal{ get;set; }
        
        /// <summary>
        /// 订单总价值
        /// </summary>
        public Decimal Total { get;set; }

        /// <summary>
        /// 收货地址信息
        /// </summary>
        [NotNullValidator(MessageTemplate = "地址不能为空")]
        [ObjectValidator]  //单个对象验证
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// 付款类型
        /// </summary>
        [EnumConversionValidator(typeof(PayMethod), MessageTemplate = "付款类型设置不正确")]  //检测输入的付款类型文本是否制定枚举中的一项
        public string PayMethod { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }

        [IgnoreNulls]  //忽略为空，信息为空时不验证
        [StringLengthValidator(10,100,MessageTemplate = "备注长度要介于10-100字符之间")]  //字符长度验证器
        public string Note { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [PropertyComparisonValidator("ConfirmPwd", ComparisonOperator.Equal, MessageTemplate = "密码不一致")] //属性比较验证器
        public string Pwd { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        [RegexValidator("^\\d{2,10}[a-zA-Z]{2,10}$", RegexOptions.Singleline, MessageTemplate = "密码必须2-10个数字开头，2-10个字母结尾")]  //正则表达式验证器
        public string ConfirmPwd { get; set; }
    }
}
