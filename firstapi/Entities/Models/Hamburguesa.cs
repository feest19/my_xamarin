using System;
using System.Collections.Generic;

namespace firstapi.Entities.Models
{
    public partial class Hamburguesa
    {
        public int IdHamburguesa { get; set; }
        public string NombreHamurguesa { get; set; }
        public string Descripcion { get; set; }
        public string PrecioHamburguesa { get; set; }
        public string PresentacionHamburguesa { get; set; }
    }
}
