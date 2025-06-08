using kolokwium.Properties.DTOs;
using kolokwium.Properties.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium.Properties.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CustomerController:ControllerBase
{
    
        private readonly IGetPurchaseCustomer _purchaseService;

        public CustomerController(IGetPurchaseCustomer purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet("{customerId}/purchases")]
        public async Task<IActionResult> GetPurchases(int customerId)
        {
            var result = await _purchaseService.GetPurchasesByCustomerIdAsync(customerId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        
        private readonly ICustomerService _customerService;
        
            [HttpPost]
            public async Task<IActionResult> AddCustomer([FromBody] NewCustomerDto dto)
            {
                try
                {
                    var success = await _customerService.AddCustomerWithTicketsAsync(dto);
                    if (!success)
                        return NotFound("Klient już istnieje.");
                    return Ok("Klient dodany wraz z biletami.");
                }
                catch (InvalidOperationException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
    
    }
