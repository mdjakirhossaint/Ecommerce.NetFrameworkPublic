using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class DiscountCalculate
    {
        class Date
        {
            private int _month; // 1-12
            private int _day; // 1-31 depending on month
            private int _year; // sets the year

            public Date(int day, int month, int year)
            {
                Month = month;
                Day = day;
                Year = year;
            }

            public void nextDay()
            {
                try
                {
                    _day = _day++;
                }
                catch (ArgumentOutOfRangeException)
                {
                    if (_month == 12) // e.g if month dec 31st then it does a try 
                    {
                        _month = 1; // month then = 1
                        _year++; // year increments
                    }

                    else
                    {
                        _month++;
                    }
                    _day = 1;
                }

            }

            public int Year
            {
                get { return _year; }
                set
                {
                    if (value >= 1820 && value <= 2020) // if value is higher than or equal to 1820 and less than or equal to 2020
                        _year = value; // sets year as value
                    else
                        throw new ArgumentOutOfRangeException("Year must be between 1820 and 2020"); // throws an exception
                }
            }

            public int Month
            {
                get { return _month; }
                set
                {
                    if (value > 0 && value <= 12) // if value is higher than 0 and less than or equal to 12
                        _month = value; // sets month as value
                    else
                        throw new ArgumentOutOfRangeException("Month must be between 1-12"); // throws an exception
                }
            }

            public int Day
            {
                get { return _day; }
                set
                {
                    int[] days = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; // array of days of max each month

                    if (value > 0 && value <= days[_month]) // if value is higher than 0 and less than or equal to days of month
                        _day = value; // sets day as value

                    else if (_month == 2 && value == 29 && // else if month is equal to 2 and value is equal to 29
                        _year % 400 == 0 || (_year % 4 == 0 && _year % 100 != 0))
                        _day = value;
                    else
                        throw new ArgumentOutOfRangeException("Day is out of range"); // throws an exception
                }
            }
        }
    }
}
