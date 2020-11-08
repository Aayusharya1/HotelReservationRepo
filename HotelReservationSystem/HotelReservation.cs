using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    class HotelReservation
    {
        public Dictionary<string, Hotel> hotels;

        public HotelReservation() 
        {
            hotels = new Dictionary<string, Hotel>();
        }
        public void AddHotel(Hotel hotel)
        {
            if (hotels.ContainsKey(hotel.name))
            {
                Console.WriteLine("Hotel Already Exists");
                return;
            }
            hotels.Add(hotel.name, hotel);
        }

        public void InsertHotelDetailsByConsole()
        {
            var hotel = new Hotel();
            Console.Write("Enter Hotel Name : ");
            hotel.name = Console.ReadLine();

            Console.Write("Enter Regular Weekday Rate : ");
            hotel.weekdayRegularRates = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Regular Weekend Rate : ");
            hotel.weekendRegularRates = Convert.ToInt32(Console.ReadLine());

            AddHotel(hotel);
        }
    }
}
