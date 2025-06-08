using kolokwium.Properties.DTOs;

namespace kolokwium.Properties.Services;

public interface ICustomerService
{
  Task<bool>AddCustomerWithTicketsAsync(NewCustomerDto dto);
}