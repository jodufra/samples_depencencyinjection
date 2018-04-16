using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    /// <summary>Represents the base class for classes that contain event data, and provides a value to use for events that do not include event data. </summary>
    public sealed class DataSetEventArgs<T> : EventArgs
    {
        public T Instance;

        public DataSetEventArgs()
        {
        }

        public DataSetEventArgs(T Instance)
        {
            this.Instance = Instance;
        }
    }
}
