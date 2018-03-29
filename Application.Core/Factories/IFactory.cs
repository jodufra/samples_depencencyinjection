using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Factories
{
    public interface IFactory<T> : IDisposable where T : class, IDisposable
    {
        T GetPerRequest();
        T Build();
    }
}
