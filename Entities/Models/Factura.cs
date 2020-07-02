using System;
using System.Collections.Generic;

namespace firstapi.Entities.Models
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public string NombreCliente { get; set; }
        public string NombreHamburguesa { get; set; }
        public string PrecioHamburguesa { get; set; }
        public string DescripcionHamburguesa { get; set; }
        public string DireccionCliente { get; set; }
        public string MetodoPago { get; set; }
        public int? Idcliente { get; set; }
    }
}
