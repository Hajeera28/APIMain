using APIMainProject.Interface;
using APIMainProject.Models;
using APIMainProject.Services;
using APIMainProject.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesting
{
    internal class OrderDetailsTest
    {
        private Mock<IOrderDetail> mockRepo;
        private OrderDetailService orderDetailsService;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IOrderDetail>();
            orderDetailsService = new OrderDetailService(mockRepo.Object);
        }

        [Test]
        public async Task GetOrderDetailsAsync_ReturnsAllOrderDetails()
        {
            var orderDetails = new List<OrderDetail>
            {
                new OrderDetail { OrderDetailId = 1, OrderId = 1, ItemName = "Pizza" },
                new OrderDetail { OrderDetailId = 2, OrderId = 1, ItemName = "Burger" }
            };
            mockRepo.Setup(r => r.GetAllOrderDetails()).ReturnsAsync(orderDetails);

            var result = await orderDetailsService.GetAllOrderDetailsAsync();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Pizza", result.First().ItemName);
        }

        [Test]
        public async Task GetOrderDetailsByIdAsync_ReturnsOrderDetail()
        {
            var orderDetail = new OrderDetail { OrderDetailId = 1, OrderId = 1, ItemName = "Pizza" };
            mockRepo.Setup(r => r.GetOrderDetailById(1)).ReturnsAsync(orderDetail);

            var result = await orderDetailsService.GetOrderDetailByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Pizza", result.ItemName);
        }

        [Test]
        public async Task AddOrderDetailsAsync_AddsOrderDetails()
        {
            var orderDetail = new OrderDetail { OrderDetailId = 3, OrderId = 2, ItemName = "Pasta" };
            mockRepo.Setup(r => r.AddOrderDetails(orderDetail)).ReturnsAsync(orderDetail);

            var result = await orderDetailsService.AddOrderDetailsAsync(orderDetail);

            Assert.IsNotNull(result);
            Assert.AreEqual("Pasta", result.ItemName);
        }

        [Test]
        public async Task UpdateOrderDetailsAsync_UpdatesOrderDetails()
        {
            var orderDetail = new OrderDetail { OrderDetailId = 1, OrderId = 1, ItemName = "Pizza Updated" };
            mockRepo.Setup(r => r.UpdateOrderDetails(1, orderDetail)).ReturnsAsync(orderDetail);

            var result = await orderDetailsService.UpdateOrderDetailsAsync(1, orderDetail);

            Assert.IsNotNull(result);
            Assert.AreEqual("Pizza Updated", result.ItemName);
        }

        [Test]
        public async Task DeleteOrderDetailsAsync_DeletesOrderDetails()
        {
            var orderDetail = new OrderDetail { OrderDetailId = 1, OrderId = 1, ItemName = "Pizza" };
            mockRepo.Setup(r => r.DeleteOrderDetails(1)).ReturnsAsync(orderDetail);

            var result = await orderDetailsService.DeleteOrderDetailsAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Pizza", result.ItemName);
        }
    }
}
