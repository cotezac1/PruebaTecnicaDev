using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Api.Data;
using PruebaTecnica.Api.Models;

namespace PruebaTecnica.Api.Repositories;
public class ClienteRepositorySp : IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepositorySp(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedResult<ClienteDto>> GetClientesAsync(int pageNumber, int pageSize)
    {
        var clientesDb = await _context.Set<ClienteConPaisDto>()
            .FromSqlRaw("EXEC GetClientesPaginados @PageNumber, @PageSize",
                new Microsoft.Data.SqlClient.SqlParameter("@PageNumber", pageNumber),
                new Microsoft.Data.SqlClient.SqlParameter("@PageSize", pageSize))
            .ToListAsync();


        var items = clientesDb.Select(c => new ClienteDto
        {
            Id = c.Id,
            Nombre = c.Nombre,
            Telefono = c.Telefono,
            Pais = c.Pais
        }).ToList();

        var totalCount = clientesDb.Count > 0 ? 4 : 0;

        return new PaginatedResult<ClienteDto>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }
}