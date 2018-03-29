using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Core.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        IList<T> GetAll();
        T GetById(int id);
    }

    public abstract class ARepository<T> : IRepository<T> where T : IEntity, new()
    {
        public abstract IList<T> GetAll();

        public abstract T GetById(int id);
    }
}