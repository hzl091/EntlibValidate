/****************************************************************************************
 * 文件名：Person
 * 作者：黄泽林
 * 创始时间：2017/5/18 14:03:27
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EntlibValidate.Domain.Test
{
    [MetadataType(typeof(Address))]
    public class Person
    {
        public Person()
        {
            Address = new Address();
        }

        [Required(ErrorMessage = "名字不能为空")]
        public string Name { get; set; }

        [Range(1,100,ErrorMessage = "年龄设置不正确")]
        public int Age { get; set; }

        [ValidateObject]
        public Address Address { get; set; }
    }
}
