namespace Kol2APBD.DTOs;

public class AddOwnerWithObjectsRequestDTO
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }

    public IEnumerable<int> ObjectsIds { get; set; }
}