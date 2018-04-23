using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Core.Entities
{
    public class User : BaseEntity
    {
        protected string firstName;
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        protected string lastName;
        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public string FullName
        {
            get => $"{firstName} {lastName}";
            set {
                var indexOfSpace = value.IndexOf(' ');
                if (indexOfSpace < 0)
                    lastName = string.Empty;
                firstName = value.Substring(0, indexOfSpace);
                lastName = value.Substring(indexOfSpace, value.Length - 1);
            }
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