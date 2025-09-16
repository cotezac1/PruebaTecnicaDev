using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Api.Models;
using PruebaTecnica.Api.Repositories;

namespace PruebaTecnica.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClienteRepositoryLinq _linqRepo;
    private readonly ClienteRepositorySp _spRepo;

    public ClientesController(ClienteRepositoryLinq linqRepo, ClienteRepositorySp spRepo)
    {
        _linqRepo = linqRepo;
        _spRepo = spRepo;
    }

    [HttpGet("linq")]
    public async Task<IActionResult> GetByLinq([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _linqRepo.GetClientesAsync(pageNumber, pageSize);
        return Ok(result);
    }

    [HttpGet("sp")]
    public async Task<IActionResult> GetBySp([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _spRepo.GetClientesAsync(pageNumber, pageSize);
         return Ok(result);
    }
}