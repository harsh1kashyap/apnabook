using ApnaBook.Application.Customer.Commands.AddCustomers;
using ApnaBook.Application.Customer.Commands.DeleteCustomers;
using ApnaBook.Application.Customer.Commands.UpdateCustomer;
using ApnaBook.Application.Customer.Queries;
using ApnaBook.Application.Customer.Queries.GetCustomersById;
using ApnaBook.Application.Customer.Queries.GetCustomersLists;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApnaBook.Web.Endpoints;

public class Customer:EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetCustomerById, "{id}")
            .MapGet(GetListOfCustomer, "GetListOfCustomer")
            .MapPost(CreateCustomer, "CreateCustomer")
            .MapPost(UpdateCustomer, "UpdateCustomer")
            .MapDelete(DeleteCustomer, "{id}");
    }

    public async Task<CustomersDTO> GetCustomerById(ISender sender, int id)
    {
        var result = await sender.Send(new GetCustomersByIdQuery(id));
        return result;
    }
    public Task<List<CustomersDTO>> GetListOfCustomer(ISender sender)
    {
        return sender.Send(new GetCustomersListsQuery());
    }

    public Task<int> CreateCustomer(ISender sender, AddCustomersCommands command)
    {
        return sender.Send(command);
    }

    public Task<int> UpdateCustomer(ISender sender, UpdateCustomersCommands command)
    {
        return sender.Send(command);
    }

    public Task<int> DeleteCustomer(ISender sender, int id)
    {
        return sender.Send(new DeleteCustomersCommands(id));
    }
}
