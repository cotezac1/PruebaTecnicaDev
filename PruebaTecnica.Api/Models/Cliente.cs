﻿namespace PruebaTecnica.Api.Models
{
    public class Cliente
    {        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public int PaisId { get; set; }
    }
}
