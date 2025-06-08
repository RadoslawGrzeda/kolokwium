using kolokwium.Properties.DTOs;

namespace kolokwium.Properties.Services;

public interface IGetPurchaseCustomer
{
     Task<CustomerPurchasesDto?> GetPurchasesByCustomerIdAsync(int customerId);
}