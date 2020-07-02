using firstapi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstapi.Services
{
    public interface IUnitOfWork
    {
        IRepository<Cliente> Clientes { get; }
        IRepository<Factura> Facturas { get; }
        IRepository<Hamburguesa> Hamburguesas { get; }

        void save();
    }
}
