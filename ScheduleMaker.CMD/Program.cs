using ScheduleMaker.GA;
using System;
using System.Collections.Generic;

namespace ScheduleMaker.CMD
{
    class Program
    {
        public static ICalculator calculator;
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
            Console.WriteLine("Hello World!\n");
           
            int min = -100; // Мин. значение
            int max = 100; // Макс. значение
            double mutationChance = 0.30; // Шанс мутации
            int mutationDelta = 3; // Относительная дельта
            int chromosomeCount = 40; // Количество хромосом
            int genesLength = 10; // Количество генов
            int generationsNumber = 500; // Количество итераций
            calculator = new FunctionRastrigin(); // Функция отбора

            while (true)
            {
                // Создание параметров и контроллера Генетического Алгоритма
                Parameter parameters = new Parameter(min, max, genesLength, mutationChance, mutationDelta);
                GeneticAlgorithmController gac = new GeneticAlgorithmController(parameters, calculator);

                // Инициализация начального поколения
                gac.InitializePopulation(chromosomeCount);

                // Вывод первого поколения
                Console.WriteLine($"\n[{calculator.FunctionName}] 1 поколение:");
                gac.OutputLastPopulation();

                // Сам процесс
                gac.Evolution(generationsNumber);

                // Вывод последнего поколения
                Console.WriteLine($"\n[{calculator.FunctionName}] {generationsNumber} поколение:");
                gac.OutputLastPopulation();

                // Самая успешная особь
                gac.OutputBestChromosome();

                // Повторить процесс?
                Console.WriteLine("\nСгенерировать новые поколения?");
                Console.ReadLine();
            }
        }
    }
}
