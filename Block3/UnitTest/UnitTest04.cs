using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise04;

namespace UnitTest
{
    [TestClass]
    public class UnitTest04
    {
        [TestMethod]
        public void IsWorkingDayTest_PublicHolidays()
        {
            foreach (DateTime[] months in Program.holidays)
            {
                foreach (DateTime day in months)
                {
                    Assert.IsFalse(Program.IsWorkingDay(day));
                }
            }
        }

        [TestMethod]
        public void IsWorkingDayTest_WeekEnd()
        {
            string date = "Sunday, October 30, 2016";
            DateTime sunday = DateTime.Parse(date);

            date = "Saturday, October 29, 2016";
            DateTime saturday = DateTime.Parse(date);

            Assert.IsFalse(Program.IsWorkingDay(sunday));
            Assert.IsFalse(Program.IsWorkingDay(saturday));
        }

        [TestMethod]
        public void IsWorkingDayTest()
        {
            string dateString = "Monday, October 31, 2016";
            DateTime date = DateTime.Parse(dateString);

            Assert.IsTrue(Program.IsWorkingDay(date));
        }

        [TestMethod]
        public void CountWorkingDaysTest_Week()
        {
            DateTime start = new DateTime(2016, 10, 24);
            DateTime end = start.AddDays(6);

            int workdays = Program.CountWorkingDays(start, end);

            Assert.AreEqual(5, workdays);
        }
    }
}
