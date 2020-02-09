using Booking.CrossCutting;
using System;

namespace Booking.Model
{
    public sealed class HotelQuery
    {
        private HotelQuery() { }

        public TaxType TaxType { get; private set; }

        public DateTime[] Dates { get; private set; }

        public static HotelQuery Create(TaxType taxType, params DateTime[] dates)
        {
            return new HotelQuery { TaxType = taxType, Dates = dates };
        }
    }
}
