using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleMaker.GA
{
    public class GeneticAlgorithmController
    {
        private static readonly Random rnd = new Random();

        /// <summary>Случайное число</summary>
        public int Roll { get; set; }

        /// <summary>Минимальное значение Roll'а</summary>
        public int Min { get; set; }

        /// <summary>Максимальное значение Roll'а</summary>
        public int Max { get; set; }

        /// <summary>Вещественные ли числа.</summary>
        public bool IsDouble { get; set; }

        /// <summary>Шанс мутации (0, х).</summary>
        public int MutationChance { get; set; }

        /// <summary>Количество генов.</summary>
        public int GenesLength { get; set; }

        /// <summary>Конструктор.</summary>
        /// <param name="min">Минимальное значение Гена.</param>
        /// <param name="max">Максимальное значение Гена.</param>
        /// <param name="mutationChance">Шанс мутации (0, х).</param>
        /// <param name="isDouble">Вещественные ли числа.</param>
        public GeneticAlgorithmController(int min, int max, int mutationChance, bool isDouble)
        {
            Min = min;
            Max = max;
            MutationChance = mutationChance;
            IsDouble = isDouble;
        }

        /// <summary>Создать Хромосому типа Int.</summary>
        /// <returns>Возвращает Хромосому типа Int.</returns>
        public Chromosome CreateChromosomeInt()
        {
            Chromosome chromosome = new Chromosome();
            chromosome.Genes = new double[GenesLength];
            for (int i = 0; i < GenesLength; i++)
            {
                Roll = rnd.Next(Min, Max);
                chromosome.Genes[i] = Roll;
            }
            return chromosome;
        }

        /// <summary>Создать Хромосому типа Double.</summary>
        /// <returns>Возвращает Хромосому типа Double.</returns>
        public Chromosome CreateChromosomeDouble()
        {
            Chromosome chromosome = new Chromosome();
            chromosome.Genes = new double[GenesLength];
            for (int i = 0; i < GenesLength; i++)
            {
                double gene = rnd.NextDouble() * (Max - Min) + Min;
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
        public List<Chromosome> Crossover(List<Chromosome> chromosomeList, int times, string functionName, int delta)
        {
            List<Chromosome> result = chromosomeList;
            int chromosomesCount = chromosomeList.Count;

            for (int k = 0; k < times; k++)
            {
                List<Chromosome> newChromosomesList = new List<Chromosome>();
                for (int i = 0; i < chromosomesCount / 2; i++)
                {
                    int chromosome2 = rnd.Next(0, chromosomesCount);
                    if (i == chromosome2)
                    {
                        i--;
                    }
                    else
                    {
                        newChromosomesList.AddRange(Mapping(result[i], result[chromosome2], delta));
                    }
                }
                // Упорядочивание и замена слабой Хромосомы случайной
                newChromosomesList.Sort((x, y) => x.Fitness(functionName).CompareTo(y.Fitness(functionName)));
                
                if (IsDouble)
                    newChromosomesList[GenesLength - 1] = CreateChromosomeDouble();
                else
                    newChromosomesList[GenesLength - 1] = CreateChromosomeInt();

                result = newChromosomesList;
            }
            return result;
        }

        /// <summary>Скрещевание двух Хромосом.</summary>
        /// <param name="chromosome1">Первая Хромосома.</param>
        /// <param name="chromosome2">Вторая Хромосома.</param>
        /// <param name="delta">Возможное смещение значения Гена (± дельта).</param>
        /// <returns>Возвращает скрещенную Хромосому.</returns>
        public List<Chromosome> Mapping(Chromosome chromosome1, Chromosome chromosome2, int delta)
        {
            List<Chromosome> chromosomesList = new List<Chromosome>();
            Chromosome newChromosome1;
            Chromosome newChromosome2;

            // Обмен генами
            Panmixia(chromosome1, chromosome2, out newChromosome1, out newChromosome2);

            Mutation(newChromosome1, MutationChance, delta);
            Mutation(newChromosome2, MutationChance, delta);

            chromosomesList.Add(newChromosome1);
            chromosomesList.Add(newChromosome2);
            return chromosomesList;
        }

        /// <summary>Алгоритм картирования/обмена генов.</summary>
        /// <param name="chromosome1">Родитель 1.</param>
        /// <param name="chromosome2">Родитель 2.</param>
        /// <param name="newChromosome1">Потомок 1.</param>
        /// <param name="newChromosome2">Потомок 2.</param>
        public void Panmixia(
            Chromosome chromosome1, Chromosome chromosome2, out Chromosome newChromosome1, out Chromosome newChromosome2)
        {
            int locusSpot = rnd.Next(0, GenesLength);
            newChromosome1 = new Chromosome();
            newChromosome2 = new Chromosome();
            newChromosome1.Genes = new double[GenesLength];
            newChromosome2.Genes = new double[GenesLength];

            Roll = rnd.Next(0, 2);
            if (Roll == 0)
            {
                for (int i = 0; i < locusSpot; i++)
                {
                    newChromosome1.Genes[i] = chromosome2.Genes[i];
                    newChromosome2.Genes[i] = chromosome1.Genes[i];
                }
                for (int i = locusSpot; i < GenesLength; i++)
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
                for (int i = locusSpot; i < GenesLength; i++)
                {
                    newChromosome1.Genes[i] = chromosome2.Genes[i];
                    newChromosome2.Genes[i] = chromosome1.Genes[i];
                }
            }
        }

        /// <summary>Мутация случайного гена.</summary>
        /// <param name="chromosome">Хромосома.</param>
        /// <param name="chance">Шанс мутации Хромосомы (0, x).</param>
        /// <returns>Возвращает Хромосому.</returns>
        public Chromosome Mutation(Chromosome chromosome, int chance)
        {
            Roll = rnd.Next(0, chance);
            if (Roll == 0)
            {
                if (IsDouble)
                {
                    double newGene = rnd.NextDouble() * (Min - Max) + Min;
                    int spot = rnd.Next(0, chromosome.Genes.Length);
                    chromosome.Genes[spot] = newGene;
                }
                else
                {
                    Roll = rnd.Next(Min, Max);
                    int spot = rnd.Next(0, chromosome.Genes.Length);
                    chromosome.Genes[spot] = Roll;
                }
            }
            return chromosome;
        }

        /// <summary>Мутация.</summary>
        /// <param name="chromosome">Хромосома.</param>
        /// <param name="chance">Шанс мутации Хромосомы (0, x).</param>
        /// <param name="delta">Возможное смещение значения Гена (± дельта).</param>
        /// <returns>Возвращает мутированную или неизмененную Хромосому.</returns>
        public Chromosome Mutation(Chromosome chromosome, int chance, int delta)
        {
            Roll = rnd.Next(0, chance);
            int spot = rnd.Next(0, chromosome.Genes.Length);
            if (Roll == 0)
            {
                if (IsDouble)
                {
                    Roll = rnd.Next(0, 2);
                    if (Roll == 0)
                    {
                        chromosome.Genes[spot] = chromosome.Genes[spot] + rnd.NextDouble() * (delta - 1) + delta;
                    }
                    else
                    {
                        chromosome.Genes[spot] = chromosome.Genes[spot] - rnd.NextDouble() * (delta - 1) + delta;
                    }
                }
                else
                {
                    Roll = rnd.Next(0, 2);
                    if (Roll == 0)
                    {
                        chromosome.Genes[spot] = chromosome.Genes[spot] + rnd.Next(1, delta + 1);
                    }
                    else
                    {
                        chromosome.Genes[spot] = chromosome.Genes[spot] - rnd.Next(1, delta + 1);
                    }
                }
            }
            return chromosome;
        }

        /// <summary>Сгенерировать начальные данные.</summary>
        /// <param name="number">Количество Хромосом.</param>
        /// <param name="arraySize">Количество Генов.</param>
        /// <returns>Возвращает список Хромосом.</returns>
        public List<Chromosome> GenerateData(int number, int arraySize)
        {
            List<Chromosome> chromosomeList = new List<Chromosome>();
            GenesLength = arraySize;
            if (IsDouble)
            {
                for (int i = 0; i < number; i++)
                {
                    Chromosome newChromosome = CreateChromosomeDouble();
                    chromosomeList.Add(newChromosome);
                }
            }
            else
            {
                for (int i = 0; i < number; i++)
                {
                    Chromosome newChromosome = CreateChromosomeInt();
                    chromosomeList.Add(newChromosome);
                }
            }
            return chromosomeList;
        }

        // Случайные особи со случайными особями 
        public List<Chromosome> Crossover2(List<Chromosome> chromosomeList, int times, string functionName, int delta)
        {
            List<Chromosome> result = chromosomeList;
            int chromosomesCount = chromosomeList.Count;

            for (int k = 0; k < times; k++)
            {
                List<Chromosome> newChromosomesList = new List<Chromosome>();
                for (int i = 0; i < chromosomesCount / 2; i++)
                {
                    // Выбираются случайные особи
                    int chromosome1 = rnd.Next(0, chromosomesCount);
                    int chromosome2 = rnd.Next(0, chromosomesCount);
                    if (chromosome1 == chromosome2)
                    {
                        i--;
                    }
                    else
                    {
                        newChromosomesList.AddRange(Mapping(result[chromosome1], result[chromosome2], delta));
                    }
                }
                // Упорядочивание и замена слабой Хромосомы случайной
                newChromosomesList.Sort((x, y) => x.Fitness(functionName).CompareTo(y.Fitness(functionName)));

                if (IsDouble)
                    newChromosomesList[GenesLength - 1] = CreateChromosomeDouble();
                else
                    newChromosomesList[GenesLength - 1] = CreateChromosomeInt();

                result = newChromosomesList;
            }
            return result;
        }
    }
}
