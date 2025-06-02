

namespace ApnaBook.Application.Customer.Commands.DeleteCustomers;
public class DeleteCustomersCommandsValidator : AbstractValidator<DeleteCustomersCommands>
{
    public DeleteCustomersCommandsValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id Not Found");
    }
}
