using Booking.Domain;
using Booking.Model;
using System.Threading.Tasks;

namespace Booking.Application
{
    public interface IHotelService
    {
        Task<Hotel> GetCheaperAsync(HotelQuery query);
    }
}
