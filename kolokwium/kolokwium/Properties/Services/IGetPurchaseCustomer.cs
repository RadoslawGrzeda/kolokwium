using kolokwium.Properties.DTOs;

namespace kolokwium.Properties.Services;

public interface IGetPurchaseCustomer
{
     Task<ICollection<CustomerPurchaseDto>>GetCustomerPurchase(int customerId);
}