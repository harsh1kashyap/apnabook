

using ApnaBook.Application.Common.Interfaces;

namespace ApnaBook.Application.Customer.Commands.DeleteCustomers;
public record DeleteCustomersCommands(int Id) : IRequest<int>;

public class DeleteCustomersCommandsHandler : IRequestHandler<DeleteCustomersCommands, int>
{
    private readonly IApplicationDbContext _context;
    public DeleteCustomersCommandsHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(DeleteCustomersCommands request, CancellationToken cancellationToken)
    {
        var existingCustomer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (existingCustomer == null)
            return 0;

        existingCustomer.IsDeleted = true;
        existingCustomer.DeletedOn = DateTime.Now;
        _context.Customers.Update(existingCustomer);
        await _context.SaveChangesAsync(cancellationToken);
        
        return 1;
    }
}
