

namespace ApnaBook.Application.Customer.Queries.GetCustomersById;
public class GetCustomersByIdQueryValidator:AbstractValidator<GetCustomersByIdQuery>
{
    public GetCustomersByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Customer Id Not Found");
    }
}
