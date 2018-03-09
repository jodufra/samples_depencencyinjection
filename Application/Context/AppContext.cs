using Application.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Context
{
    public class AppContext : BaseContext
    {

        public IList<User> Users = new List<User>();
        public IList<Todo> Todos = new List<Todo>();

        public AppContext()
        {
            Register(typeof(User), Users.AsQueryable());
            Register(typeof(Todo), Todos.AsQueryable());
            Seed();
        }

        void Seed()
        {
            const int usersCount = 5;
            const int todosCount = 10;

            for (int u = 0; u < usersCount; u++)
            {
                var user = new User
                {
                    Id = u + 1,
                    Name = $"User num. {u + 1}",
                    DateCreated = DateTime.Now
                };
                Users.Add(user);

                for (int t = 0; t < todosCount; t++)
                {
                    var isDone = t % 2 == 0;
                    var todo = new Todo
                    {
                        Id = u + 1,
                        IdUser = user.Id,
                        Description = $"Todo num. {t + 1}",
                        DateCreated = DateTime.Now,
                        IsDone = isDone,
                        DateDone = isDone ? DateTime.Now : (DateTime?)null,
                        DateUpdated = isDone ? DateTime.Now : (DateTime?)null
                    };
                    Todos.Add(todo);
                }
            }
        }

    }
}