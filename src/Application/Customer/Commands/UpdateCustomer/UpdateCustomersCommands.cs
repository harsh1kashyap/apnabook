using ApnaBook.Application.Common.Interfaces;

namespace ApnaBook.Application.Customer.Commands.UpdateCustomer;
public class UpdateCustomersCommands:IRequest<int>
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public int RoleId { get; set; }
}

public class UpdateCustomersCommandsHandler : IRequestHandler<UpdateCustomersCommands, int>
{
    private readonly IApplicationDbContext _context;
    public UpdateCustomersCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateCustomersCommands request, CancellationToken cancellationToken)
    {
        var existingCustomer = await _context.Customers
                                .FirstOrDefaultAsync(x => x.Id == request.Id && x.IsDeleted == false);

        if (existingCustomer == null) {
            return 0;
        }

        existingCustomer.CustomerName = request.CustomerName;
        existingCustomer.CustomerEmail = request.CustomerEmail;
        existingCustomer.CustomerPhone = request.CustomerPhone;
        existingCustomer.Role = request.RoleId;

        _context.Customers.Update(existingCustomer);
        await _context.SaveChangesAsync(cancellationToken);
        return existingCustomer.Id;
    }
}
