using System;

namespace Booking.CrossCutting
{
    public static class DateTimeExtensions
    {
        public static DayType DayType(this DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return CrossCutting.DayType.Weekend;
            }

            return CrossCutting.DayType.Week;
        }
    }
}
