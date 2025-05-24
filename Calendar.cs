using System;
using System.Globalization;

class Calendar400Years
{
    static void Main()
    {
        int startYear = 2000;
        int totalYears = 400;

        for (int year = startYear; year < startYear + totalYears; year++)
        {
            Console.WriteLine("\n\n===================== YEAR: " + year + " =====================\n");

            for (int month = 1; month <= 12; month++)
            {
                PrintMonth(year, month);
            }
        }

        Console.WriteLine("\n\n400-Year Calendar Finished!");
    }

    static void PrintMonth(int year, int month)
    {
        string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        Console.WriteLine("\n---------- " + monthName + " " + year + " ----------");
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        DateTime firstDay = new DateTime(year, month, 1);
        int daysInMonth = DateTime.DaysInMonth(year, month);
        int currentDay = 1;

        // Indent for the first line
        int startDay = (int)firstDay.DayOfWeek;
        for (int i = 0; i < startDay; i++)
        {
            Console.Write("    ");
        }

        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write(day.ToString().PadLeft(3) + " ");

            if ((startDay + day) % 7 == 0)
                Console.WriteLine(); // New line at the end of the week
        }

        Console.WriteLine();
    }
}
