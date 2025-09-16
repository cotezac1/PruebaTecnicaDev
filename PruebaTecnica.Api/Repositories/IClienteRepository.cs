using PruebaTecnica.Api.Models;
namespace PruebaTecnica.Api.Repositories
{
    public interface IClienteRepository
    {
        Task<PaginatedResult<ClienteDto>> GetClientesAsync(int pageNumber, int pageSize);
    }
}
