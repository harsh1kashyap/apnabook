

namespace ApnaBook.Application.Customer.Commands.UpdateCustomer;
public class UpdateCustomersCommandsValidator:AbstractValidator<UpdateCustomersCommands>
{
    public UpdateCustomersCommandsValidator()
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
    }
}
