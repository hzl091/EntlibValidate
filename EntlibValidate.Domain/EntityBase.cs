using System;
using System.Linq;
using EntlibValidate.Framework;

namespace EntlibValidate.Domain
{
    public abstract class EntityBase<TEntity>
    {
        /// <summary>
        /// 验证并设置是否抛出异常
        /// </summary>
        /// <param name="throwIf">验证不通过是否选择抛异常</param>
        /// <returns></returns>
        public ValidateResults DoValidate(bool throwIf = true)
        {
            IValidator validator = new EntlibValidator<TEntity>();
            var rs = validator.DoValidate(this,false);
            this.AddCustomerValidate(rs); //钩子,自定义验证时重写该方法

            if (throwIf)
            {
                if (!rs.IsValid)
                {
                    throw new Exception(rs.First().ErrorMessage);
                }
            }

            return rs;


            //Validator<TEntity> orderValidator
            //   = ValidationFactory.CreateValidator<TEntity>();
            //var rs = orderValidator.Validate(this);
            //this.AddCustomerValidate(rs); //钩子,自定义验证时重写该方法

            //if (throwIf)
            //{
            //    if (!rs.IsValid)
            //    {
            //        throw new Exception(rs.First().Message);
            //    }
            //}

            //return rs;
        }

        /// <summary>
        /// 验证状态
        /// </summary>
        public bool IsValid
        {
            get { return DoValidate(false).Count == 0; }
        }


        /// <summary>
        /// 自定义验证
        /// </summary>
        /// <param name="validateResults"></param>
        protected virtual void AddCustomerValidate(ValidateResults validateResults)
        {
            
        }
    }
}
