using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zAnonimize
{
    /// <summary>Represents the base class for custom attributes.</summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class AnonimizePropertyAttribute : Attribute
    {

    }
}
