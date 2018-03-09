using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Context
{
    public class BaseContext : IContext
    {
        Dictionary<Type, IQueryable<IEntity>> _Queriables;

        protected BaseContext()
        {
            _Queriables = new Dictionary<Type, IQueryable<IEntity>>();
        }

        protected void Register(Type type, IQueryable<IEntity> queriable)
        {
            _Queriables.Add(type, queriable);
        }

        public IQueryable<T> Query<T>() where T : IEntity
        {
            var type = typeof(T);
            if (!_Queriables.ContainsKey(type))
                throw new ArgumentOutOfRangeException(type.ToString());
            return (IQueryable<T>)_Queriables[type];
        }
    }
}