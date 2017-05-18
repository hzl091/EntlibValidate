/****************************************************************************************
 * 文件名：Person_Test
 * 作者：黄泽林
 * 创始时间：2017/5/18 14:06:05
 * 创建说明：
****************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntlibValidate.Domain.Test
{
    [TestClass]
    public class Person_Test
    {
        [TestMethod]
        public void Person_Validate_Test()
        {
            var person = new Person();
            person.Address.FullName = "sdfsdfgsdfgdsfgsdfgsdfgsdfgsdf";
            var validationContext = new ValidationContext(person,null,null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(person, validationContext, results, true);
           
            if (!isValid)
            {
                foreach (var rs in results)
                {
                    Console.WriteLine(rs.ErrorMessage);
                }
            }
        }

        [TestMethod]
        public void Person_Validate_Test1()
        {
            var person = new Person();
            person.Address.FullName = "sdfsdfgsdfgdsfgsdfgsdfgsdfgsdf";

            var results = this.DoValidate(person);
            results.AddRange(this.DoValidate(person.Address));

            foreach (var rs in results)
            {
                Console.WriteLine(rs.ErrorMessage);
            }
        }

        public List<ValidationResult> DoValidate(object obj)
        {
            var validationContext = new ValidationContext(obj, null, null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, validationContext, results, true);
            return results;
        }
    }
}
