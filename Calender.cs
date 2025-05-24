using System;
using System.Collections.Generic;

public class CalendarUtils
{
    // Determines whether a given year is a leap year
    public static bool IsLeapYear(int year) =>
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
        else return 0;
    }

    // Generates a list of strings representing a month's calendar layout
    public static List<string> GetMonthLines(int month, int year)
    {
        List<string> lines = new List<string>();
        string[] months = {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };

        lines.Add($"{months[month - 1]}, {year}".PadRight(22));
        lines.Add("Su Mo Tu We Th Fr Sa");

        int days = GetDaysInMonth(month, year);
        int startDay = Program.CalculateDayOfWeek(1, month, year);

        string week = new string(' ', startDay * 3);
        int dayOfWeek = startDay;

        for (int date = 1; date <= days; date++)
        {
            week += $"{date,2} ";
            dayOfWeek++;

            if (dayOfWeek == 7)
            {
                lines.Add(week.TrimEnd());
                week = "";
                dayOfWeek = 0;
            }
        }

        if (week.Length > 0)
            lines.Add(week.TrimEnd());

        return lines;
    }
}
