using System;

namespace Application.Core
{
    public interface IDataSet
    {
        Type DataType { get; }
        event EventHandler Added;
    }
}
