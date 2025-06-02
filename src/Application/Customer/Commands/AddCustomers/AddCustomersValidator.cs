namespace ApnaBook.Application.Customer.Commands.AddCustomers;
public class AddCustomersValidator:AbstractValidator<AddCustomersCommands>
{
    public AddCustomersValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Name can't be Empty");

        RuleFor(x => x.CustomerEmail)
            .NotEmpty()
            .WithMessage("Email can't be Empty");

        RuleFor(x => x.CustomerPhone)
            .NotEmpty()
            .WithMessage("Phone can't be Empty");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password can't be Empty");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirm Password can't be Empty");
    }
}
