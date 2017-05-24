/****************************************************************************************
 * 文件名：ObjectCollectionLength
 * 作者：黄泽林
 * 创始时间：2017/5/24 10:36:20
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EntlibValidate.Domain
{
    public class ObjectCollectionLengthAttribute : ValidationAttribute
    {
        /// <summary>
        /// 最小长度
        /// </summary>
        public int MinLength { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        public int MaxLength { get; set; }

        public ObjectCollectionLengthAttribute(int minLength)
        {
            if (minLength < 0)
            {
                throw new ArgumentException("minLength不能为负数");
            }
            MinLength = minLength;
        }

        public ObjectCollectionLengthAttribute(int minLength,int maxLength)
        {
            if (minLength < 0)
            {
                throw new ArgumentException("minLength不能为负数");
            }

            if (maxLength < 0)
            {
                throw new ArgumentException("maxLength不能为负数");
            }

            if (maxLength < minLength)
            {
                throw new ArgumentException("maxLength必须大于或等于minLength");
            }

            MinLength = minLength;
            MaxLength = maxLength;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;
            Type[] interfaces = value.GetType().GetInterfaces();
            var count = (from p in interfaces
                         where p == typeof(ICollection)
                select p).Count();
            if (count == 0)
            {
                throw new InvalidOperationException("ObjectCollectionLength验证标签只适用于集合类型");
            }

            var target = value as ICollection;
            if (MaxLength == 0)
            {
                return target.Count >= MinLength;
            }
            return target.Count >= MinLength && target.Count <= MaxLength;
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = name + " 集合中元素的个数不符合规则。"; 
            }

            return base.FormatErrorMessage(name);
        }
    }
}
