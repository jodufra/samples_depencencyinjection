using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.Core.Repositories;
using Application.Core.Contexts;
using Application.Core.Entities;

namespace Application.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

    }

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IContext Context) : base(Context)
        {
        }
    }
}