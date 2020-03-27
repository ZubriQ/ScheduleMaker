using ScheduleMaker.GA;
using ScheduleMaker.OP;
using ScheduleMaker.OP.School;
using ScheduleMaker.PSO;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("Добро пожаловать. Нажмите на клавишу:\n1 - GA.\n2 - PSO.\n3 - Test Open Shop");
            var pressedKey = Console.ReadKey();
            switch (pressedKey.Key)
            {
                #region GA
                case ConsoleKey.D1:
                    int min = -500; // Мин. значение
                    int max = 500; // Макс. значение
                    double mutationChance = 0.75; // Шанс мутации
                    int mutationDelta = 2; // Относительная дельта
                    int chromosomeCount = 400; // Количество хромосом
                    int genesLength = 10; // Количество генов
                    int generationsNumber = 1000; // Количество итераций
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
                    double constantOfSpeed1 = 1.49445; // Константа скорости 1
                    double constantOfSpeed2 = 1.49445; // Константа скорости 2
                    double inertia = 0.729; // Инерция
                    int minimum = -300; // Мин. значение
                    int maximum = 300; // Макс. значение
                    int iterationsNumber = 4000; // Количество повторений
                    int particleCount = 40; // Количество Частиц
                    int dimensionCount = 10; // Количество измерений
                    calculator = new FunctionRosenbrock();

                    while (true)
                    {
                        Console.WriteLine("\n\tВыбран Particle Swarm Optimization.\n");

                        PSO.Parameter parameters = new PSO.Parameter(minimum, maximum, particleCount, dimensionCount);
                        PSOController pso = new PSOController(parameters, calculator);
                        pso.InitializeParticleSwarm();
                        pso.FindGlobalMinimum(inertia, constantOfSpeed1, constantOfSpeed2, iterationsNumber);

                        // Повторить процесс?
                        Console.WriteLine("\nСгенерировать новые данные? (Нажмите любую клавишу).");

                        Console.ReadLine();
                    }
                #endregion

                #region Open Shop
                case ConsoleKey.D3:

                    while (true)
                    {
                        Console.WriteLine("\n\tВыбран Open Shop.\n");


                        // Создание Open Shop и Учебного плана
                        int teachersCount = 2;
                        int syllabusesCount = 1;
                        int subjectsCount = 2;
                        byte daysCount = 6;
                        // Все Учителя в школе
                        Teacher[] teachers = new Teacher[teachersCount];
                        teachers[0] = new Teacher(0, "Алг.");
                        teachers[1] = new Teacher(1, "Рус.");

                        // Предмет одного Учебного плана
                        Subject[] subjects1 = new Subject[subjectsCount];
                        subjects1[0] = new Subject("Алг.", 11, 13);
                        subjects1[1] = new Subject("Рус.", 11, 15);

                        // Учебный план
                        Syllabus[] syllabuses = new Syllabus[syllabusesCount];
                        Syllabus syllabus1 = new Syllabus(0, "10А", subjects1, teachers, daysCount);
                        syllabuses[0] = syllabus1;

                        // Вызов Open Shop
                        OpenShop openShop = new OpenShop(teachers, syllabuses);

                        // Создание расписания
                        openShop.MakeScheduleById(0);

                        // Вывод
                        openShop.OutputMachines();
                        openShop.OutputScheduleById(0);



                        Console.WriteLine("\nПовторить процесс? (Нажмите любую клавишу).");
                        Console.ReadLine();
                    }
                    #endregion
            }
        }
    }
}
