using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class TodoQueryTest
    {
        private List<TodoItem> _itens;

        public TodoQueryTest()
        {
            _itens = new List<TodoItem>();
            _itens.Add(new TodoItem("Tarefa 01", "usuario1", DateTime.Now));
            _itens.Add(new TodoItem("Tarefa 02", "usuario1", DateTime.Now));
            _itens.Add(new TodoItem("Tarefa 03", "devleandrodias", DateTime.Now));
            _itens.Add(new TodoItem("Tarefa 04", "usuario1", DateTime.Now));
            _itens.Add(new TodoItem("Tarefa 05", "devleandrodias", DateTime.Now));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_devleandrodias()
        {
            IQueryable<TodoItem> queryable = _itens.AsQueryable().Where(TodoQueries.GetAll("devleandrodias"));
            Assert.AreEqual(2, queryable.Count());
        }
    }
}