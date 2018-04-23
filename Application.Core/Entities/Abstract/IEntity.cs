using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Application.Core.Entities
{
    public interface IEntity : INotifyPropertyChanged
    {
        int Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateUpdated { get; set; }
        bool IsNew { get; }
    }
}