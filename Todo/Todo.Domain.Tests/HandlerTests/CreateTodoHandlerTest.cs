using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTest
    {
        [TestMethod]
        public void Dado_um_comando_invalido_deve_interrompar_a_execucao()
        {
            CreateTodoCommand createTodoCommand = new CreateTodoCommand("", "", DateTime.Now);
            TodoHandler todoHandler = new TodoHandler(repository: null);
            Assert.Fail();
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            Assert.Fail();
        }
    }
}