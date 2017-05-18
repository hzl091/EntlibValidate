using System;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace EntlibValidate.Domain
{
    public abstract class EntityBase<TEntity>
    {
        /// <summary>
        /// 验证并设置是否抛出异常
        /// </summary>
        /// <param name="throwIt"></param>
        /// <returns></returns>
        public ValidationResults ValidateThrowIf(bool throwIt = true)
        {
            Validator<TEntity> orderValidator
               = ValidationFactory.CreateValidator<TEntity>();
            var rs = orderValidator.Validate(this);
            this.AddCustomerValidate(rs); //钩子,自定义验证时重写该方法

            if (throwIt)
            {
                if (!rs.IsValid)
                {
                    throw new Exception(rs.First().Message);
                }
            }

            return rs;
        }

        /// <summary>
        /// 验证状态
        /// </summary>
        public bool IsValid
        {
            get { return ValidateThrowIf(false).Count == 0; }
        }


        /// <summary>
        /// 自定义验证
        /// </summary>
        /// <param name="validationResults"></param>
        protected virtual void AddCustomerValidate(ValidationResults validationResults)
        {

        }
    }
}
