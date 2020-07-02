using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstapi.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstapi.Controllers
{
    [Route("api/[controller]")]
    public class ExampleController : Controller
    {
        private readonly mi_app_xamarinContext db;

        public ExampleController(mi_app_xamarinContext _db) {
            db = _db;
        }


        public IActionResult Get() {
            var data = db.Cliente.ToList();

            return Ok(data);
        }
    }
}
