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
            int year = 0;         //Год рождения 
            int currentDay = 0;   //Текущий день
            int currentMonth = 0; //Текущий месяц
            int birthdayDay = 0;  //День рождения
            int birthdayMonth = 0;//Месяц рождения
            int days = 0;         //Дни до следующего дня рождения

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
            //Если год високосный - добавляем три года
            //к количеству дней
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
                days = 365 * 3;

            //Отнимаем от произведения дней и месяцев дня рождения от соответствующих текущих
            days = currentDay * currentMonth - birthdayDay * birthdayMonth;
            if (days < 0)
                days *= -1;

            writer.WriteLine(days);
            writer.Close();
        }
    }
}
