namespace UI.Validation
{
    using System;
    using FluentValidation;
    using StructureMap;

    public class ValidatorFactory : IValidatorFactory
    {
        private readonly IContainer _container;

        public ValidatorFactory(IContainer container)
        {
            _container = container;
        }

        public IValidator<T> GetValidator<T>()
        {
            return _container.GetInstance<IValidator<T>>();
        }

        public IValidator GetValidator(Type type)
        {
            var genericValidator = typeof (IValidator<>).MakeGenericType(type);
            return (IValidator) _container.TryGetInstance(genericValidator);
        }
    }
}