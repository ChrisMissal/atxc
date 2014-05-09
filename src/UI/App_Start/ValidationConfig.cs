namespace UI
{
    using FluentValidation.WebApi;
    using StructureMap;
    using Validation;

    public class ValidationConfig
    {
        public static void Register(IContainer container)
        {
            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new ValidatorFactory(container);
            });
        }
    }
}