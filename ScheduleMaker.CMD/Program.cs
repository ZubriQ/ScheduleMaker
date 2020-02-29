﻿using ScheduleMaker.GA;
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
            Console.WriteLine("Hello World!\n");
            
            #region Подготовка данных
            bool isDouble = true; // Вещественные ли числа
            int min = -50; // Мин. значение
            int max = 50; // Макс. значение
            int mutationChance = 4; // Шанс мутации
            int mutationDelta = 2; // Относительная дельта
            int chromosomeCount = 40; // Количество хромосом
            int chromosomeGenesLength = 10; // Количество генов
            int generationsNumber = 4000; // Количество итераций
            string functionName = "Розенброк"; // Выбор нужной функции: Розенброк, Сфера, Растригин
            // TODO: исправить functionName

            // Создание контроллера Генетического Алгоритма
            GeneticAlgorithmController gac = new GeneticAlgorithmController(min, max, mutationChance, isDouble);

            // Генерация Хромосом
            List<Chromosome> chromosomeList = gac.GenerateData(chromosomeCount, chromosomeGenesLength);

            // Вывод первого поколения
            Console.WriteLine($"\n[{functionName}] 1 поколение:");
            ChromosomesOutput(chromosomeList, functionName, isDouble);
            #endregion

            #region Кроссоверы и мутации
            List<Chromosome> newChromosomeList = gac.Panmixia(chromosomeList, generationsNumber, functionName, mutationDelta);
            #endregion

            #region Вывод
            // Вывод последнего поколения
            Console.WriteLine($"\n[{functionName}] {generationsNumber} поколение:");
            ChromosomesOutput(newChromosomeList, functionName, isDouble);

            // Самая успешная особь
            Console.WriteLine("\nГены самой приспособленной особи:");
            Console.WriteLine("  " + newChromosomeList[0].Fitness(functionName));
            for (int i = 0; i < newChromosomeList[0].Genes.Length; i++)
            {
                Console.Write($"  {newChromosomeList[0].Genes[i]}");
                if ((i + 1) % 5 == 0) Console.Write("\n");
            }
            #endregion

            Console.ReadLine();
        }

        public static void ChromosomesOutput(List<Chromosome> chromosomesList, string functionName, bool isDouble)
        {
            if (isDouble)
            {
                // Вывод особей
                for (int i = 0; i < chromosomesList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: " + string.Format("{0:0.0000}", chromosomesList[i].Fitness(functionName)));
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
            else
            {
                for (int i = 0; i < chromosomesList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {chromosomesList[i].Fitness(functionName)}");
                }
                for (int i = 0; i < chromosomesList.Count; i++)
                {
                    Console.Write($"{i + 1}:");
                    for (int j = 0; j < chromosomesList[j].Genes.Length; j++)
                    {
                        Console.Write($"  {chromosomesList[i].Genes[j]}");
                        //if ((j + 1) % 5 == 0) Console.Write("\n");
                    }
                    Console.WriteLine();
                }
            }
            
        }
    }
}
