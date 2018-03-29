using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Data.Entities
{
    public class Todo : BaseEntity
    {
        public int IdUser { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime? DateDone { get; set; }
    }
}