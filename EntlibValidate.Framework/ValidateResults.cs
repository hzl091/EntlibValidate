/****************************************************************************************
 * 文件名：ValidateResultCollection
 * 作者：黄泽林
 * 创始时间：2017/5/18 15:49:42
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntlibValidate.Framework
{
    public class ValidateResults :  List<ValidateResult>
    {
        /// <summary>
        /// 验证是否通过
        /// </summary>
        public bool IsValid
        {
            get
            {
                return Count == 0;
            }
        }

        public void AddResult(string key, string errorMessage)
        {
            this.Add(new ValidateResult() { Key = key, ErrorMessage = errorMessage });
        }
    }
}
