using System;
using System.Collections.Generic;

namespace ScheduleMaker.GA
{
    public class GeneticAlgorithmController
    {
        public ICalculator Calculator { get; private set; }

        private static readonly Random rnd = new Random();

        /// <summary>
        /// Базовые параметры алгоритма популяций.
        /// </summary>
        public Parameter Parameters { get; set; }

        /// <summary>
        /// Наилучшая хромосома.
        /// </summary>
        public Chromosome BestChromosome { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="parameters">Базовые значения алгоритма.</param>
        /// <param name="calculator">Функция оценки Приспособленности.</param>
        public GeneticAlgorithmController(Parameter parameters, ICalculator calculator)
        {
            Parameters = parameters;
            Calculator = calculator;
            BestChromosome = null;
        }

        /// <summary>Создать Особь типа Double.</summary>
        /// <returns>Возвращает Особь типа Double.</returns>
        public Chromosome CreateChromosome()
        {
            Chromosome chromosome = new Chromosome();
            chromosome.Genes = new double[Parameters.GenesLength];
            for (int i = 0; i < Parameters.GenesLength; i++)
            {
                double gene = rnd.NextDouble() * (Parameters.Max - Parameters.Min) + Parameters.Min;
                chromosome.Genes[i] = gene;
            }
            return chromosome;
        }

        /// <summary>Кроссовер.</summary>
        /// <param name="chromosomeList">Список Хромосом.</param>
        /// <param name="times">Количество итераций.</param>
        /// <param name="functionName">Название функции.</param>
        /// <param name="delta">Возможное смещение значения Гена (± дельта).</param>
        /// <returns>Возвращает последнее поколение.</returns>
        public List<Chromosome> Panmixia(List<Chromosome> chromosomeList, int times)
        {
            List<Chromosome> result = chromosomeList;
            int chromosomesCount = chromosomeList.Count;
            for (int k = 0; k < times; k++)
            {
                List<Chromosome> newChromosomesList = new List<Chromosome>();
                for (int i = 0; i < chromosomesCount / 2; i++)
                {
                    int roll = rnd.Next(0, chromosomesCount);
                    if (i == roll)
                    {
                        i--;
                    }
                    else
                    {
                        newChromosomesList.AddRange(Mapping(result[i], result[roll]));
                    }
                }
                // Упорядочивание и замена слабой Хромосомы случайной
                newChromosomesList.Sort((x, y) => x.Fitness(Calculator).CompareTo(y.Fitness(Calculator)));
                // Добавление нового случайного потомка вместо наихудшего
                newChromosomesList[Parameters.GenesLength - 1] = CreateChromosome();
                result = newChromosomesList;
            }
            return result;
        }

        /// <summary>Скрещевание двух Особей.</summary>
        /// <param name="chromosome1">Первая Особь.</param>
        /// <param name="chromosome2">Вторая Особь.</param>
        /// <param name="delta">Возможное смещение значения Гена (± дельта).</param>
        /// <returns>Возвращает скрещенную Особь.</returns>
        public List<Chromosome> Mapping(Chromosome chromosome1, Chromosome chromosome2)
        {
            // Инициализация переменных
            List<Chromosome> chromosomesList = new List<Chromosome>();
            Chromosome newChromosome1;
            Chromosome newChromosome2;
            // Кроссовер, Вид Кроссовера
            TwoPointCrossover(chromosome1, chromosome2, out newChromosome1, out newChromosome2);
            // Мутации
            Mutate(newChromosome1);
            Mutate(newChromosome2);
            // Возвращение двух Особей
            chromosomesList.Add(newChromosome1);
            chromosomesList.Add(newChromosome2);
            return chromosomesList;
        }

        /// <summary>Алгоритм обмена Генами с 1 точкой.</summary>
        /// <param name="chromosome1">Родитель 1.</param>
        /// <param name="chromosome2">Родитель 2.</param>
        /// <param name="newChromosome1">Потомок 1.</param>
        /// <param name="newChromosome2">Потомок 2.</param>
        public void SinglePointCrossover(
            Chromosome chromosome1, Chromosome chromosome2, out Chromosome newChromosome1, out Chromosome newChromosome2)
        {
            newChromosome1 = new Chromosome() { Genes = new double[Parameters.GenesLength] };
            newChromosome2 = new Chromosome() { Genes = new double[Parameters.GenesLength] };
            int locusSpot = rnd.Next(0, Parameters.GenesLength);
            int roll = rnd.Next(0, 2);
            if (roll == 0)
            {
                Calculator.Fitness(chromosome2.Genes);
                for (int i = 0; i < locusSpot; i++)
                {
                    newChromosome1.Genes[i] = chromosome2.Genes[i];
                    newChromosome2.Genes[i] = chromosome1.Genes[i];
                }
                for (int i = locusSpot; i < Parameters.GenesLength; i++)
                {
                    newChromosome1.Genes[i] = chromosome1.Genes[i];
                    newChromosome2.Genes[i] = chromosome2.Genes[i];
                }
            }
            else
            {
                for (int i = 0; i < locusSpot; i++)
                {
                    newChromosome1.Genes[i] = chromosome1.Genes[i];
                    newChromosome2.Genes[i] = chromosome2.Genes[i];
                }
                for (int i = locusSpot; i < Parameters.GenesLength; i++)
                {
                    newChromosome1.Genes[i] = chromosome2.Genes[i];
                    newChromosome2.Genes[i] = chromosome1.Genes[i];
                }
            }
        }

        /// <summary>Алгоритм обмена Генами с 2 точками.</summary>
        /// <param name="chromosome1">Родитель 1.</param>
        /// <param name="chromosome2">Родитель 2.</param>
        /// <param name="newChromosome1">Потомок 1.</param>
        /// <param name="newChromosome2">Потомок 2.</param>
        public void TwoPointCrossover(
            Chromosome chromosome1, Chromosome chromosome2, out Chromosome newChromosome1, out Chromosome newChromosome2)
        {
            newChromosome1 = new Chromosome() { Genes = new double[Parameters.GenesLength] };
            newChromosome2 = new Chromosome() { Genes = new double[Parameters.GenesLength] };
            int locusSpot1 = rnd.Next(0, Parameters.GenesLength);
            int locusSpot2 = rnd.Next(0, Parameters.GenesLength);
            while (locusSpot2 == locusSpot1)
            { 
                locusSpot2 = rnd.Next(0, Parameters.GenesLength);
            }
            if (locusSpot1 < locusSpot2)
            {
                for (int i = 0; i < locusSpot1; i++)
                {
                    newChromosome1.Genes[i] = chromosome1.Genes[i];
                    newChromosome2.Genes[i] = chromosome2.Genes[i];
                }
                for (int i = locusSpot1; i < locusSpot2; i++)
                {
                    newChromosome1.Genes[i] = chromosome2.Genes[i];
                    newChromosome2.Genes[i] = chromosome1.Genes[i];
                }
                for (int i = locusSpot2; i < Parameters.GenesLength; i++)
                {
                    newChromosome1.Genes[i] = chromosome1.Genes[i];
                    newChromosome2.Genes[i] = chromosome2.Genes[i];
                }
            }
            else
            {
                for (int i = 0; i < locusSpot2; i++)
                {
                    newChromosome1.Genes[i] = chromosome1.Genes[i];
                    newChromosome2.Genes[i] = chromosome2.Genes[i];
                }
                for (int i = locusSpot2; i < locusSpot1; i++)
                {
                    newChromosome1.Genes[i] = chromosome2.Genes[i];
                    newChromosome2.Genes[i] = chromosome1.Genes[i];
                }
                for (int i = locusSpot1; i < Parameters.GenesLength; i++)
                {
                    newChromosome1.Genes[i] = chromosome1.Genes[i];
                    newChromosome2.Genes[i] = chromosome2.Genes[i];
                }
            }
        }

        /// <summary>
        /// Мутация Особи.
        /// </summary>
        /// <param name="chromosome">Особь.</param>
        /// <returns>Возвращает мутированную или такую же Особь.</returns>
        public Chromosome Mutate(Chromosome chromosome)
        {
            double roll = rnd.NextDouble();
            int spot = rnd.Next(0, chromosome.Genes.Length);
            if (roll < Parameters.MutationChance)
            {
                int isPlus = rnd.Next(0, 2);
                if (isPlus == 0)
                {
                    chromosome.Genes[spot] = chromosome.Genes[spot] + 
                        (rnd.NextDouble() * (Parameters.Delta - 1) + Parameters.Delta);
                }
                else
                {
                    chromosome.Genes[spot] = chromosome.Genes[spot] - 
                        (rnd.NextDouble() * (Parameters.Delta - 1) + Parameters.Delta);
                }
            }
            return chromosome;
        }

        /// <summary>Сгенерировать начальные данные.</summary>
        /// <param name="numberOfChromosomes">Количество Особей.</param>
        /// <param name="genesLength">Количество Генов.</param>
        /// <returns>Возвращает список Особей.</returns>
        public List<Chromosome> GenerateData(int numberOfChromosomes, int genesLength)
        {
            List<Chromosome> chromosomeList = new List<Chromosome>();
            Parameters.GenesLength = genesLength;
            Parameters.IterationsNumber++;
            for (int i = 0; i < numberOfChromosomes; i++)
            {
                Chromosome newChromosome = CreateChromosome();
                chromosomeList.Add(newChromosome);
            }
            return chromosomeList;
        }
    }
}
