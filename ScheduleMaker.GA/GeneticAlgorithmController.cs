using System;
using System.Collections.Generic;

namespace ScheduleMaker.GA
{
    public class GeneticAlgorithmController
    {
        public ICalculator Calculator { get; private set; }

        private static readonly Random rnd = new Random();

        /// <summary>
        /// Базовые параметры алгоритма.
        /// </summary>
        public Param Parameters { get; set; }

        /// <summary>
        /// Наилучшая хромосома.
        /// </summary>
        public Chromosome BestChromosome { get; set; }

        /// <summary>
        /// Последняя популяция.
        /// </summary>
        public List<Chromosome> LastPopulation { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="parameters">Базовые значения алгоритма.</param>
        /// <param name="calculator">Функция оценки Приспособленности.</param>
        public GeneticAlgorithmController(Param parameters, ICalculator calculator)
        {
            Parameters = parameters;
            Calculator = calculator;
            BestChromosome = null;
            LastPopulation = null;
        }

        /// <summary>Кроссовер.</summary>
        /// <param name="generationsNumber">Количество поколений.</param>
        /// <returns>Возвращает последнее поколение.</returns>
        public void Evolution(int generationsNumber)
        {
            for (int i = 0; i < generationsNumber; i++)
            {
                List<Chromosome> newPopulation = new List<Chromosome>();

                Crossover(LastPopulation, ref newPopulation);
                Mutatation(ref newPopulation);
                Selection(ref newPopulation);

                LastPopulation = newPopulation;
            }
        }

        #region Crossover, Mutation, Selection
        /// <summary>
        /// Кроссовер.
        /// </summary>
        /// <param name="chromosomeList1">Родители.</param>
        /// <param name="chromosomesList2">Потомки.</param>
        private void Crossover(List<Chromosome> chromosomeList1, ref List<Chromosome> chromosomesList2)
        {
            for (int i = 0; i < chromosomeList1.Count / 2; i++)
            {
                int roll = rnd.Next(0, chromosomeList1.Count);
                if (i == roll)
                {
                    i--;
                }
                else
                {
                    chromosomesList2.AddRange(Cross(chromosomeList1[i], chromosomeList1[roll]));
                }
            }
        }

        /// <summary>Скрещевание двух Особей.</summary>
        /// <param name="chromosome1">Первая Особь.</param>
        /// <param name="chromosome2">Вторая Особь.</param>
        /// <returns>Возвращает скрещенную Особь.</returns>
        private List<Chromosome> Cross(Chromosome chromosome1, Chromosome chromosome2)
        {
            List<Chromosome> chromosomesList = new List<Chromosome>();
            Chromosome newChromosome1;
            Chromosome newChromosome2;

            TwoPointCrossover(chromosome1, chromosome2, out newChromosome1, out newChromosome2);

            chromosomesList.Add(newChromosome1);
            chromosomesList.Add(newChromosome2);
            return chromosomesList;
        }

        /// <summary>Алгоритм обмена Генами с 2 точками.</summary>
        /// <param name="parent1">Родитель 1.</param>
        /// <param name="parent2">Родитель 2.</param>
        /// <param name="child1">Потомок 1.</param>
        /// <param name="child2">Потомок 2.</param>
        private void TwoPointCrossover(Chromosome parent1, Chromosome parent2, out Chromosome child1, out Chromosome child2)
        {
            child1 = new Chromosome() { Genes = new double[Parameters.GenesLength] };
            child2 = new Chromosome() { Genes = new double[Parameters.GenesLength] };

            Tuple<int, int> twoPoints = GetTwoPoints();

            SwapGenes(ref parent1, ref parent2, ref child1, ref child2, twoPoints.Item1, twoPoints.Item1);
        }

        /// <summary>
        /// Обмен Генами.
        /// </summary>
        /// <param name="parent1">Родитель 1.</param>
        /// <param name="parent2">Родитель 2</param>
        /// <param name="child1">Потомок 1.</param>
        /// <param name="child2">Потомок 2.</param>
        /// <param name="spot1">Точка 1.</param>
        /// <param name="spot2">Точка 2.</param>
        private void SwapGenes(ref Chromosome parent1, ref Chromosome parent2, ref Chromosome child1,
                              ref Chromosome child2, int spot1, int spot2)
        {
            for (int i = 0; i < spot1; i++)
            {
                child1.Genes[i] = parent1.Genes[i];
                child2.Genes[i] = parent2.Genes[i];
            }
            for (int i = spot1; i < spot2; i++)
            {
                child1.Genes[i] = parent2.Genes[i];
                child2.Genes[i] = parent1.Genes[i];
            }
            for (int i = spot2; i < Parameters.GenesLength; i++)
            {
                child1.Genes[i] = parent1.Genes[i];
                child2.Genes[i] = parent2.Genes[i];
            }
        }

        /// <summary>
        /// Создать две точки отрезка.
        /// </summary>
        /// <returns>Возвращает две точки отрезка.</returns>
        private Tuple<int, int> GetTwoPoints()
        {
            int locusSpot1 = rnd.Next(0, Parameters.GenesLength);
            int locusSpot2 = rnd.Next(0, Parameters.GenesLength);
            while (locusSpot2 == locusSpot1)
            {
                locusSpot2 = rnd.Next(0, Parameters.GenesLength);
            }
            if (locusSpot1 < locusSpot2)
            {
                return Tuple.Create(locusSpot1, locusSpot2);
            }
            else
            {
                return Tuple.Create(locusSpot2, locusSpot1);
            }
        }

        /// <summary>
        /// Мутация.
        /// </summary>
        /// <param name="population">Популяция.</param>
        private void Mutatation(ref List<Chromosome> population)
        {
            for (int i = 0; i < population.Count; i++)
            {
                double roll = rnd.NextDouble();
                if (roll < Parameters.MutationChance)
                {
                    Tuple<int, int> twoPoints = GetTwoPoints();
                    for (int j = twoPoints.Item1; j < twoPoints.Item2; j++)
                    {
                        population[i].Genes[j] = population[i].Genes[j] +
                        (rnd.NextDouble() * 2 * (Parameters.Delta) - Parameters.Delta);
                    }
                }
            }
        }

        /// <summary>
        /// Селекция.
        /// </summary>
        /// <param name="population">Популяция.</param>
        private void Selection(ref List<Chromosome> population)
        {
            population.Sort((x, y) => x.Fitness(Calculator).CompareTo(y.Fitness(Calculator)));
            //population[population.Count - 1] = CreateChromosome();
            GetTheBestChromosome(population[0]);

            // Инверсировать гены если одинаковые значения Fitness
            InverseGenes(ref population);
        }

        /// <summary>
        /// Инверсия Генов в обратном порядке
        /// </summary>
        /// <param name="population">Популяция.</param>
        private void InverseGenes(ref List<Chromosome> population)
        {
            for (int i = 0; i < population.Count - 1; i++)
            {
                if (population[i].Fitness(Calculator) == population[i + 1].Fitness(Calculator))
                {
                    Array.Reverse(population[i + 1].Genes);
                    i++;
                }
            }
        }
        #endregion

        private void GetTheBestChromosome(Chromosome chromosome)
        {
            if (chromosome.Fitness(Calculator) < BestChromosome.Fitness(Calculator))
            {
                BestChromosome = chromosome;
            }
        }

        /// <summary>Создать Особь.</summary>
        /// <returns>Возвращает Особь.</returns>
        private Chromosome CreateChromosome()
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

        /// <summary>Сгенерировать начальные данные.</summary>
        /// <param name="numberOfChromosomes">Количество Особей.</param>
        /// <returns>Возвращает список Особей.</returns>
        public List<Chromosome> InitializePopulation(int numberOfChromosomes)
        {
            List<Chromosome> chromosomeList = new List<Chromosome>();
            Parameters.IterationsNumber++;
            for (int i = 0; i < numberOfChromosomes; i++)
            {
                Chromosome newChromosome = CreateChromosome();
                chromosomeList.Add(newChromosome);
            }
            chromosomeList.Sort((x, y) => x.Fitness(Calculator).CompareTo(y.Fitness(Calculator)));
            BestChromosome = chromosomeList[0];
            LastPopulation = chromosomeList;
            return chromosomeList;
        }

        #region output
        /// <summary>
        /// Выводит в консоль последнюю популяцию.
        /// </summary>
        public void OutputLastPopulation()
        {
            for (int i = 0; i < LastPopulation.Count; i++)
            {
                Console.WriteLine($"{i + 1}: " + string.Format("{0:0.0000}", LastPopulation[i].Fitness(Calculator)));
            }
            for (int i = 0; i < LastPopulation.Count; i++)
            {
                Console.Write($"{i + 1}:");
                for (int j = 0; j < LastPopulation[j].Genes.Length; j++)
                {
                    Console.Write("  " + string.Format("{0:0.0000}", LastPopulation[i].Genes[j]));
                    //if ((j + 1) % 5 == 0) Console.Write("\n");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Выводит в консоль наилучшую хромосому.
        /// </summary>
        public void OutputBestChromosome()
        {
            Console.WriteLine("\nГены самой приспособленной особи:");
            Console.WriteLine("  " + BestChromosome.Fitness(Calculator));
            for (int i = 0; i < BestChromosome.Genes.Length; i++)
            {
                Console.Write($"  {BestChromosome.Genes[i]}");
                if ((i + 1) % 5 == 0) Console.Write("\n");
            }
        }
        #endregion
    }
}
