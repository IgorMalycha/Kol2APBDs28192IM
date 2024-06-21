using System.Transactions;
using Kol2APBD.DTOs;
using Kol2APBD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kol2APBD.Controllers;

[Route("api/owners")]
[ApiController]
public class OwnersController : ControllerBase
{
    private readonly IDbService _dbService;
    public OwnersController(IDbService dbService)
    {
        _dbService = dbService;
    }


    [HttpGet("{Id}")]
    public async Task<IActionResult> GetOwnerData(int id)
    {
        if (!await _dbService.DoesOwnerExist(id))
        {
            NotFound($"Owner wiht given id: {id} does not exist");
        }
        
        var owner = await _dbService.GetOwnerData(id);

        var result = new GetOwnerDataDTO()
        {
            FirstName = owner.FirstName,
            LastName = owner.LastName,
            PhoneNumber = owner.PhoneNumber,
            OwnerObjectsDTO = owner.ObjectOwners.Select(e => new OwnerObjectDTO()
            {
                Id = e.Object.Id,
                Width = e.Object.Width,
                Height = e.Object.Height,
                Type = e.Object.ObjectType.Name,
                Warehouse = e.Object.Warehouse.Name
            }).ToList()
        };

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddOwnerWithObjects([FromBody] AddOwnerWithObjectsRequestDTO addOwnerWithObjectsDto)
    {

        if (!await _dbService.DoesObjectsExist(addOwnerWithObjectsDto.ObjectsIds))
        {
            return NotFound("One of given Objects Id does not exist");
        }

        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddOwnerWithObjects(addOwnerWithObjectsDto);
            
            scope.Complete();
        }

        return Created();
        
    }
}