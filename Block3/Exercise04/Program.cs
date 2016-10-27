using System;


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
    }
}
