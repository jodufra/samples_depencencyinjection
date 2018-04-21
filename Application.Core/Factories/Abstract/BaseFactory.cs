using System;
using System.Collections;
using System.Threading;
using System.Web;

namespace Application.Core.Factories
{
    public abstract class BaseFactory<T> : IFactory<T> where T : class, IDisposable, new()
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
            return GetPerRequest(GetContextDictionary());
        }

        public T GetPerRequest(IDictionary dictionary)
        {
            if (dictionary == null)
                return Build();

            var value = (T)dictionary[Key];
            if (value == null)
            {
                value = Build();
                dictionary[Key] = value;
            }

            return value;
        }

        public virtual T Build()
        {
            return new T();
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
                var dictionary = GetContextDictionary();
                if (dictionary != null)
                {
                    var value = (T)dictionary[Key];
                    if (value != null)
                    {
                        value.Dispose();
                    }
                }
            }

            IsDisposed = true;
        }

        protected virtual IDictionary GetContextDictionary()
        {
            return HttpContext.Current?.Items;
        }
    }
}
