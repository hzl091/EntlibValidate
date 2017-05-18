/****************************************************************************************
 * 文件名：ValidateResult
 * 作者：黄泽林
 * 创始时间：2017/5/18 15:47:04
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntlibValidate.Framework
{
    /// <summary>
    /// 验证结果
    /// </summary>
    public class ValidateResult
    {
        /// <summary>
        /// key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
