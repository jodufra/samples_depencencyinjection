using System;
using System.Threading;
using System.Web;

namespace Application.Core.Factories
{
    public abstract class BaseFactory<T> : IFactory<T> where T : class, IDisposable
    {
        string Key;
        bool IsDisposed;

        protected BaseFactory(string key)
        {
            Key = key;
            IsDisposed = false;
        }

        public T GetPerRequest()
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null)
                return Build();

            var context = (T)httpContext.Items[Key];
            if (context == null)
            {
                context = Build();
                httpContext.Items[Key] = context;
            }

            return context;
        }

        public abstract T Build();

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
                GetPerRequest().Dispose();

            IsDisposed = true;
        }

    }
}
