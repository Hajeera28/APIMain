using APIMainProject.Models;
using APIMainProject.Services;
using APIMainProject.Interface;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesting
{
    internal class UserTest
    {
        private Mock<IUser> mockRepo;
        private UserService userService;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IUser>();
            userService = new UserService(mockRepo.Object);
        }

        [Test]
        public async Task GetUsersAsync_ReturnsAllUsers()
        {
            var users = new List<User>
            {
                new User { UserId = 1, UserName = "Hajeera", Email = "hajeera@example.com" },
                new User { UserId = 2, UserName = "Rahul", Email = "rahul@example.com" }
            };
            mockRepo.Setup(r => r.GetAllUsers()).ReturnsAsync(users);

            var result = await userService.GetAllUsersAsync();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Hajeera", result.First().UserName);
        }

        [Test]
        public async Task GetUserByIdAsync_ReturnsUser()
        {
            var user = new User { UserId = 1, UserName = "Hajeera", Email = "hajeera@example.com" };
            mockRepo.Setup(r => r.GetUserById(1)).ReturnsAsync(user);

            var result = await userService.GetUserByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Hajeera", result.UserName);
        }

        [Test]
        public async Task AddUserAsync_AddsUser()
        {
            var user = new User { UserId = 3, UserName = "Priya", Email = "priya@example.com" };
            mockRepo.Setup(r => r.AddUsers(user)).ReturnsAsync(user);

            var result = await userService.AddUsersAsync(user);

            Assert.IsNotNull(result);
            Assert.AreEqual("Priya", result.UserName);
        }

        [Test]
        public async Task UpdateUserAsync_UpdatesUser()
        {
            var user = new User { UserId = 1, UserName = "Hajeera Updated", Email = "hajeera@example.com" };
            mockRepo.Setup(r => r.UpdateUsers(1, user)).ReturnsAsync(user);

            var result = await userService.UpdateUsersAsync(1, user);

            Assert.IsNotNull(result);
            Assert.AreEqual("Hajeera Updated", result.UserName);
        }

        [Test]
        public async Task DeleteUserAsync_DeletesUser()
        {
            var user = new User { UserId = 1, UserName = "Hajeera", Email = "hajeera@example.com" };
            mockRepo.Setup(r => r.DeleteUsers(1)).ReturnsAsync(user);

            var result = await userService.DeleteUsersAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Hajeera", result.UserName);
        }
    }
}
