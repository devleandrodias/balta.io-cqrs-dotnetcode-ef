using System;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult()
        {

        }

        public GenericCommandResult(bool success, string message, Object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
    }
}