using System;

namespace ScheduleMaker.CMD
{
    class Program
    {
        ///    Генетический алгоритм 
        /// Создание популяции
        /// Вычисление Fitness
        /// ПОВТОР:
        ///    Выбор
        ///    Crossover
        ///    Мутация
        ///    Вычисление Fitness

        /// Функция Розенброка
        /// f(x, y) = (1-x)^2 + 100(y-x^2)^2
        /// 

        static void Main(string[] args)
        {
            #region initial data
            // Входные данные на 1 четверть:
            int weeksNumber = 8; // Кол-во Недель в Четверти (8,8,10,8)
            int subjectsNumber = 5; // Кол-во предметов
            int classroomsNumber = 16; // 16 Младшие, 30 Старшие
            int summaryLessonsNumber = 160; // Уроков в четверть
            int studyDaysPerWeek = 5; // 5/6 учебных Дней в Неделю
            int maximumLessonsPerDay = 4; // 4-8 Уроков в День
            int maximumLessonsPerWeek = 21; // 21-34 Урока в зависимости от Класса. +3 если 6 Дней
            #endregion
            Console.WriteLine("Hello World!");

            Console.WriteLine(Rosenbrock(1,1));
            Console.WriteLine(Rosenbrock(-2, 4));
            Console.WriteLine(Rosenbrock(2, -4));
            Console.WriteLine(Rosenbrock(4, -16));
            Console.WriteLine(Rosenbrock(10, -100));
            Console.WriteLine(Rosenbrock(10, 100));
            Console.WriteLine(Rosenbrock(11, 121));

            Console.ReadLine();
        }

        public static double Rosenbrock(int x, int y)
        {
            return Math.Pow( (1 - x), 2) + 100 * Math.Pow(y - Math.Pow(x, 2), 2);
        }
    }
}
