using System;
using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Commands.Generics;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Ropositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Fail Fast Validation

            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua mensagem está errada!", command.Notifications);

            // Criar um todo

            // Salvar um todo no banco

            // Notificar o usuário

            throw new Exception();
        }
    }
}