using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using firstapi.Entities.Models;
using firstapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace firstapi.Controllers
{
    [Route("api/v1/mi_app_xamarinapi/[controller]")]
    public class UsuariosController : Controller
    {
        private mi_app_xamarinContext _context = new mi_app_xamarinContext();
        private UnitOfWork _UnitOfWork = new UnitOfWork(new mi_app_xamarinContext());
        [HttpGet]
        public IActionResult GetAllUser()
        {
            var clientes = _UnitOfWork.Clientes.get();
            if (clientes != null)
            {
                return Ok(clientes);
            }
            else
            {
                return Ok();
            }
        }
        [HttpGet("id")]

        public IActionResult GetById(int id)
        {
            Cliente clientes = _UnitOfWork.Clientes.GetById(id);
            if (clientes != null)
            {
                return Ok(clientes);
            }
            else
            {
                return BadRequest("no se a encontrado registro de id");
            }
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody]Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _UnitOfWork.Clientes.update(cliente);
                    _UnitOfWork.save();
                    return Ok();

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("id")]
        public IActionResult DeleteUser(int id)
        {
            if (id!= 0)
            {
                _UnitOfWork.Clientes.Delete(id);
                _UnitOfWork.save();
                return Ok("Usuario eliminado");

            }
            else
            {
                return BadRequest("usuario con id invalido");
            }
        }
    }
}
