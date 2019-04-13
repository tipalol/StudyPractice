using System.IO;
using System;

namespace PracticeFirst
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("INPUT.TXT"); //Поток ввода
            StreamWriter writer = new StreamWriter("OUTPUT.TXT");//Поток вывода
            string[] currentDate; //Текущая дата
            string[] birthdayDate;//Дата дня рождения
            int year = 0;     //Год рождения 
            int currentDay;   //Текущий день
            int currentMonth; //Текущий месяц
            int birthdayDay;  //День рождения
            int birthdayMonth;//Месяц рождения
            int days = 0;     //Дни до следующего дня рождения

            try {
                currentDate = reader.ReadLine().Split(' ');
                birthdayDate = reader.ReadLine().Split(' ');
                reader.Close();
                currentDay = Convert.ToInt32(currentDate[0]);
                currentMonth = Convert.ToInt32(currentDate[1]);
                birthdayDay = Convert.ToInt32(birthdayDate[0]);
                birthdayMonth = Convert.ToInt32(birthdayDate[1]);
                year = Convert.ToInt32(birthdayDate[2]);
            } catch {
                writer.WriteLine("Ошибка во входных данных");
                writer.Close();
                Environment.Exit(1);
            }

            //Проверка на високосный год
            //Если год високосный - добавляем три года
            //к количеству дней
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
                days = 365 * 3;


        }
    }
}
