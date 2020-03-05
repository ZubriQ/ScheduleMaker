using ScheduleMaker.GA;
using ScheduleMaker.PSO;
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
            /* // Входные данные на 1 четверть:
            int weeksNumber = 8; // Кол-во Недель в Четверти (8,8,10,8)
            int subjectsNumber = 5; // Кол-во предметов
            int classroomsNumber = 16; // 16 Младшие, 30 Старшие
            int summaryLessonsNumber = 160; // Уроков в четверть
            int studyDaysPerWeek = 5; // 5/6 учебных Дней в Неделю
            int maximumLessonsPerDay = 4; // 4-8 Уроков в День
            int maximumLessonsPerWeek = 21; // 21-34 Урока в зависимости от Класса. +3 если 6 Дней */
            #endregion
            Console.WriteLine("Добро пожаловать. Нажмите на клавишу:\n1 - GA.\n2 - PSO.");
            var pressedKey = Console.ReadKey();
            switch (pressedKey.Key)
            {
                #region GA
                case ConsoleKey.D1:
                    int min = -130; // Мин. значение
                    int max = 130; // Макс. значение
                    double mutationChance = 0.30; // Шанс мутации
                    int mutationDelta = 3; // Относительная дельта
                    int chromosomeCount = 40; // Количество хромосом
                    int genesLength = 10; // Количество генов
                    int generationsNumber = 500; // Количество итераций
                    calculator = new FunctionSphere(); // Функция 

                    while (true)
                    {
                        Console.WriteLine("\n\tВыбран Genetic Algorithm.\n");
                        // Создание параметров и контроллера Генетического Алгоритма
                        GA.Parameter parameters = new GA.Parameter(min, max, genesLength, mutationChance, mutationDelta);
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
                        Console.WriteLine("\nСгенерировать новые поколения? (Нажмите любую клавишу).");
                        
                        Console.ReadLine();
                    }
                #endregion

                #region PSO
                case ConsoleKey.D2:
                    // TODO: Это работает?? ?   ?  ?  ? ?? ??   ?

                    int minimum = -1000; // Мин. значение
                    int maximum = 1000; // Макс. значение
                    int constantOfSpeed1 = 2; // Константа скорости 1
                    int constantOfSpeed2 = 2; // Константа скорости 2
                    int iterationsNumber = 7; // Количество повторений
                    int particlesCount = 15; // Количество Частиц
                    calculator = new FunctionSphere();

                    while (true)
                    {
                        Console.WriteLine("\n\tВыбран Particle Swarm Optimization.\n");

                        PSO.Parameter parameters = new PSO.Parameter(minimum, maximum);
                        PSOController pso = new PSOController(parameters, calculator);
                        pso.InitializeSwarm(particlesCount);
                        pso.FindCriteria(constantOfSpeed1, constantOfSpeed2, iterationsNumber);

                        // Повторить процесс?
                        Console.WriteLine("\nСгенерировать новые данные? (Нажмите любую клавишу).");

                        Console.ReadLine();
                    }
                    #endregion
            }
        }
    }
}
