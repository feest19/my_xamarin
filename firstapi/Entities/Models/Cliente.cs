using System;
using System.Collections.Generic;

namespace firstapi.Entities.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int? Celular { get; set; }
        public string Direccion { get; set; }
        public string MetodoPago { get; set; }
    }
}
