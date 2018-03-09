using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.Context;

namespace Application.Repositories
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