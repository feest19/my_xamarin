using firstapi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstapi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private mi_app_xamarinContext _context;
        private BaseRepository<Cliente> _Clientes;
        private BaseRepository<Factura> _Factura;
        private BaseRepository<Hamburguesa> _Hamburgesa;

        public UnitOfWork(mi_app_xamarinContext dbcontext)
        {
            _context = dbcontext;
        }
        public IRepository<Cliente> Clientes
        {
            get
            {
                return _Clientes ?? (_Clientes = new BaseRepository<Cliente>(_context));
            }
        }

        public IRepository<Factura> Facturas
        {
            get
            {
                return _Factura ?? (_Factura = new BaseRepository<Factura>(_context));
            }
        }

        public IRepository<Hamburguesa> Hamburguesas {
            get {
                return _Hamburgesa ?? (_Hamburgesa = new BaseRepository<Hamburguesa>(_context));
            }
        }

        public void save()
        {
            throw new NotImplementedException();
        }
    }
}
