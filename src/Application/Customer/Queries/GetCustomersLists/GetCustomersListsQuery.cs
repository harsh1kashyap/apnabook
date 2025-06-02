
using ApnaBook.Application.Common.Interfaces;
using ApnaBook.Domain.Enums;

namespace ApnaBook.Application.Customer.Queries.GetCustomersLists;
public record GetCustomersListsQuery:IRequest<List<CustomersDTO>>;

public class GetCustomersListsQueryHandler : IRequestHandler<GetCustomersListsQuery, List<CustomersDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetCustomersListsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<CustomersDTO>> Handle(GetCustomersListsQuery request, CancellationToken cancellationToken)
    {
        var listOfCustomers = await _context.Customers
                    .AsNoTracking()
                    .Where(x => x.IsDeleted == false)
                    .ProjectTo<CustomersDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

        if(listOfCustomers.Count>0)
        {
            listOfCustomers.ForEach(x => x.RoleName = Enum.GetName(typeof(MasterRole), x.RoleId) ?? string.Empty);
        }
        
        return listOfCustomers ?? new List<CustomersDTO>();
    }
}
