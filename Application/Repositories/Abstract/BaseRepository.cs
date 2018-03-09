using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.Entities;
using Application.Context;

namespace Application.Repositories
{
    public class BaseRepository<T> : ARepository<T> where T : IEntity, new()
    {
        protected readonly IContext Context;

        public BaseRepository(IContext Context)
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