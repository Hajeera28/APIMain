using APIMainProject.Models;
using APIMainProject.Services;
using APIMainProject.Repository;
using APIMainProject.Interface;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesting
{
    internal class HotelTest
    {
        private Mock<IHotel> mockRepo;
        private HotelService hotelService;

        [SetUp]
        public void Setup()
        {
            mockRepo = new Mock<IHotel>();
            hotelService = new HotelService(mockRepo.Object);
        }

        [Test]
        public async Task GetHotelsAsync_ReturnsAllHotels()
        {
            var hotels = new List<Hotel>
            {
                new Hotel { HotelId = 1, HotelName = "Hotel A", Location = "Chennai" },
                new Hotel { HotelId = 2, HotelName = "Hotel B", Location = "Bangalore" }
            };
            mockRepo.Setup(r => r.GetAllHotels()).ReturnsAsync(hotels);

            var result = await hotelService.GetAllHotelsAsync();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Hotel A", result.First().HotelName);
        }

        [Test]
        public async Task GetHotelByIdAsync_ReturnsHotel()
        {
            var hotel = new Hotel { HotelId = 1, HotelName = "Hotel A", Location = "Chennai" };
            mockRepo.Setup(r => r.GetHotelById(1)).ReturnsAsync(hotel);

            var result = await hotelService.GetHotelByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Hotel A", result.HotelName);
        }

        [Test]
        public async Task AddHotelAsync_AddsHotel()
        {
            var hotel = new Hotel { HotelId = 3, HotelName = "Hotel C", Location = "Hyderabad" };
            mockRepo.Setup(r => r.AddHotels(hotel)).ReturnsAsync(hotel);

            var result = await hotelService.AddHotelsAsync(hotel);

            Assert.IsNotNull(result);
            Assert.AreEqual("Hotel C", result.HotelName);
        }

        [Test]
        public async Task UpdateHotelAsync_UpdatesHotel()
        {
            var hotel = new Hotel { HotelId = 1, HotelName = "Hotel A Updated", Location = "Chennai" };
            mockRepo.Setup(r => r.UpdateHotels(1, hotel)).ReturnsAsync(hotel);

            var result = await hotelService.UpdateHotelsAsync(1, hotel);

            Assert.IsNotNull(result);
            Assert.AreEqual("Hotel A Updated", result.HotelName);
        }

        [Test]
        public async Task DeleteHotelAsync_DeletesHotel()
        {
            var hotel = new Hotel { HotelId = 1, HotelName = "Hotel A", Location = "Chennai" };
            mockRepo.Setup(r => r.DeleteHotels(1)).ReturnsAsync(hotel);

            var result = await hotelService.DeleteHotelsAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Hotel A", result.HotelName);
        }
    }
}
