using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface IDataSet
    {
        Type GetDataType();
        event EventHandler Added;
    }

    public class DataSet<T> : List<T>, IDataSet where T : IEntity
    {
        readonly Type _dataType;

        public DataSet()
        {
            _dataType = typeof(T);
        }

        public event EventHandler Added;

        public new void Add(T item)
        {
            Added?.Invoke(this, new DataSetEventArgs<IEntity>(item));
            base.Add(item);
        }

        public Type GetDataType() => _dataType;
    }
}
