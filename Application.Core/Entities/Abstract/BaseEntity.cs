using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Application.Core.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsNew)));
                }
            }
        }

        protected DateTime _dateCreated;
        public DateTime DateCreated
        {
            get
            {
                return _dateCreated;
            }
            set
            {
                if (value != _dateCreated)
                {
                    _dateCreated = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateCreated)));
                }
            }
        }

        protected DateTime? _dateUpdated;
        public DateTime? DateUpdated
        {
            get
            {
                return _dateUpdated;
            }
            set
            {
                if (value != _dateUpdated)
                {
                    _dateUpdated = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateUpdated)));
                }
            }
        }

        public bool IsNew
        {
            get
            {
                return Id == 0;
            }
        }
    }
}