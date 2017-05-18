/****************************************************************************************
 * 文件名：Order
 * 作者：黄泽林
 * 创始时间：2017/5/18 10:15:13
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace EntlibValidate.Domain
{
    public partial class Order
    {
        protected override void AddCustomerValidate(ValidationResults validationResults)
        {
            if (string.IsNullOrEmpty(ShippingAddress.Province))
            {
                validationResults.AddResult(new ValidationResult( "地址中的省份未设置",null,"Province","",null));
            }
            else
            {
                if (ShippingAddress.Province != "广东")
                {
                    validationResults.AddResult(new ValidationResult("暂时只支持广东省内发货", null, "Province", "", null));
                }
            }
        }
    }
}
