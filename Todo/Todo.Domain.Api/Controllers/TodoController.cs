using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Generics;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Ropositories;

namespace Todo.Domain.Api.Controllers
{
    [Route("/v1/todos"), ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            return repository.GetAll("devleandrodias");
        }

        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "devleandrodias";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}