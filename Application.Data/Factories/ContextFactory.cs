using Application.Core.Factories;
using Application.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Factories
{
    public class DbContextFactory : BaseFactory<DbContext>
    {
        public static DbContextFactory Instance = new DbContextFactory();

        public DbContextFactory() : base(nameof(DbContext))
        {
        }

        public DbContextFactory(string key) : base(key)
        {
        }

        public override DbContext Build()
        {
            return new DbContext();
        }
    }
}
