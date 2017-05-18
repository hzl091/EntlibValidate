/****************************************************************************************
 * 文件名：OrderLine
 * 作者：黄泽林
 * 创始时间：2017/5/17 9:38:18
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace EntlibValidate.Domain
{
    public class OrderLine
    {
        /// <summary>
        /// sku编码
        /// </summary>
        public int Sku { get; set; }

        /// <summary>
        /// sku名称
        /// </summary>
        [NotNullValidator(MessageTemplate = "sku名称名字不能为空")]
        [RegexValidator("^yg.*$", RegexOptions.Singleline, MessageTemplate = "sku名称名字必须以yg开头")]
        public string SkuName { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        [RangeValidator(1, RangeBoundaryType.Inclusive, 10, RangeBoundaryType.Inclusive, MessageTemplate = "sku购买数量只能介于1-10之间")]
        public int Qty { get; set; }

        /// <summary>
        /// 实际购买价
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 实际购买总价
        /// </summary>
        public decimal LineTotal { get; set; }

        /// <summary>
        /// 总折扣
        /// </summary>
        public decimal DiscountTotal { get; set; }

        /// <summary>
        /// 总重量
        /// </summary>
        public float WeightTotal { get; set; }
    }
}
