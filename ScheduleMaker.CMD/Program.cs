using ScheduleMaker.GA;
using System;
using System.Collections.Generic;

namespace ScheduleMaker.CMD
{
    class Program
    {
        public static ICalculator calculator;

        public static Random rnd = new Random();
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
            bool isDouble = true; // Вещественные ли числа
            int min = -50; // Мин. значение
            int max = 50; // Макс. значение
            double mutationChance = 0.30; // Шанс мутации
            int mutationDelta = 2; // Относительная дельта
            int chromosomeCount = 40; // Количество хромосом
            int genesLength = 10; // Количество генов
            int generationsNumber = 1000; // Количество итераций
            calculator = new FunctionRastrigin(); // Функция отбора
            // Создание контроллера Генетического Алгоритма

            Parameter parameters = new Parameter(min, max, genesLength, mutationChance, mutationDelta);
            GeneticAlgorithmController gac = new GeneticAlgorithmController(parameters, calculator);

            // Генерация Хромосом
            List<Chromosome> chromosomeList = gac.InitializePopulation(chromosomeCount, genesLength);

            // Вывод первого поколения
            Console.WriteLine($"\n[{calculator.FunctionName}] 1 поколение:");
            ChromosomesOutput(chromosomeList, calculator.FunctionName, isDouble);
            #endregion

            #region Кроссоверы и мутации
            List<Chromosome> newChromosomeList = gac.Panmixia(chromosomeList, generationsNumber);
            #endregion

            #region Вывод
            // Вывод последнего поколения
            Console.WriteLine($"\n[{calculator.FunctionName}] {generationsNumber} поколение:");
            ChromosomesOutput(newChromosomeList, calculator.FunctionName, isDouble);

            // Самая успешная особь
            Console.WriteLine("\nГены самой приспособленной особи:");
            Console.WriteLine("  " + gac.BestChromosome.Fitness(calculator));
            for (int i = 0; i < gac.BestChromosome.Genes.Length; i++)
            {
                Console.Write($"  {newChromosomeList[0].Genes[i]}");
                if ((i + 1) % 5 == 0) Console.Write("\n");
            }
            #endregion
            

            Console.ReadLine();
        }

        public static void ChromosomesOutput(List<Chromosome> chromosomesList, string functionName, bool isDouble)
        {
            // Вывод особей
            for (int i = 0; i < chromosomesList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: " + string.Format("{0:0.0000}", chromosomesList[i].Fitness(calculator)));
            }
            // Вывод генов
            for (int i = 0; i < chromosomesList.Count; i++)
            {
                Console.Write($"{i + 1}:");
                for (int j = 0; j < chromosomesList[j].Genes.Length; j++)
                {
                    Console.Write("  " + string.Format("{0:0.0000}", chromosomesList[i].Genes[j]));
                    //if ((j + 1) % 5 == 0) Console.Write("\n");
                }
                Console.WriteLine();
            }
        }
    }
}
