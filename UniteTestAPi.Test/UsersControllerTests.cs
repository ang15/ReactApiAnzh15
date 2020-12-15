using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApAnzh.Controllers;
using WebApAnzh.Models;
using Xunit;

namespace UnitTestApi.Tests
{
    public class UsersControllerTests
    {
        UsersController _controller;
        UsersContext db;

        public   UsersControllerTests()
        {
            var options = new DbContextOptionsBuilder<UsersContext>()
                .UseInMemoryDatabase(databaseName: "usersdbstore").Options;

            // Set up a context (connection to the "DB") for writing
            using (var context = new UsersContext(options))
            {
                db = context;
                    db.Users.Add(new User { Name = "Tom", Age = 26 });
                    db.Users.Add(new User { Name = "Alice", Age = 31 });
                    db.SaveChanges();
                _controller = new UsersController(db);
            }

        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<BadRequestResult>(okResult.Result);

        }

        [Fact]
        public void Get_IdPassed_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            User testUser = new User()
            {
                Name = "ang",
                Age = 5
            };

            // Act
            var createdResponse = _controller.Post(testUser);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Remove_IdPassed_ReturnsOkResult()
        {
            // Arrange
            int testId = 1;

            // Act
            var okResponse = _controller.Delete(testId);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
    }
}