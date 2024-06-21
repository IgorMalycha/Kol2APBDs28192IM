namespace Kol2APBD.DTOs;

public class AddOwnerWithObjectsDTO
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }

    public IEnumerable<int> ObjectsIds { get; set; }
}