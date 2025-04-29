using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Data;
using ToDoApi.Models;
using ToDoApi.Repositories;

namespace ToDoApi.Tests.Repository
{
    public class ToDoRepositoryTests
    {
        private async Task<MariaDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<MariaDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new MariaDatabaseContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.ToDos.CountAsync() <= 0 )
            {
                for ( int i = 0; i < 10; i++ )
                {
                    dbContext.ToDos.Add(new ToDo
                    {
                        Title = "Learn geometrics",
                        Description = "Learning by listening to podcasts",
                        CompletePercent = 20,
                        Expiration = DateTime.Now.AddDays(1)
                    }
                    );
                    await dbContext.SaveChangesAsync();
                }
            }
            return dbContext;
        }
        [Fact]
        public async void ToDoRepository_GetAll_ReturnsToDos()
        {
            var dbContext = await GetDatabaseContext();
            var repos = new ToDoRepository(dbContext);

            var result = repos.GetAll();

            result.Should().BeOfType(typeof(List<ToDo>));
        }
        [Fact]
        public async void ToDoRepository_GetById_ReturnsToDo()
        {
            int id = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new ToDoRepository(dbContext);

            var result = repos.GetById(id);

            result.Should().BeOfType(typeof(ToDo));

        }
        [Fact]
        public async void ToDoRepository_GetIncoming_ReturnsToDos()
        {
            string when = "today";
            var dbContext = await GetDatabaseContext();
            var repos = new ToDoRepository(dbContext);

            var result = repos.GetIncoming(when);

            result.Should().BeOfType(typeof(List<ToDo>));
        }
        [Fact]
        public async void ToDoRepository_Create_ReturnsTrue()
        {
            var toDo = new ToDo
            {
                Title = "Learn geometrics",
                Description = "Learning by listening to podcasts",
                CompletePercent = 20,
                Expiration = DateTime.Now.AddDays(1)
            };
            var dbContext = await GetDatabaseContext();
            var repos = new ToDoRepository(dbContext);

            var result = repos.Create(toDo);

            result.Should().BeTrue();
        }
        [Fact]
        public async void ToDoRepository_Update_ReturnsTrue()
        {
            
            var toDo = new ToDo
            {
                Id = 2,
                Title = "Learn geometrics",
                Description = "Learning by listening to podcasts",
                CompletePercent = 20,
                Expiration = DateTime.Now.AddDays(1)
            };
            var dbContext = await GetDatabaseContext();
            var repos = new ToDoRepository(dbContext);

            var result = repos.Update(toDo);

            result.Should().BeTrue();

        }
        [Fact]
        public async void ToDoRepository_SetPercent_ReturnsTrue()
        {
            int id = 1;
            int percent = 25;
            var dbContext = await GetDatabaseContext();
            var repos = new ToDoRepository(dbContext);

            var result = repos.SetPercent(id, percent);

            result.Should().BeTrue();
        }
        [Fact]
        public async void ToDoRepository_Delete_ReturnsTrue()
        {
            int id = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new ToDoRepository(dbContext);

            var result = repos.Delete(id);

            result.Should().BeTrue();
        }
        [Fact]
        public async void ToDoRepository_Complete_ReturnsTrue()
        {
            int id = 1;
            var dbContext = await GetDatabaseContext();
            var repos = new ToDoRepository(dbContext);

            var result = repos.Complete(id); 
            
            result.Should().BeTrue();

        }
    }
}
