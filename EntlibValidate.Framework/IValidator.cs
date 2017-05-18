using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntlibValidate.Framework
{
    /// <summary>
    /// 验证接口
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// 执行验证
        /// </summary>
        /// <param name="target">要验证的对象</param>
        /// <param name="throwIf">验证失败抛异常</param>
        /// <returns>验证结果</returns>
        ValidateResults DoValidate(object target, bool throwIf = true);
    }
}
