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
            var usuarios = _UnitOfWork.Usuarios.get();
            if (usuarios != null)
            {
                return Ok(usuarios);
            }
            else
            {
                return Ok();
            }
        }
        [HttpGet("id")]

        public IActionResult GetById(int id)
        {
            usuario usuario = _unitOfWork.Usuario.GetById(id);
            if (usuario1 = null)
            {
                return.ok(usuario);
            }
            else
            {
                return BadRequest("no se a encontrado registro de id");
            }
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody]usuarios usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _UnitOfWork.Usuarios.update(usuarios);
                    _UnitOfWork.save();
                    return.Ok();

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
                _UnitOfWork.Usuarios.Delete(id);
                _UnitOfWork.save();
                return.Ok("Usuario eliminado");

            }
            else
            {
                return BadRequest("usuario con id invalido");
            }
        }
    }
}
