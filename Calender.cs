using System;
using System.Collections.Generic;
using System.Linq;

class FourHundredYearCalendar
{
    // Determines whether a given year is a leap year
    static bool IsLeapYear(int year) =>
        (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);

    // Returns the number of days in a specific month of a given year
    public static int GetDaysInMonth(int month, int year)
    {
        if (month == 1) return 31;
        else if (month == 2) return IsLeapYear(year) ? 29 : 28;
        else if (month == 3) return 31;
        else if (month == 4) return 30;
        else if (month == 5) return 31;
        else if (month == 6) return 30;
        else if (month == 7) return 31;
        else if (month == 8) return 31;
        else if (month == 9) return 30;
        else if (month == 10) return 31;
        else if (month == 11) return 30;
        else if (month == 12) return 31;
        else return 0; // Return 0 for invalid month
    }

    // Generates the lines (as strings) to visually represent one month in a calendar format
    public static List<string> GetMonthLines(int month, int year)
    {
        List<string> lines = new List<string>();
        string[] months = {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };

        // Add month title in format "Month, Year"
        lines.Add($"{months[month - 1]}, {year}".PadRight(22));
        lines.Add("Su Mo Tu We Th Fr Sa"); // Day headers

        int days = GetDaysInMonth(month, year); // Get number of days in the month
        int startDay = CalculateDayOfWeek(1, month, year); // Get day of week for 1st of month

        string week = new string(' ', startDay * 3); // Add padding for initial empty days
        int dayOfWeek = startDay;

        // Generate each date line for the month
        for (int date = 1; date <= days; date++)
        {
            week += $"{date,2} "; // Add the date, padded to 2 characters
            dayOfWeek++;

            // Start a new line after Saturday
            if (dayOfWeek == 7)
            {
                lines.Add(week.TrimEnd());
                week = "";
                dayOfWeek = 0;
            }
        }

        // Add the last week line if it wasn't added yet
        if (week.Length > 0)
            lines.Add(week.TrimEnd());

        return lines;
    }
}
    