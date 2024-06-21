using Kol2APBD.Context;
using Kol2APBD.DTOs;
using Kol2APBD.Models;
using Microsoft.EntityFrameworkCore;
using Object = Kol2APBD.Models.Object;

namespace Kol2APBD.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Owner> GetOwnerData(int id)
    {
        return await _context.Owners.Include(e => e.ObjectOwners)
            .ThenInclude(e => e.Object)
            .ThenInclude(e => e.ObjectType)
            .Include(e => e.ObjectOwners)
            .ThenInclude(e => e.Object).ThenInclude(e => e.ObjectType)
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> DoesOwnerExist(int id)
    {
        return await _context.Owners.AnyAsync(e => e.Id == id);
    }

    public async Task AddOwnerWithObjects(AddOwnerWithObjectsRequestDTO addOwnerWithObjectsRequestDto)
    {
        
        Owner newOwner = new Owner()
        {
            FirstName = addOwnerWithObjectsRequestDto.FirstName,
            LastName = addOwnerWithObjectsRequestDto.LastName,
            PhoneNumber = addOwnerWithObjectsRequestDto.PhoneNumber,
        };
        

        foreach (var id in addOwnerWithObjectsRequestDto.ObjectsIds)
        {
            _context.ObjectOwners.Add(new ObjectOwner()
            {
                ObjectId = id,
                Owner = newOwner
            });
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> DoesObjectsExist(IEnumerable<int> objectsIds)
    {
        foreach (var id in objectsIds)
        {
            if (!await _context.Objects.AnyAsync(e => e.Id == id))
            {
                return false;
            }
        }

        return true;
    }
}