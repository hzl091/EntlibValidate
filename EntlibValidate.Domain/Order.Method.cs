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
using EntlibValidate.Framework;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace EntlibValidate.Domain
{
    public partial class Order
    {
        protected override void AddCustomerValidate(ValidateResults validateResults)
        {
            if (string.IsNullOrEmpty(ShippingAddress.Province))
            {
                validateResults.AddResult("Province","地址中的省份未设置");
            }
            else
            {
                if (ShippingAddress.Province != "广东")
                {
                    validateResults.AddResult("Province", "暂时只支持广东省内发货");
                }
            }
        }
    }
}
