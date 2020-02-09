using Booking.CrossCutting;
using Booking.Domain;
using Booking.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Infrastructure
{
    public sealed class HotelRepository : IHotelRepository
    {
        public Task<Hotel> GetCheaperAsync(HotelQuery query)
        {
            var hotel =
                 Queryable()
                .SelectMany(x => x.Taxes, (hotel, tax) => new { hotel, tax })
                .Where(x => x.tax.TaxType == query.TaxType && query.Dates.Any(date => date.DayType() == x.tax.DayType))
                .OrderBy(x => x.tax.Value)
                .ThenByDescending(x => x.hotel.Rating)
                .Select(x => x.hotel)
                .FirstOrDefault();

            return Task.FromResult(hotel);
        }

        private static IQueryable<Hotel> Queryable()
        {
            return new List<Hotel>
            {
                new Hotel("Parque das Flores", Rating.Three, new List<Tax>
                {
                    new Tax(TaxType.Regular, DayType.Week, 110),
                    new Tax(TaxType.Regular, DayType.Weekend, 90),
                    new Tax(TaxType.Loyalty, DayType.Week, 80),
                    new Tax(TaxType.Loyalty, DayType.Weekend, 80)
                }),
                new Hotel("Jardim Botânico", Rating.Four, new List<Tax>
                {
                    new Tax(TaxType.Regular, DayType.Week, 160),
                    new Tax(TaxType.Regular, DayType.Weekend, 60),
                    new Tax(TaxType.Loyalty, DayType.Week, 110),
                    new Tax(TaxType.Loyalty, DayType.Weekend, 50)
                }),
                new Hotel("Mar Atlântico", Rating.Five, new List<Tax>
                {
                    new Tax(TaxType.Regular, DayType.Week, 220),
                    new Tax(TaxType.Regular, DayType.Weekend, 150),
                    new Tax(TaxType.Loyalty, DayType.Week, 100),
                    new Tax(TaxType.Loyalty, DayType.Weekend, 40)
                })
            }.AsQueryable();
        }
    }
}
