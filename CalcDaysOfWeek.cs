using System;
using System.Collections.Generic;
using System.Linq;

class FourHundredYearCalendar
{
    // Calculates the day of the week for a given date using Zeller's Congruence
public static int CalculateDayOfWeek(int day, int month, int year)
{
    if (month < 3)
    {
        month += 12;
        year--;
    }

    int k = year % 100;     // Year within the century
    int j = year / 100;     // Zero-based century

    // Zeller’s formula to compute day of week (0=Saturday, ..., 6=Friday)
    int h = (day + (13 * (month + 1)) / 5 + k + (k / 4) + (j / 4) + (5 * j)) % 7;

    // Convert to (0 = Sunday, ..., 6 = Saturday)
    int dayOfWeek = (h + 6) % 7;
    return dayOfWeek;
}

// Main entry point: generates calendar for years 1900 to 2300
static void Main()
{
    for (int year = 1900; year <= 2300; year++) // Loop through each year
    {
        string yearTitle = $"============================== YEAR {year} ==============================";

        // Center-align the year heading
        Console.WriteLine($"\n{yearTitle.PadLeft((88 + yearTitle.Length) / 2)}\n");

        for (int group = 0; group < 12; group += 4) // Group months into sets of 4 per line
        {
            List<List<string>> allMonthLines = new List<List<string>>();

            // Get line-by-line calendar data for 4 months
            for (int m = 0; m < 4; m++)
            {
                int month = group + m + 1;
                allMonthLines.Add(GetMonthLines(month, year));
            }

            // Find the maximum number of lines among the 4 months
            int maxLines = allMonthLines.Max(m => m.Count);

            // Print each line across the 4 months, with spacing
            for (int line = 0; line < maxLines; line++)
            {
                for (int m = 0; m < 4; m++)
                {
                    if (line < allMonthLines[m].Count)
                        Console.Write(allMonthLines[m][line].PadRight(26)); // Print with padding
                    else
                        Console.Write(new string(' ', 26)); // Empty space if no content
                }
                Console.WriteLine();
            }

            Console.WriteLine(); // Extra line between groups of 4 months
        }
    }
}
}
  