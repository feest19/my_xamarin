using firstapi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstapi.Entities.DTOs
{
    public class ContactoList
    {
        public int idUser { get; set; }
        public List<Factura> ListFactura { get; set; }
    }
}
