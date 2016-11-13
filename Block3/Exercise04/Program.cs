using System;
using System.Globalization;

namespace Exercise04
{
    public class Program
    {
        public static DateTime[][] holidays = new DateTime[12][]
        {
            new DateTime[] {new DateTime(DateTime.Now.Year, 1, 1), new DateTime(DateTime.Now.Year, 1, 6)},
            new DateTime[] {},
            new DateTime[] {new DateTime(DateTime.Now.Year, 3, 27), new DateTime(DateTime.Now.Year, 3, 28)},
            new DateTime[] {new DateTime(DateTime.Now.Year, 4, 25), new DateTime(DateTime.Now.Year, 4, 28)},
            new DateTime[] {new DateTime(DateTime.Now.Year, 5, 1), new DateTime(DateTime.Now.Year, 1, 16)},
            new DateTime[] {new DateTime(DateTime.Now.Year, 6, 2)},
            new DateTime[] {},
            new DateTime[] {new DateTime(DateTime.Now.Year, 8, 15)},
            new DateTime[] {},
            new DateTime[] {},
            new DateTime[] {new DateTime(DateTime.Now.Year, 11, 1)},
            new DateTime[] {new DateTime(DateTime.Now.Year, 12, 8), new DateTime(DateTime.Now.Year, 12, 25), new DateTime(DateTime.Now.Year, 12, 26)},
        };

        static void Main(string[] args)
        {
            string datePattern = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            DateTime date;
            DateTime today = DateTime.Now;
            string dateStr;

            Console.WriteLine("This program counts the working days starting from today: {0:dd/MM/yyyy}", today);

            Console.Write("Please, enter a future date in the format " + datePattern + ": ");

            dateStr = Console.ReadLine();
            while (!DateTime.TryParse(dateStr, out date))
            {
                Console.WriteLine("Input date has not a valid format.\n");
                Console.Write("Please, enter a future date in the format " + datePattern + ": ");
                dateStr = Console.ReadLine();
            }

            try
            {
                Console.WriteLine("There are {0} working days.", CountWorkingDays(today, date));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static bool IsWorkingDay(DateTime date)
        {
            DayOfWeek day = date.DayOfWeek;
            if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            {
                return false;
            }

            int month = date.Month;
            foreach (DateTime hol in holidays[month - 1])
            {
                if (hol.Day == date.Day)
                {
                    return false;
                }
            }

            return true;
        }

        //count workdays from the current date to a given date
        public static int CountWorkingDays(DateTime start, DateTime end)
        {
            int count = 0;

            if (end.CompareTo(start) <= 0)
            {
                throw new ArgumentException("End date could not be before the start date.");
            }

            for (DateTime day = start; day.Date.CompareTo(end.Date) <= 0; day = day.AddDays(1))
            {
                if (IsWorkingDay(day))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
