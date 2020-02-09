using Booking.Application;
using Booking.CrossCutting;
using Booking.Infrastructure;
using Booking.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Booking.Tests
{
    [TestClass]
    public class HotelServiceTest
    {
        private readonly IHotelService _hotelService;

        public HotelServiceTest()
        {
            var services = new ServiceCollection();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelService, HotelService>();
            _hotelService = services.BuildServiceProvider().GetRequiredService<IHotelService>();
        }

        [TestMethod]
        public void HotelService_GetCheaperAsync_JardimBotanico()
        {
            var query = HotelQuery.Create
            (
                TaxType.Regular,
                new DateTime(2020, 3, 20),
                new DateTime(2020, 3, 21),
                new DateTime(2020, 3, 22)
            );

            var hotel = _hotelService.GetCheaperAsync(query).Result;

            Assert.AreEqual("Jardim Botânico", hotel.Name);
        }

        [TestMethod]
        public void HotelService_GetCheaperAsync_MarAtlantico()
        {
            var query = HotelQuery.Create
            (
                TaxType.Loyalty,
                new DateTime(2020, 3, 26),
                new DateTime(2020, 3, 27),
                new DateTime(2020, 3, 28)
            );

            var hotel = _hotelService.GetCheaperAsync(query).Result;

            Assert.AreEqual("Mar Atlântico", hotel.Name);
        }

        [TestMethod]
        public void HotelService_GetCheaperAsync_ParqueDasFlores()
        {
            var query = HotelQuery.Create
            (
                TaxType.Regular,
                new DateTime(2020, 3, 16),
                new DateTime(2020, 3, 17),
                new DateTime(2020, 3, 18)
            );

            var hotel = _hotelService.GetCheaperAsync(query).Result;

            Assert.AreEqual("Parque das Flores", hotel.Name);
        }
    }
}
