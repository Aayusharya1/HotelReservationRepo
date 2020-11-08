using HotelReservationSystem;
using NUnit.Framework;
using System;

namespace HotelReservationTests
{
    public class Tests
    {
        private HotelReservation hotelReservation;

        [SetUp]
        public void SetUP()
        {
            hotelReservation = new HotelReservation();
            hotelReservation.AddHotel(new Hotel { name = "Lakewood", weekdayRegularRates = 110, weekendRegularRates = 90, weekdayLoyaltyRates = 80, weekendLoyaltyRates = 80, rating = 3 });
            hotelReservation.AddHotel(new Hotel { name = "Bridgewood", weekdayRegularRates = 160, weekendRegularRates = 60, weekdayLoyaltyRates = 110, weekendLoyaltyRates = 50, rating = 4 });
            hotelReservation.AddHotel(new Hotel { name = "Ridgewood", weekdayRegularRates = 220, weekendRegularRates = 150, weekdayLoyaltyRates = 100, weekendLoyaltyRates = 40, rating = 5 });
        }
        [Test]
        public void AddHotel_WhenPassedNewHotel_AddsHotelToSystem()
        {
            var hotel = new Hotel { name = "MyHotel", weekdayRegularRates = 10, weekendRegularRates = 20 };

            var prevCount = hotelReservation.hotels.Count;
            hotelReservation.AddHotel(hotel);

            Assert.That(hotelReservation.hotels.Count, Is.EqualTo(prevCount + 1));
            Assert.That(hotelReservation.hotels.ContainsKey(hotel.name), Is.True);

        }

        [Test]
        public void FindCheapestHotels_WhenGivenValidDateRange_ReturnsCheapestHotel()
        {
            var startDate = Convert.ToDateTime("10Sep2020");
            var endDate = Convert.ToDateTime("11Sep2020");

            var expected = hotelReservation.hotels["Lakewood"];
            var result = hotelReservation.FindCheapestHotel(startDate, endDate);

            Assert.That(result, Does.Contain(expected));
        }

        [Test]
        public void FindCheapestBestRatedHotels_WhenGivenValidDateRange_ReturnsCheapestHotelWithHighestRating()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("13Sep2020");

            var expected = hotelReservation.hotels["Bridgewood"];
            var result = hotelReservation.FindCheapestBestRatedHotel(startDate, endDate);

            Assert.That(result, Does.Contain(expected));
        }

        [Test]
        public void FindCheapestBestRatedHotels_WhenGivenValidDateRangeForLoyalty_ReturnsCheapestHotelWithHighestRating()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("12Sep2020");

            var expected = hotelReservation.hotels["Ridgewood"];
            var result = hotelReservation.FindCheapestBestRatedHotel(startDate, endDate, CustomerType.Reward);

            Assert.That(result, Does.Contain(expected));
        }
        [Test]
        public void FindBestRatedHotels_WhenGivenValidDateRange_ReturnsBestRatedHotel()
        {
            var startDate = Convert.ToDateTime("11Sep2020");
            var endDate = Convert.ToDateTime("13Sep2020");

            var expected = hotelReservation.hotels["Ridgewood"];
            var result = hotelReservation.FindBestRatedHotel(startDate, endDate);

            Assert.That(result, Does.Contain(expected));
        }

    }
}