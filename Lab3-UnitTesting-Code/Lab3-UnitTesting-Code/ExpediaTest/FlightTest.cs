using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        [Test()]
        public void TestThatFlightInitializes()
        {
            DateTime startDate = new DateTime(2012, 3, 4);
            DateTime endDate = new DateTime(2012, 3, 7);
            var target = new Flight(startDate, endDate, 5); 
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightStoresMiles()
        {
            DateTime startDate = new DateTime(2012, 3, 4);
            DateTime endDate = new DateTime(2012, 3, 7);
            var target = new Flight(startDate, endDate, 5);
            Assert.AreEqual(5, target.Miles);
        }

        [Test()]
        public void TestThatFlightBookingPriceCorrectZeroDayDifference()
        {
            DateTime startDate = new DateTime(2012, 3, 4);
            DateTime endDate = new DateTime(2012, 3, 4);
            var target = new Flight(startDate, endDate, 5);
            Assert.AreEqual(200, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightBookingPriceCorrectOneDayDifference()
        {
            DateTime startDate = new DateTime(2012, 3, 4);
            DateTime endDate = new DateTime(2012, 3, 5);
            var target = new Flight(startDate, endDate, 5);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightBookingPriceCorrectTwoDayDifference()
        {
            DateTime startDate = new DateTime(2012, 3, 4);
            DateTime endDate = new DateTime(2012, 3, 6);
            var target = new Flight(startDate, endDate, 5);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightBookingPriceCorrectTenDayDifference()
        {
            DateTime startDate = new DateTime(2012, 3, 4);
            DateTime endDate = new DateTime(2012, 3, 14);
            var target = new Flight(startDate, endDate, 5);
            Assert.AreEqual(400, target.getBasePrice());
        }



        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsBadDates()
        {
            DateTime startDate = new DateTime(2012,3,4);
            DateTime endDate = new DateTime(2012,3,1);
            new Flight(startDate, endDate, 5);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            DateTime startDate = new DateTime(2012, 3, 4);
            DateTime endDate = new DateTime(2012, 3, 7);
            new Flight(startDate, endDate, -5);
        }
	}
}
