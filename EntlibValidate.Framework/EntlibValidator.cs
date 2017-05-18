/****************************************************************************************
 * 文件名：EntlibValidator
 * 作者：黄泽林
 * 创始时间：2017/5/18 15:56:46
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace EntlibValidate.Framework
{
    public class EntlibValidator<T> : IValidator
    {
        public ValidateResults DoValidate(object target, bool throwIf = true)
        {
            Validator<T> orderValidator
              = ValidationFactory.CreateValidator<T>();
            var rs = orderValidator.Validate(target);

            ValidateResults newRs = new ValidateResults();
            newRs.AddRange(rs.Select(item => new ValidateResult {Key = item.Key, ErrorMessage = item.Message}));
            return newRs;
        }
    }
}
