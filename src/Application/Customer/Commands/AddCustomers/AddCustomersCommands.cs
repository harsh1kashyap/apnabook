

using ApnaBook.Application.Common.Interfaces;
using ApnaBook.Domain.Entities;

namespace ApnaBook.Application.Customer.Commands.AddCustomers;
public class AddCustomersCommands:IRequest<int>
{
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public int RoleId { get; set; }
}

public class AddCustomersCommandsHandler : IRequestHandler<AddCustomersCommands, int>
{
    private readonly IApplicationDbContext _context;
    public AddCustomersCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(AddCustomersCommands request, CancellationToken cancellationToken)
    {
        var entity = new Customers{
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail,
            CustomerPhone = request.CustomerPhone,
            Password = request.Password,
            ConfirmPassword = request.ConfirmPassword,
            Role = request.RoleId
        };

        await _context.Customers.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
