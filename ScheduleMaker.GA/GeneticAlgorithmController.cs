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

        /// <summary>Шанс Мутации (0, х).</summary>
        public int MutationChance { get; set; }

        /// <summary>Конструктор.</summary>
        /// <param name="min">Минимальное значение Гена.</param>
        /// <param name="max">Максимальное значение Гена.</param>
        /// <param name="isDouble">Вещественные ли числа.</param>
        public GeneticAlgorithmController(int min, int max, int mutationChance, bool isDouble)
        {
            Min = min;
            Max = max;
            MutationChance = mutationChance;
            IsDouble = isDouble;
        }

        /// <summary>Создать Хромосому типа Int.</summary>
        /// <param name="arraySize">Количество Генов.</param>
        /// <param name="min">Минимальное значение Гена.</param>
        /// <param name="max">Максимальное значение Гена.</param>
        /// <returns>Возвращает Хромосому типа Int.</returns>
        public Chromosome CreateChromosomeInt(int arraySize)
        {
            Chromosome chromosome = new Chromosome();
            chromosome.Genes = new double[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                Roll = rnd.Next(Min, Max);
                chromosome.Genes[i] = Roll;
            }
            return chromosome;
        }

        /// <summary>Создать Хромосому типа Double.</summary>
        /// <param name="arraySize">Количество Генов.</param>
        /// <param name="min">Минимальное значение Гена.</param>
        /// <param name="max">Максимальное значение Гена.</param>
        /// <returns>Возвращает Хромосому типа Double.</returns>
        public Chromosome CreateChromosomeDouble(int arraySize)
        {
            Chromosome chromosome = new Chromosome();
            chromosome.Genes = new double[arraySize];
            for (int i = 0; i < arraySize; i++)
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
        /// <returns>Возвращает последнее поколение.</returns>
        public List<Chromosome> Crossover(List<Chromosome> chromosomeList, int times, string functionName)
        {
            List<Chromosome> result = chromosomeList;
            int length = chromosomeList.Count;

            for (int k = 0; k < times; k++)
            {
                List<Chromosome> newChromosomesList = new List<Chromosome>();
                for (int i = 0; i < length / 2; i++)
                {
                    Roll = rnd.Next(0, length);
                    if (Roll == i)
                    {
                        i--;
                    }
                    else
                    {
                        List<Chromosome> newChromosomesList2 = new List<Chromosome>();
                        newChromosomesList2 = Mapping(result[i], result[Roll]);
                        newChromosomesList.Add(newChromosomesList2[0]);
                        newChromosomesList.Add(newChromosomesList2[1]);
                    }
                }
                // Упорядочивание и замена слабой Хромосомы случайной
                newChromosomesList.Sort((x, y) => x.Fitness(functionName).CompareTo(y.Fitness(functionName)));
                if (IsDouble)
                {
                    newChromosomesList[length - 1] = CreateChromosomeDouble(chromosomeList[0].Genes.Length);
                }
                else newChromosomesList[length - 1] = CreateChromosomeInt(chromosomeList[0].Genes.Length);

                result = newChromosomesList;
            }
            return result;
        }

        /// <summary>Скрещевание двух хромосом.</summary>
        /// <param name="chromosome1">Первая хромосома.</param>
        /// <param name="chromosome2">Вторая хромосома.</param>
        /// <param name="chance">Шанс мутации Хромосомы (0, х).</param>
        /// <returns>Возвращает скрещенную особь.</returns>
        public List<Chromosome> Mapping(Chromosome chromosome1, Chromosome chromosome2)
        {
            Random rnd = new Random();
            int locusSpot;
            int length = chromosome1.Genes.Length;
            

            List<Chromosome> chromosomesList = new List<Chromosome>();
            Chromosome newChromosome1 = new Chromosome();
            Chromosome newChromosome2 = new Chromosome();
            newChromosome1.Genes = new double[length];
            newChromosome2.Genes = new double[length];

            // Выбираем Локус/Место в Хромосоме
            locusSpot = rnd.Next(0, length);

            Roll = rnd.Next(0, 2);
            if (Roll == 0)
            {
                for (int i = 0; i < locusSpot; i++)
                {
                    newChromosome1.Genes[i] = chromosome2.Genes[i];
                    newChromosome2.Genes[i] = chromosome1.Genes[i];
                }
                for (int i = locusSpot; i < length; i++)
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
                for (int i = locusSpot; i < length; i++)
                {
                    
                    newChromosome1.Genes[i] = chromosome2.Genes[i];
                    newChromosome2.Genes[i] = chromosome1.Genes[i];
                }
            }

            // Мутация
            Mutation(newChromosome1, MutationChance);
            Mutation(newChromosome2, MutationChance);
            
            chromosomesList.Add(newChromosome1);
            chromosomesList.Add(newChromosome2);
            return chromosomesList;
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

        /// <summary>Сгенерировать начальные данные.</summary>
        /// <param name="number">Количество Хромосом.</param>
        /// <param name="arraySize">Количество Генов.</param>
        /// <param name="min">Минимальное значение Гена.</param>
        /// <param name="max">Максимальное значение Гена.</param>
        /// <returns>Возвращает список Хромосом.</returns>
        public List<Chromosome> GenerateData(int number, int arraySize)
        {
            List<Chromosome> chromosomeList = new List<Chromosome>();
            if (IsDouble)
            {
                for (int i = 0; i < number; i++)
                {
                    Chromosome newChromosome = CreateChromosomeDouble(arraySize);
                    chromosomeList.Add(newChromosome);
                }
            }
            else
            {
                for (int i = 0; i < number; i++)
                {
                    Chromosome newChromosome = CreateChromosomeInt(arraySize);
                    chromosomeList.Add(newChromosome);
                }
            }
            return chromosomeList;
        }
    }
}
