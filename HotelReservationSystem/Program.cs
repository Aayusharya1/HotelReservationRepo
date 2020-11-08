using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HotelReservation hotelReservation = new HotelReservation();
            hotelReservation.InsertHotelDetailsByConsole();
            
        }
    }
}
