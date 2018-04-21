using Application.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Core.Contexts
{
    public interface IContext : IDisposable
    {
        DataSet<T> Get<T>() where T : IEntity;
        IQueryable<T> Query<T>() where T : IEntity;
    }
}