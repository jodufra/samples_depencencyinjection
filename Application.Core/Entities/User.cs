using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zAnonimize;

namespace Application.Core.Entities
{
    [AnonimizeProperties(nameof(Name))]
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public User()
        {
            AnonimizeService.Register(this);
        }

    }

}