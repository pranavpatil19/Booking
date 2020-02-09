using Booking.Domain;
using Booking.Model;
using System.Threading.Tasks;

namespace Booking.Infrastructure
{
    public interface IHotelRepository
    {
        Task<Hotel> GetCheaperAsync(HotelQuery query);
    }
}
