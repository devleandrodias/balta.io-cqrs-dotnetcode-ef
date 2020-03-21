using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Generics;
using Todo.Domain.Handlers;

namespace Todo.Domain.Api.Controllers
{
    [Route("/v1/todos"), ApiController]
    public class TodoController : ControllerBase
    {
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {

        }
    }
}