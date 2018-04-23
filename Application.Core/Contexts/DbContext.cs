using Application.Core;
using Application.Core.Contexts;
using Application.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Core.Contexts
{
    public class DbContext : BaseContext
    {
        public DataSet<Todo> Todos = new DataSet<Todo>();
        public DataSet<User> Users = new DataSet<User>();

        public DbContext()
        {
            Seed();
        }

        static Todo GenerateTodo(int id)
        {
            var isDone = id % 2 == 0;
            var todo = new Todo
            {
                Id = id + 1,
                Description = $"Todo num. {id + 1}",
                IsDone = isDone,
                DateDone = isDone ? DateTime.Now : (DateTime?)null
            };
            return todo;
        }

        static User GenerateUser(int id)
        {
            var user = new User
            {
                Id = id + 1,
                FullName = $"User num. {id + 1}"
            };
            return user;
        }

        void Seed()
        {
            const int usersCount = 5;
            const int todosCount = 10;

            for (int u = 0; u < usersCount; u++)
            {
                var user = GenerateUser(u);
                Users.Add(user);

                for (int t = 0; t < todosCount; t++)
                {
                    var todo = GenerateTodo(t);
                    todo.IdUser = user.Id;
                    Todos.Add(todo);
                }
            }
        }
    }
}