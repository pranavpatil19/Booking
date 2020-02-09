using Booking.Domain;
using Booking.Infrastructure;
using Booking.Model;
using System.Threading.Tasks;

namespace Booking.Application
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public Task<Hotel> GetCheaperAsync(HotelQuery query)
        {
            if (query == default) { return default; }

            return _hotelRepository.GetCheaperAsync(query);
        }
    }
}
