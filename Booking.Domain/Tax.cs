using Booking.CrossCutting;

namespace Booking.Domain
{
    public class Tax
    {
        public Tax
        (
            TaxType taxType,
            DayType dayType,
            decimal value
        )
        {
            TaxType = taxType;
            DayType = dayType;
            Value = value;
        }

        public TaxType TaxType { get; private set; }

        public DayType DayType { get; private set; }

        public decimal Value { get; private set; }
    }
}
