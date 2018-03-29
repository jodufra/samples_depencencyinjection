using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.Core.Entities;
using Application.Core.Contexts;

namespace Application.Core.Repositories
{
    public abstract class BaseRepository<T> : ARepository<T> where T : IEntity, new()
    {
        protected readonly IContext Context;

        protected BaseRepository(IContext Context)
        {
            this.Context = Context;
        }

        public override IList<T> GetAll()
        {
            return (from p in Context.Query<T>() select p).ToList();
        }

        public override T GetById(int id)
        {
            return (from p in Context.Query<T>() where p.Id == id select p).FirstOrDefault();
        }
    }
}