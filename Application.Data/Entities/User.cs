using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zAnonimize;

namespace Application.Data.Entities
{
    public class User : BaseEntity
    {
        [Anonimize]
        public string Name { get; set; }
    }
}