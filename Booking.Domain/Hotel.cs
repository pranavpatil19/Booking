using Booking.CrossCutting;
using System.Collections.Generic;

namespace Booking.Domain
{
    public class Hotel
    {
        public Hotel
        (
            string name,
            Rating rating,
            IReadOnlyList<Tax> taxes
        )
        {
            Name = name;
            Rating = rating;
            Taxes = taxes;
        }

        public string Name { get; private set; }

        public Rating Rating { get; private set; }

        public IReadOnlyList<Tax> Taxes { get; private set; }
    }
}