using Application.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class HomeIndexModel
    {
        public IList<User> Users { get; set; }

    }
}