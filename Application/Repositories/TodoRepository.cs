using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.Context;

namespace Application.Repositories
{
    public interface ITodoRepository : IRepository<Todo>
    {
        void SetDone(int idTodo, bool isDone);
    }

    public class TodoRepository : BaseRepository<Todo>, ITodoRepository
    {
        public TodoRepository(IContext Context) : base(Context)
        {
        }

        public void SetDone(int idTodo, bool isDone)
        {
            var todo = GetById(idTodo);
            if (todo == null)
                return;

            todo.IsDone = isDone;
            todo.DateDone = isDone ? DateTime.Now : (DateTime?) null;
            todo.DateUpdated = DateTime.Now;
        }
    }
}