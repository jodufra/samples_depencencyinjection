using Cauldron.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zAnonimize
{
    /// <summary>Represents the base class for custom attributes.</summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class AnonimizeAttribute : Attribute, IPropertyInterceptor
    {
        public string EncryptedValue { get; set; }

        public string DecryptedValue { get; set; }

        public bool OnException(Exception e)
        {
            throw e;
        }

        public void OnExit()
        {
        }

        public void OnGet(PropertyInterceptionInfo propertyInterceptionInfo, object value)
        {
            
        }

        public bool OnSet(PropertyInterceptionInfo propertyInterceptionInfo, object oldValue, object newValue)
        {
            if(DecryptedValue != (string)newValue && EncryptedValue != (string)newValue)
            {
                DecryptedValue = (string)newValue;
                EncryptedValue = Anonimize.Encrypt(DecryptedValue);
                propertyInterceptionInfo.SetValue(EncryptedValue);
            }
            return true;
        }
    }
}
