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

        [HttpGet("IdUsuario")]
        public IActionResult GetContacts(int IdUsuario)
        {
            if (IdUsuario != 0)
            {
                var user = UnitOfWork.Usuarios.get(x => x.id == IdUsuario);
                if (user != null)
                {
                    var contactos = UnitOfWork.Contactos.get(x => x.IdUsuario == IdUsuario);
                    var result = CreateMappedObject(contactos,IdUsuario);
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

        private  ContactoList CreateMappedObject(IEnumerable<contacto>contactos,int IdUsuario)
        {
            ContactoList listaAmigos = new ContactoList();
            foreach(var item in contactos)
            {
                usuario contactoAmigo = UnitOfWork.Usuarios.GetById(item.idContacto);
                listaAmigos.contactoAgregados.Add(contactoAmigo);
            }
            listaAmigos.idUser = IdUsuario;
            return listaAmigos;
        }
    }
}
