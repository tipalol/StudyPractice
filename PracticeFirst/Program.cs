using System.IO;
using System;

namespace PracticeFirst
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            var reader = new StreamReader("INPUT.TXT"); //Поток ввода
            var writer = new StreamWriter("OUTPUT.TXT");//Поток вывода
            var monthSize = new int[] { 0, 31, 0, 31, 30, 31, 30, 31, 30, 31, 30, 31, 30 }; 
            string[] currentDate; //Текущая дата
            string[] birthdayDate;//Дата дня рождения
            var year = 0;         //Год рождения 
            var currentDay = 0;   //Текущий день
            var currentMonth = 0; //Текущий месяц
            var birthdayDay = 0;  //День рождения
            var birthdayMonth = 0;//Месяц рождения
            var days = 0;         //Дни до следующего дня рождения
            var monthDays = 0;

            try {
                currentDate = reader.ReadLine().Split(' ');
                birthdayDate = reader.ReadLine().Split(' ');
                reader.Close();
                currentDay = Convert.ToInt32(currentDate[0]);
                if (currentDate[1].Contains("0"))
                    currentMonth = Convert.ToInt32(currentDate[1].Remove(0, 1));
                else
                    currentMonth = Convert.ToInt32(currentDate[1]);
                birthdayDay = Convert.ToInt32(birthdayDate[0]);
                if (birthdayDate[1].Contains("0"))
                    birthdayMonth = Convert.ToInt32(birthdayDate[1].Remove(0, 1));
                else
                    birthdayMonth = Convert.ToInt32(birthdayDate[1]);
                year = Convert.ToInt32(birthdayDate[2]);
            } catch {
                writer.WriteLine("Ошибка во входных данных");
                writer.Close();
                Environment.Exit(1);
            }



            //Проверка на високосный год
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
                monthSize[2] = 29;
            else
                monthSize[2] = 28;

            monthDays = monthSize[currentMonth];

            while (!(currentDay == birthdayDay && currentMonth == birthdayMonth))
            {
                if (currentDay == 31 && currentMonth == 12)
                {
                    currentDay = 1;
                    currentMonth = 1;
                }
                else if (currentDay == monthDays)
                {
                    currentDay = 1;
                }
                else
                    days++;

                days++;

            }


            writer.WriteLine(days);
            writer.Close();
        }
    }
}
