/****************************************************************************************
 * 文件名：PhoneValidator
 * 作者：黄泽林
 * 创始时间：2017/5/18 9:43:58
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace EntlibValidate.Domain
{
    /// <summary>
    /// 自定义手机号验证器
    /// </summary>
    public class PhoneValidator : Validator<String>
    {
        public PhoneValidator(string tag)
            : base("", tag)
        {

        }

        protected override string DefaultMessageTemplate
        {
            get
            {
                return string.IsNullOrEmpty(MessageTemplate) ? MessageTemplate : "手机号设置不正确";
            }
        }

        protected override void DoValidate(string objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            Regex regex = new Regex("^1\\d{10}$");

            if (string.IsNullOrEmpty(objectToValidate))
            {
                LogValidationResult(
                        validationResults,
                        "手机号不能为空",
                        currentTarget,
                        key);
                return;
            }

            var match = regex.Match(objectToValidate);
            if (!match.Success)
            {
                 LogValidationResult(
                        validationResults,
                        "手机号格式错误",
                        currentTarget,
                        key);
            }
        }
    }
}
