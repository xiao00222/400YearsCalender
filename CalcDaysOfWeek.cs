using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    // Zeller's Congruence to calculate day of week
    public static int CalculateDayOfWeek(int day, int month, int year)
    {
        if (month < 3)
        {
            month += 12;
            year--;
        }

        int k = year % 100;
        int j = year / 100;

        int h = (day + (13 * (month + 1)) / 5 + k + (k / 4) + (j / 4) + (5 * j)) % 7;
        return (h + 6) % 7;
    }

    // Main entry point to display the 400 years calendar
    public static void Main()
    {
        for (int year = 1900; year <= 2300; year++)
        {
            string yearTitle = $"============================== YEAR {year} ==============================";
            Console.WriteLine($"\n{yearTitle.PadLeft((88 + yearTitle.Length) / 2)}\n");

            for (int group = 0; group < 12; group += 4)
            {
                List<List<string>> allMonthLines = new List<List<string>>();

                for (int m = 0; m < 4; m++)
                {
                    int month = group + m + 1;
                    allMonthLines.Add(CalendarUtils.GetMonthLines(month, year));
                }

                int maxLines = allMonthLines.Max(m => m.Count);

                for (int line = 0; line < maxLines; line++)
                {
                    for (int m = 0; m < 4; m++)
                    {
                        if (line < allMonthLines[m].Count)
                            Console.Write(allMonthLines[m][line].PadRight(26));
                        else
                            Console.Write(new string(' ', 26));
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }
}
