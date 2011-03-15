using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
		//TODO Task 7 items go here
		private readonly DateTime startDate = new DateTime(2011, 1, 1);
        private readonly DateTime endDate = new DateTime(2011,1,8);
        private readonly int flightMiles = 100;

		[Test()]
		public void TestThatFlightInitializes()
		{
            var target = new Flight(startDate, endDate, flightMiles);
			Assert.IsNotNull(target);
		}

		[Test()]
		public void TestThatFlightHasCorrectBasePriceForOneDayFlight()
		{
            var target = new Flight(startDate, new DateTime(2011,1,2), flightMiles);
			Assert.AreEqual(220, target.getBasePrice());
		}

		[Test()]
		public void TestThatFlightHasCorrectBasePriceForTwoDayFlight()
		{
            var target = new Flight(startDate, new DateTime(2011,1,3), flightMiles);
			Assert.AreEqual(240, target.getBasePrice());
		}

		[Test()]
		public void TestThatFlightHasCorrectBasePriceForSevenDaysFlight()
		{
            var target = new Flight(startDate, new DateTime(2011,1,8), flightMiles);
			Assert.AreEqual(340, target.getBasePrice());
		}

        [Test()]
        public void TestThatFlightGetsCorrectMilesFromFlight()
        {
            var target = new Flight(startDate, endDate, flightMiles);
            Assert.AreEqual(flightMiles, target.Miles);
        }

		[Test()]
        [ExpectedException(typeof(InvalidOperationException))]
		public void TestThatFlightThrowsOnStartDateAfterEndDates()
		{
			new Flight(endDate,startDate,flightMiles);
		}

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(startDate, endDate, -100);
        }
	}
}
