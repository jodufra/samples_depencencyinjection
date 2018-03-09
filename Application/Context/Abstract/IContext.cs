using Application.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Context
{
    public interface IContext 
    {
        IQueryable<T> Query<T>() where T : IEntity ;
    }
}