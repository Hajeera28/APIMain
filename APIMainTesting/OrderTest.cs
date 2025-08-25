using APIMainProject.Models;
using APIMainProject.Services;
using APIMainProject.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesting
{
    internal class OrderTest
    {
        private Mock<IOrder> mockRepo;
        private OrderService orderService;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IOrder>();
            orderService = new OrderService(mockRepo.Object);
        }

        [Test]
        public async Task GetOrdersAsync_ReturnsAllOrders()
        {
            var orders = new List<Order>
            {
                new Order { OrderId = 1, OrderDate = DateTime.Today, OrderTime = DateTime.Now, Status = OrderStatus.Pending, HotelId = 1, UserId = 1 },
                new Order { OrderId = 2, OrderDate = DateTime.Today, OrderTime = DateTime.Now, Status = OrderStatus.Completed, HotelId = 2, UserId = 2 }
            };
            mockRepo.Setup(r => r.GetAllOrders()).ReturnsAsync(orders);

            var result = await orderService.GetAllOrdersAsync();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(OrderStatus.Pending, result.First().Status);
        }

        [Test]
        public async Task GetOrderByIdAsync_ReturnsOrder()
        {
            var order = new Order { OrderId = 1, OrderDate = DateTime.Today, OrderTime = DateTime.Now, Status = OrderStatus.Pending, HotelId = 1, UserId = 1 };
            mockRepo.Setup(r => r.GetOrderById(1)).ReturnsAsync(order);

            var result = await orderService.GetOrderByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(OrderStatus.Pending, result.Status);
        }

        [Test]
        public async Task AddOrderAsync_AddsOrder()
        {
            var order = new Order { OrderId = 3, OrderDate = DateTime.Today, OrderTime = DateTime.Now, Status = OrderStatus.Pending, HotelId = 3, UserId = 3 };
            mockRepo.Setup(r => r.AddOrders(order)).ReturnsAsync(order);

            var result = await orderService.AddOrdersAsync(order);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.OrderId);
        }

        [Test]
        public async Task UpdateOrderAsync_UpdatesOrder()
        {
            var order = new Order { OrderId = 1, OrderDate = DateTime.Today, OrderTime = DateTime.Now, Status = OrderStatus.Completed, HotelId = 1, UserId = 1 };
            mockRepo.Setup(r => r.UpdateOrders(1, order)).ReturnsAsync(order);

            var result = await orderService.UpdateOrdersAsync(1, order);

            Assert.IsNotNull(result);
            Assert.AreEqual(OrderStatus.Completed, result.Status);
        }

        [Test]
        public async Task DeleteOrderAsync_DeletesOrder()
        {
            var order = new Order { OrderId = 1, OrderDate = DateTime.Today, OrderTime = DateTime.Now, Status = OrderStatus.Pending, HotelId = 1, UserId = 1 };
            mockRepo.Setup(r => r.DeleteOrders(1)).ReturnsAsync(order);

            var result = await orderService.DeleteOrdersAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.OrderId);
        }
    }
}
