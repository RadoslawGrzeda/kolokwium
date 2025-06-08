using kolokwium.Properties.Data;

namespace kolokwium.Properties.Services;

public class Service:IService
{
    private readonly Database _context;

    public Service(Database context)
    {
        _context = context;
    }
    
}
// public async Task<GetPatientInformationDto?> GetPatientByIdAsync(int idPatient)
    