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
    
    
}