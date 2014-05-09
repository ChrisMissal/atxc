namespace UI.Validation
{
    using FluentValidation;
    using Models;

    public class PersonFormValidator : AbstractValidator<PersonForm>
    {
        public PersonFormValidator()
        {
            RuleFor(x => x.Name).Length(3, 30);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Bio).Length(15, 160);
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.Categories).NotEmpty();
        }
    }
}