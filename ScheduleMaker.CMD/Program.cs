
using ScheduleMaker.GA;
using System;
using System.Collections.Generic;

namespace ScheduleMaker.CMD
{
    class Program
    {
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
            GeneticAlgorithmController gac = new GeneticAlgorithmController();

            #region Начальные данные

            // Генерация Хромосом
            // 1- Количество хромосом, 2- Кол-во генов, 3- Мин. значение, 4- Макс. значение
            List<Chromosome> chromosomeList = gac.GenerateData(10, 3, -1, 200);

            // Количество итераций
            int generationsNumber = 50000;

            // Вывод
            int chromosomeCount = 1;
            foreach (var chromosome in chromosomeList)
            {
                Console.WriteLine($"{chromosomeCount}: {chromosome.RosenbrockFitness}");
                chromosomeCount++;
            }
            #endregion

            #region Кроссовер
            List<Chromosome> newChromosomeList = gac.Crossover(chromosomeList, generationsNumber);
            Console.WriteLine($"Спустя {generationsNumber} поколений(ие):");

            // Вывод
            foreach (var chromosome in newChromosomeList)
            {
                Console.WriteLine(chromosome.RosenbrockFitness);
            }
            #endregion

            Console.ReadLine();
        }

        
    }
}
