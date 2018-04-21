using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Application.Core.Contexts
{
    public class BaseContext : IContext
    {
        Dictionary<Type, FieldInfo> DataTypes;
        Dictionary<Type, object> DataSets;
        bool IsDisposed;

        protected BaseContext()
        {
            IsDisposed = false;

            DataTypes = new Dictionary<Type, FieldInfo>();
            DataSets = new Dictionary<Type, object>();

            var dataSetType = typeof(IDataSet);

            var type = GetType();
            var fields = type.GetFields();

            foreach (var fieldInfo in fields)
            {
                var dbSet = (IDataSet)fieldInfo.GetValue(this);
                var dbSetType = dbSet.DataType;

                DataTypes.Add(dbSetType, fieldInfo);

                dbSet.Added += OnAdd;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DataSet<T> Get<T>() where T : IEntity
        {
            return GetDataSet<T>();
        }

        public IQueryable<T> Query<T>() where T : IEntity
        {
            return GetDataSet<T>().AsQueryable();
        }

        protected static void OnAdd(object sender, EventArgs e)
        {
            var item = ((DataSetEventArgs<IEntity>)e).Instance;
            item.DateCreated = DateTime.Now;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;

            if (disposing)
                DataTypes.Clear();

            IsDisposed = true;
        }

        DataSet<T> GetDataSet<T>() where T : IEntity
        {
            var dataSetType = typeof(T);

            if (!DataTypes.ContainsKey(dataSetType))
                throw new ArgumentOutOfRangeException(dataSetType.ToString());

            if (!DataSets.ContainsKey(dataSetType))
                DataSets.Add(dataSetType, (DataSet<T>)DataTypes[dataSetType].GetValue(this));
            
            return (DataSet<T>)DataSets[dataSetType];
        }

    }
}