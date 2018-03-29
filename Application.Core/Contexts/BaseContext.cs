using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Core.Contexts
{
    public class BaseContext : IContext
    {
        bool IsDisposed;
        Dictionary<Type, IQueryable<IEntity>> Queriables;

        protected BaseContext()
        {
            IsDisposed = false;
            Queriables = new Dictionary<Type, IQueryable<IEntity>>();
        }

        protected void Register(Type type, IQueryable<IEntity> queriable)
        {
            Queriables.Add(type, queriable);
        }

        public IQueryable<T> Query<T>() where T : IEntity
        {
            var type = typeof(T);
            if (!Queriables.ContainsKey(type))
                throw new ArgumentOutOfRangeException(type.ToString());
            return (IQueryable<T>)Queriables[type];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;

            if (disposing)
            {
                foreach (var entity in Queriables.Values)
                {
                    entity.ToList().Clear();
                }
            }

            IsDisposed = true;
        }
    }
}