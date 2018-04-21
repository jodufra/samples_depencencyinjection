using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Core.Factories
{
    public interface IFactory<T> : IDisposable where T : class, IDisposable, new()
    {
        T GetPerRequest();
        T GetPerRequest(IDictionary dictionary);
        T Build();
    }
}
