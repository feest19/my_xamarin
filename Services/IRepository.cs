using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace firstapi.Services
{
    public interface IRepository<TEenty> where TEenty:class
    {
        void insert(TEenty entityToInsert);
        void update(TEenty entityToUpdate);
        IEnumerable<TEenty> get(Expression<Func<TEenty, bool>> filter = null,Func<IQueryable<TEenty>,
            IOrderedQueryable<TEenty>>ordeBy=null,string includeProperties="");

        TEenty GetById(object id);

        void Delete(TEenty entityToDelete);

        void Delete(Object id);
    }
}
