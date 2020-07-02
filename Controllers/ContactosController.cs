using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using firstapi.Entities.Models;
using firstapi.Services;
using System.Net;
using Newtonsoft.Json;
using firstapi.Entities.DTOs;
using System.Diagnostics;

namespace firstapi.Controllers
{
    [Route("api/v1/mi_app_xamarinapi/[controller]")]
    public class ContactosController : Controller
    {
        private UnitOfWork UnitOfWork = new UnitOfWork(new mi_app_xamarinContext());
        private mi_app_xamarinContext _context = new mi_app_xamarinContext();

        [HttpGet("{IdCliente}")]
        public IActionResult GetFacturas(int IdCliente)
        {
            if (IdCliente != 0)
            {
                var cliente = UnitOfWork.Clientes.get(x => x.IdCliente == IdCliente);
                if (cliente != null)
                {
                    var facturas = UnitOfWork.Facturas.get(x => x.Idcliente == IdCliente);
                    var result = CreateMappedObject(facturas,IdCliente);
                    var serializedList = JsonConvert.SerializeObject(result, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                        }
                            );
                    return Ok(serializedList);
                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        private ContactoList CreateMappedObject(IEnumerable<Factura> factura, int IdCliente)
        {
            ContactoList listaFacturas = new ContactoList();
            foreach (var item in factura)
            {
                var _factura = UnitOfWork.Facturas.GetById(item.IdFactura);
                listaFacturas.ListFactura.Add(_factura);
            }
            listaFacturas.idUser = IdCliente;
            return listaFacturas;
        }
    }
}
