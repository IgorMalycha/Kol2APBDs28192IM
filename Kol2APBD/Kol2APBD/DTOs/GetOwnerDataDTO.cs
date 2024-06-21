using Kol2APBD.Models;

namespace Kol2APBD.DTOs;

public class GetOwnerDataDTO
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }

    public ICollection<OwnerObjectDTO> OwnerObjectsDTO { get; set; }
}