﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelReservation
    {
        public Dictionary<string, Hotel> hotels;
        public enum CustomerType { Regular, Reward };

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

        public List<Hotel> FindCheapestHotels(DateTime startDate, DateTime endDate, CustomerType customerType = 0)
        {
            if (startDate > endDate)
            {
                throw new HotelReservationException(ExceptionType.INVALID_DATES, "Dates Entered are Invalid");
            }
            var cost = Int32.MaxValue;
            var cheapestHotels = new List<Hotel>();
            foreach (var hotel in hotels)
            {
                var temp = cost;
                cost = Math.Min(cost, CalculateTotalCost(hotel.Value, startDate, endDate, customerType));

            }
            foreach (var hotel in hotels)
            {
                if (CalculateTotalCost(hotel.Value, startDate, endDate, customerType) == cost)
                    cheapestHotels.Add(hotel.Value);
            }
            return cheapestHotels;
        }

        public List<Hotel> FindCheapestBestRatedHotel(DateTime startDate, DateTime endDate, CustomerType customerType = 0)
        {
            var cheapestHotels = FindCheapestHotels(startDate, endDate, customerType);
            var cheapestBestRatedHotels = new List<Hotel>();
            var maxRating = 0;
            foreach (var hotel in cheapestHotels)
                maxRating = Math.Max(maxRating, hotel.rating);
            foreach (var hotel in cheapestHotels)
                if (hotel.rating == maxRating)
                    cheapestBestRatedHotels.Add(hotel);
            return cheapestBestRatedHotels;

        }
        public List<Hotel> FindBestRatedHotel(DateTime startDate, DateTime endDate)
        {
            var cheapestBestRatedHotels = new List<Hotel>();
            var maxRating = 0;
            foreach (var hotel in hotels)
                maxRating = Math.Max(maxRating, hotel.Value.rating);
            foreach (var hotel in hotels)
                if (hotel.Value.rating == maxRating)
                    cheapestBestRatedHotels.Add(hotel.Value);
            return cheapestBestRatedHotels;

        }


        public int CalculateTotalCost(Hotel hotel, DateTime startDate, DateTime endDate, CustomerType customerType = 0)
        {
            var cost = 0;
            var weekdayRate = customerType == CustomerType.Regular ? hotel.weekdayRegularRates : hotel.weekdayLoyaltyRates;
            var weekendRate = customerType == CustomerType.Regular ? hotel.weekendRegularRates : hotel.weekendLoyaltyRates;
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    cost += weekendRate;
                else
                    cost += weekdayRate;
            }
            return cost;
        }

        public static CustomerType GetCustomerType(string customerType)
        {
            if (customerType != "regular" && customerType != "reward")
                throw new HotelReservationException(ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type Entered");
            return customerType == "regular" ? CustomerType.Regular : CustomerType.Reward;
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

            Console.Write("Enter Loyalty Weekday Rate : ");
            hotel.weekdayLoyaltyRates = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Loyalty Weekend Rate : ");
            hotel.weekendLoyaltyRates = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Rating : ");
            hotel.rating = Convert.ToInt32(Console.ReadLine());

            AddHotel(hotel);
        }
    }
}
