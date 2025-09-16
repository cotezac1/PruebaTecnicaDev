using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Api.Data;
using PruebaTecnica.Api.Models;

namespace PruebaTecnica.Api.Repositories;
public class ClienteRepositoryLinq : IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepositoryLinq(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedResult<ClienteDto>> GetClientesAsync(int pageNumber, int pageSize)
    {
        var query = from c in _context.Clientes
                    join p in _context.Paises on c.PaisId equals p.Id
                    select new ClienteDto
                    {
                        Id = c.Id,
                        Nombre = c.Nombre,
                        Telefono = c.Telefono,
                        Pais = p.Nombre 
                    };


        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResult<ClienteDto>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }
}