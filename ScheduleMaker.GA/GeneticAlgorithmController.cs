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
        /// <param name="iterationsNumber">Количество итераций.</param>
        /// <param name="functionName">Название функции.</param>
        /// <param name="delta">Возможное смещение значения Гена (± дельта).</param>
        /// <returns>Возвращает последнее поколение.</returns>
        public List<Chromosome> Panmixia(List<Chromosome> chromosomeList, int iterationsNumber)
        {
            List<Chromosome> result = chromosomeList;
            for (int k = 0; k < iterationsNumber; k++)
            {
                List<Chromosome> newChromosomesList = new List<Chromosome>();

                // TODO: сделать поочередно кроссовер, мутации и селекцию
                // Кроссовер и мутации
                Cross(ref result, ref newChromosomesList);

                newChromosomesList.Sort((x, y) => x.Fitness(Calculator).CompareTo(y.Fitness(Calculator)));
                FindTheBestChromosome(newChromosomesList[0]);
                newChromosomesList[Parameters.GenesLength - 1] = CreateChromosome();
                result = newChromosomesList;
            }
            return result;
        }

        public void Cross(ref List<Chromosome> chromosomeList1, ref List<Chromosome> chromosomesList2)
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
                    chromosomesList2.AddRange(CrossoverAndMutation(chromosomeList1[i], chromosomeList1[roll]));
                }
            }
        }

        public void FindTheBestChromosome(Chromosome chromosome)
        {
            if (chromosome.Fitness(Calculator) < BestChromosome.Fitness(Calculator))
            {
                BestChromosome = chromosome;
            }
        }

        /// <summary>Скрещевание двух Особей.</summary>
        /// <param name="chromosome1">Первая Особь.</param>
        /// <param name="chromosome2">Вторая Особь.</param>
        /// <param name="delta">Возможное смещение значения Гена (± дельта).</param>
        /// <returns>Возвращает скрещенную Особь.</returns>
        public List<Chromosome> CrossoverAndMutation(Chromosome chromosome1, Chromosome chromosome2)
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

        /// <summary>Алгоритм обмена Генами с 2 точками.</summary>
        /// <param name="parent1">Родитель 1.</param>
        /// <param name="parent2">Родитель 2.</param>
        /// <param name="child1">Потомок 1.</param>
        /// <param name="child2">Потомок 2.</param>
        public void TwoPointCrossover(Chromosome parent1, Chromosome parent2, out Chromosome child1, out Chromosome child2)
        {
            child1 = new Chromosome() { Genes = new double[Parameters.GenesLength] };
            child2 = new Chromosome() { Genes = new double[Parameters.GenesLength] };
            int locusSpot1 = rnd.Next(0, Parameters.GenesLength);
            int locusSpot2 = rnd.Next(0, Parameters.GenesLength);
            while (locusSpot2 == locusSpot1)
            { 
                locusSpot2 = rnd.Next(0, Parameters.GenesLength);
            }
            if (locusSpot1 < locusSpot2)
            {
                SwapGenes(ref parent1, ref parent2, ref child1, ref child2, locusSpot1, locusSpot2);
            }
            else
            {
                SwapGenes(ref parent1, ref parent2, ref child1, ref child2, locusSpot2, locusSpot1);
            }
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
        public void SwapGenes(ref Chromosome parent1, ref Chromosome parent2, ref Chromosome child1,
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
                chromosome.Genes[spot] = chromosome.Genes[spot] +
                        (rnd.NextDouble() * 2 * (Parameters.Delta) - Parameters.Delta);
            }
            return chromosome;
        }

        /// <summary>Сгенерировать начальные данные.</summary>
        /// <param name="numberOfChromosomes">Количество Особей.</param>
        /// <param name="genesLength">Количество Генов.</param>
        /// <returns>Возвращает список Особей.</returns>
        public List<Chromosome> InitializePopulation(int numberOfChromosomes, int genesLength)
        {
            List<Chromosome> chromosomeList = new List<Chromosome>();
            Parameters.GenesLength = genesLength;
            Parameters.IterationsNumber++;
            for (int i = 0; i < numberOfChromosomes; i++)
            {
                Chromosome newChromosome = CreateChromosome();
                chromosomeList.Add(newChromosome);
            }
            chromosomeList.Sort((x, y) => x.Fitness(Calculator).CompareTo(y.Fitness(Calculator)));
            BestChromosome = chromosomeList[0];
            return chromosomeList;
        }
    }
}
