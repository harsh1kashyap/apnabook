
using ApnaBook.Domain.Entities;
using ApnaBook.Domain.Enums;

namespace ApnaBook.Application.Customer.Queries;
public class CustomersDTO
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Customers, CustomersDTO>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.CustomerPhone, opt => opt.MapFrom(src => src.CustomerPhone))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.CustomerEmail))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.RoleName, opt => opt.Ignore());
        }
    }
}
