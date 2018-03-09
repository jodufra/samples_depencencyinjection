using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateUpdated { get; set; }
    }
}