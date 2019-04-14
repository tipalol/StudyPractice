using System.IO;
using System;
namespace PracticeFirst
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var reader = new StreamReader("INPUT.TXT");
            var writer = new StreamWriter("OUTPUT.TXT");
            var monthSize = new int[] { 0, 31, 0, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] input = reader.ReadLine().Split(' ');
            int bday = Convert.ToInt32( input[0] );
            int bmonth = Convert.ToInt32(input[1].Trim('0'));
            input = reader.ReadLine().Split(' ');
            reader.Close();
            int day = Convert.ToInt32(input[0]);
            int month = Convert.ToInt32(input[1].Trim('0'));
            int year = Convert.ToInt32(input[2]);
            int days = 0;
            while (!(day == bday && month == bmonth))
            {
                int daysInFebruary;
                if ((year % 4 ==0 && year % 100 != 0) || year % 400 == 0)
                {
                    daysInFebruary = 29;
                } else
                {
                    daysInFebruary = 28;
                }
                int daysInMonth = 0;
                if (month == 2)
                {
                    daysInMonth = daysInFebruary;
                } else
                {
                    daysInMonth = monthSize[month];
                }
                if (day == 31 && month == 12)
                {
                    day = 1;
                    month = 1;
                    year++;
                } else if (day == daysInMonth)
                {
                    day = 1;
                    month++;
                } else
                {
                    day++;
                }
                days++;
            }
            writer.Write(days);
            writer.Close();
        }
    }
}
