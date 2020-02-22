using ScheduleMaker.GA;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("Hello World!\n");

            #region Подготовка данных
            // Создание контроллера Генетического Алгоритма
            GeneticAlgorithmController gac = new GeneticAlgorithmController(-30, 30, false);

            // Выбор нужной функции: Розенброк, Сфера, Растригин
            string functionName = "Розенброк";

            // Генерация Хромосом
            // 1- Количество хромосом, 2- Кол-во генов
            List<Chromosome> chromosomeList = gac.GenerateData(15, 5);

            // Количество итераций
            int generationsNumber = 100000;

            // Вывод первого поколения
            Console.WriteLine($"[{functionName}] 1 поколение:");
            for (int i = 0; i<chromosomeList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {chromosomeList[i].Fitness(functionName)}");
            }
            #endregion

            #region Кроссовер
            List<Chromosome> newChromosomeList = gac.Crossover(chromosomeList, generationsNumber, functionName);
            #endregion

            #region Вывод
            // Вывод последнего поколения
            Console.WriteLine($"\n[{functionName}] Спустя {generationsNumber} поколений:");
            for (int i = 0; i < newChromosomeList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {newChromosomeList[i].Fitness(functionName)}");
            }

            // Успешные гены
            Console.WriteLine("\nГены самой приспособленной особи:");
            for (int i = 0; i < newChromosomeList[0].Genes.Length; i++)
            {
                Console.Write($"{newChromosomeList[0].Genes[i]} ");
                if ((i + 1) % 5 == 0) Console.Write("\n");
            }
            #endregion

            Console.ReadLine();
        }
    }
}
