using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kol2APBD.Models;

public class Object
{
    [Key]
    public int Id { get; set; }
    public int WarehouseId { get; set; }
    public int ObjectTypeId { get; set; }
    [DataType("decimal")]
    [Precision(4, 2)]
    public decimal Width { get; set; }
    [DataType("decimal")]
    [Precision(4, 2)]
    public decimal Height { get; set; }

    [ForeignKey(nameof(WarehouseId))]
    public Warehouse Warehouse { get; set; }

    [ForeignKey(nameof(ObjectTypeId))]
    public ObjectType ObjectType { get; set; }

    public ICollection<ObjectOwner> ObjectOwners { get; set; }
}