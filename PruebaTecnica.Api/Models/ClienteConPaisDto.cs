namespace PruebaTecnica.Api.Models;
public class ClienteConPaisDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Pais { get; set; } = string.Empty;
}