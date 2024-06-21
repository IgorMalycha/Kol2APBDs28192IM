using Kol2APBD.Models;
using Microsoft.EntityFrameworkCore;
using Object = Kol2APBD.Models.Object;

namespace Kol2APBD.Context;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<ObjectType> ObjectTypes { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Object> Objects { get; set; }
    public DbSet<ObjectOwner> ObjectOwners { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Warehouse>().HasData(new List<Warehouse>
        {
            new Warehouse() {
                Id = 1,
                Name = "jakis",
            }
        });

            modelBuilder.Entity<ObjectType>().HasData(new List<ObjectType>
            {
                new ObjectType() {
                    Id = 1,
                    Name = "jaisobj"
                }
            });

            modelBuilder.Entity<Owner>().HasData(new List<Owner>
            {
                new Owner()
                {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "kowal",
                    PhoneNumber = "999999999"
                }
            });

            modelBuilder.Entity<Object>().HasData(new List<Object>
            {
                new Object()
                {
                    Id = 1,
                    WarehouseId = 1,
                    ObjectTypeId = 1,
                    Width = 2.1M,
                    Height = 2.1M
                }
            });

            modelBuilder.Entity<ObjectOwner>().HasData(new List<ObjectOwner>
            {
                new ObjectOwner()
                {
                    ObjectId = 1,
                    OwnerId = 1
                }
            });
    }
}