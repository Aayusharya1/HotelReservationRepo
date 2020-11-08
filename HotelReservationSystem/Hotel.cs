using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        public string name { get; set; }
        public int weekdayRegularRates { get; set; }

        public int weekendRegularRates { get; set; }

        public int rating { get; set; }

        public int weekdayLoyaltyRates { get; set; }
        public int weekendLoyaltyRates { get; set; }
    }
}
