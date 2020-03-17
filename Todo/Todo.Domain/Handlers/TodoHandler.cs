using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Commands.Generics;
using Todo.Domain.Entities;
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
            // Fail Fast Validation
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua mensagem está errada!", command.Notifications);

            // Criar um todo
            TodoItem todoItem = new TodoItem(command.Title, command.User, command.Date);

            // Salvar um todo no banco
            _repository.Create(todoItem);

            // Retornar o resultadp
            return new GenericCommandResult(true, "Tarefa salva com sucesso!", todoItem);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua mensagem está errada", command.Notifications);

            // Recuperar um TodoItem (Rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            // Altera o título
            todo.UpdateTitle(command.Title);

            // Salvar no banco
            _repository.Update(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa atualizada com sucesso!", command.Notifications);
        }
    }
}