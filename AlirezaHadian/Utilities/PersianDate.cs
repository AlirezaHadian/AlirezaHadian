using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Globalization;

namespace AlirezaHadian.Utilities
{
    public static class PersianDate
    {
        public static string ToShamsiWithHour(this DateTime dt)
        {
            string[] persianDayNames = {
        "یک‌شنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه"
    };
            PersianCalendar persianCalendar = new PersianCalendar();
            string dayname = persianDayNames[(int)dt.DayOfWeek];
            int year = persianCalendar.GetYear(dt);
            int month = persianCalendar.GetMonth(dt);
            int day = persianCalendar.GetDayOfMonth(dt);
            int hour = persianCalendar.GetHour(dt);
            int minute = persianCalendar.GetMinute(dt);

            string persianDate = $"{dayname} - {year:0000}/{month:00}/{day:00} در ساعت {hour:00}:{minute:00}";
            return persianDate;
        }

        public static string ToShamsi(this DateTime dt)
        {
            string[] persianDayNames = {
        "یک‌شنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه"
    };
            PersianCalendar persianCalendar = new PersianCalendar();
            string dayname = persianDayNames[(int)dt.DayOfWeek];
            int year = persianCalendar.GetYear(dt);
            int month = persianCalendar.GetMonth(dt);
            int day = persianCalendar.GetDayOfMonth(dt);

            string persianDate = $"{dayname} - {year:0000}/{month:00}/{day:00}";
            return persianDate;
        }
    }
}
