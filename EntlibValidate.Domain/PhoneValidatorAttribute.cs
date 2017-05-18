/****************************************************************************************
 * 文件名：PhoneValidatorAttribute
 * 作者：黄泽林
 * 创始时间：2017/5/18 10:02:27
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace EntlibValidate.Domain
{
    /// <summary>
    /// 自定义手机号验证器特性
    /// </summary>
    public class PhoneValidatorAttribute : ValidatorAttribute
    {
        protected override Validator DoCreateValidator(Type targetType)
        {
            return new PhoneValidator(Tag);
        }
    }
}
