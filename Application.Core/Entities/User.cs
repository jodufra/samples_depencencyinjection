using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Core.Entities
{
    public class User : BaseEntity
    {
        protected string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        protected string email;
        public string Email
        {
            get => email;
            set => email = value;
        }

        protected DateTime dateBirth;
        public DateTime DateBirth
        {
            get => dateBirth;
            set => dateBirth = value;
        }

        public int Age
        {
            get
            {
                return (DateTime.Now - DateBirth).Hours / 24 / 365;
            }
        }

    }

}