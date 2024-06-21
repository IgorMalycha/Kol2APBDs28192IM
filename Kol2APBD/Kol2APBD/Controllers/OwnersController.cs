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
    public async Task<IActionResult> GetOwnerData(int Id)
    {
        if (!await _dbService.DoesOwnerExist(Id))
        {
            NotFound($"Owner wiht given id: {Id} does not exist");
        }
        
        var Owner = await _dbService.GetOwnerData(Id);

        var result = new GetOwnerDataDTO()
        {
            FirstName = Owner.FirstName,
            LastName = Owner.LastName,
            PhoneNumber = Owner.PhoneNumber,
            OwnerObjectsDTO = Owner.ObjectOwners.Select(e => new OwnerObjectDTO()
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
    public async Task<IActionResult> AddOwnerWithObjects([FromBody] AddOwnerWithObjectsDTO addOwnerWithObjectsDto)
    {



        await _dbService.AddOwnerWithObjects(addOwnerWithObjectsDto);
        
        
        return Created();
    }
}