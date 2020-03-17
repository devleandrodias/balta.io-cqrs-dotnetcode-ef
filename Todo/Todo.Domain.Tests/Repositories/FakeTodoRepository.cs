using System;
using Todo.Domain.Entities;
using Todo.Domain.Ropositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem item)
        {

        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("Título Aqui", "devleandrodias", DateTime.Now);
        }

        public void Update(TodoItem item)
        {

        }
    }
}