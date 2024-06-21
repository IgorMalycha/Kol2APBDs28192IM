using System.ComponentModel.DataAnnotations;

namespace Kol2APBD.Models;

public class Owner
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(9)]
    public string PhoneNumber { get; set; }

    public ICollection<ObjectOwner> ObjectOwners { get; set; }
}