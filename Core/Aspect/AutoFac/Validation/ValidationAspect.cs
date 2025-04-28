using Castle.DynamicProxy;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.AutoFac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Lütfen Geçerli Bir IValidator Giriniz ");
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invacation)  
        {
            var validator = (IValidator?)Activator.CreateInstance(_validatorType);

            var entityType = _validatorType?.BaseType?.GetGenericArguments()[0];

            var entities = invacation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator!, entity);
            }
        }
    }
}