using System;
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
        private string _userName = "devleandrodias";
        private DateTime _today = DateTime.Now.Date;

        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            return repository.GetAll(_userName);
        }

        [HttpGet("done")]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllDone(_userName);
        }

        [HttpGet("done/today")]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
        {
            return repository.GetAllByPeriod(_userName, _today, true);
        }

        [HttpGet("done/tomorrow")]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
        {
            return repository.GetAllByPeriod(_userName, _today.AddDays(1), true);
        }

        [HttpGet("undone")]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllDone(_userName);
        }

        [HttpGet("undone/today")]
        public IEnumerable<TodoItem> GetAllUndoneForToday([FromServices] ITodoRepository repository)
        {
            return repository.GetAllByPeriod(_userName, _today, false);
        }

        [HttpGet("undone/tomorrow")]
        public IEnumerable<TodoItem> GetAllUndoneForTomorrow([FromServices] ITodoRepository repository)
        {
            return repository.GetAllByPeriod(_userName, _today.AddDays(1), false);
        }

        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = _userName;
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = _userName;
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut("mark-as-done")]
        public GenericCommandResult MarkAsDone([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = _userName;
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut("mark-as-undone")]
        public GenericCommandResult MarkAsUndone([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = _userName;
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}