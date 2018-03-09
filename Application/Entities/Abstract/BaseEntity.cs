using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public bool IsNew { get { return Id == 0; } }
    }
}