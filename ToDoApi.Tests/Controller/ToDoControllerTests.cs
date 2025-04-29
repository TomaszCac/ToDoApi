using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Controllers;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Tests.Controller
{
    public class ToDoControllerTests
    {
        private readonly IToDoRepository _todorepos;

        public ToDoControllerTests()
        {
            _todorepos = A.Fake<IToDoRepository>();
        }

        [Fact]
        public void ToDoController_Get_ReturnOk()
        { 
            var controller = new ToDoController(_todorepos);
           
            var result = controller.Get();

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void ToDoController_GetByID_ReturnOk()
        {
            int id = 1;
            var controller = new ToDoController(_todorepos);

            var result = controller.Get(id);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));


        }
        [Fact]
        public void ToDoController_GetIncoming_ReturnOk()
        {
            string when = "today";
            var controller = new ToDoController(_todorepos);

            var result = controller.Get(when);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));

        }
        [Fact]
        public void ToDoController_Post_ReturnObjectResult()
        {
            var todo = A.Fake<ToDo>();
            var controller = new ToDoController(_todorepos);

            var result = controller.Post(todo);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));
        }
        [Fact]
        public void ToDoController_Put_ReturnNoContent()
        {
            int id = 1;
            var todo = A.Fake<ToDo>();
            var controller = new ToDoController(_todorepos);
            A.CallTo(() => _todorepos.Update(todo)).Returns(true);

            var result = controller.Put(id, todo);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void ToDoController_SetPercent_ReturnNoContent()
        {
            int id = 1;
            int percent = 20;
            var controller = new ToDoController(_todorepos);
            A.CallTo(() => _todorepos.SetPercent(id, percent)).Returns(true);

            var result = controller.SetPercent(id, percent);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void ToDoController_Delete_ReturnNoContent()
        {
            int id = 1;
            var controller = new ToDoController(_todorepos);
            A.CallTo(() => _todorepos.Delete(id)).Returns(true);

            var result = controller.Delete(id);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NoContentResult));
        }
        [Fact]
        public void ToDoController_Complete_ReturnsNoContent()
        {
            int id = 1;
            var controller = new ToDoController(_todorepos);
            A.CallTo(() => _todorepos.Complete(id)).Returns(true);

            var result = controller.Complete(id);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NoContentResult));
        }
    }
}
