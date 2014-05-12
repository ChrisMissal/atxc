namespace UI.Validation
{
    using Core;
    using FluentValidation;
    using Models;

    public class PersonFormValidator : AbstractValidator<PersonForm>
    {
        public PersonFormValidator()
        {
            RuleFor(x => x.Name).Length(Constants.PersonNameLengthMin, Constants.PersonNameLengthMax);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Bio).Length(Constants.PersonBioLengthMin, Constants.PersonBioLengthMax);
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.Categories).NotEmpty();
        }
    }
}