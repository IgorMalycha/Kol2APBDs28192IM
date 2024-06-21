using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kol2APBD.Models;

[Table("Object_Type")]
public class ObjectType
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<Object> Objects { get; set; } = new HashSet<Object>();
}