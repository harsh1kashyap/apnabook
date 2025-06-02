
using ApnaBook.Application.Common.Interfaces;
using ApnaBook.Domain.Enums;

namespace ApnaBook.Application.Customer.Queries.GetCustomersById;
public record GetCustomersByIdQuery(int Id):IRequest<CustomersDTO>;

public class GetCustomersByIdQueryHandler : IRequestHandler<GetCustomersByIdQuery, CustomersDTO>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomersByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomersDTO> Handle(GetCustomersByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Customers
                        .AsNoTracking()
                        .Where(x => x.Id == request.Id)
                        .ProjectTo<CustomersDTO>(_mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync(cancellationToken);

        if (result != null)
        {
            result.RoleName = Enum.GetName(typeof(MasterRole), result.RoleId) ?? string.Empty;
        }

        return result ?? new CustomersDTO();

    }
}

