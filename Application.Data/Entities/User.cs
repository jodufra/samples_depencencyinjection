using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Data.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
    }
}