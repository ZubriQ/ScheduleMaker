using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleMaker.GA
{
    public class GeneticAlgorithmController
    {
        public static Random rnd = new Random();

        /// <summary>Случайное число</summary>
        public int Roll { get; set; }

        /// <summary>Минимальное значение Roll'а</summary>
        public int Min { get; set; }

        /// <summary>Максимальное значение Roll'а</summary>
        public int Max { get; set; }

        /// <summary>Вещественные ли числа.</summary>
        public bool IsDouble { get; set; }

        /// <summary>Конструктор.</summary>
        /// <param name="min">Минимальное значение Гена.</param>
        /// <param name="max">Максимальное значение Гена.</param>
        /// <param name="isDouble">Вещественные ли числа.</param>
        public GeneticAlgorithmController(int min, int max, bool isDouble)
        {
            Min = min;
            Max = max;
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
                double gene = rnd.NextDouble() * (Max - Min);
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

            for (int k = 0; k < times; k++)
            {
                List<Chromosome> newChromosomeList = new List<Chromosome>();
                for (int i = 0; i < chromosomeList.Count; i++)
                {
                    Roll = rnd.Next(0, chromosomeList.Count - 1);
                    if (Roll == i)
                    {
                        i--;
                    }
                    else
                    {
                        Chromosome newChromosome = Mapping(result[i], result[Roll]);
                        newChromosomeList.Add(newChromosome);
                    }
                }
                // Упорядочивание и замена слабой Хромосомы случайной
                newChromosomeList.Sort((x, y) => x.Fitness(functionName).CompareTo(y.Fitness(functionName)));
                if (IsDouble)
                {
                    newChromosomeList[chromosomeList.Count - 1] = CreateChromosomeDouble(chromosomeList[0].Genes.Length);
                }
                else newChromosomeList[chromosomeList.Count - 1] = CreateChromosomeInt(chromosomeList[0].Genes.Length);

                result = newChromosomeList;
            }
            return result;
        }

        /// <summary>Скрещевание двух хромосом.</summary>
        /// <param name="chromosome1">Первая хромосома.</param>
        /// <param name="chromosome2">Вторая хромосома.</param>
        /// <returns>Возвращает скрещенную особь.</returns>
        public Chromosome Mapping(Chromosome chromosome1, Chromosome chromosome2)
        {
            Random rnd = new Random();
            int locusSpot, roll;

            Chromosome newChromosome = new Chromosome();
            newChromosome.Genes = new double[chromosome1.Genes.Length];

            // Выбираем Локус/Место в Хромосоме
            locusSpot = rnd.Next(0, chromosome1.Genes.Length);

            roll = rnd.Next(0, 2);
            if (roll == 0)
            {
                for (int i = 0; i < locusSpot; i++)
                {
                    newChromosome.Genes[i] = chromosome1.Genes[i];
                }
                for (int i = locusSpot; i < chromosome1.Genes.Length; i++)
                {
                    newChromosome.Genes[i] = chromosome2.Genes[i];
                }
            }
            else
            {
                for (int i = 0; i < locusSpot; i++)
                {
                    newChromosome.Genes[i] = chromosome2.Genes[i];
                }
                for (int i = locusSpot; i < chromosome1.Genes.Length; i++)
                {
                    newChromosome.Genes[i] = chromosome1.Genes[i];
                }
            }

            // Мутация
            roll = rnd.Next(0, 2);
            if (roll == 0)
            {
                int spot = rnd.Next(0, chromosome1.Genes.Length);

                if (IsDouble)
                {
                    double newGene = rnd.NextDouble() * (Min - Max);
                    newChromosome.Genes[spot] = newGene;
                }
                else
                {
                    Roll = rnd.Next(Min, Max);
                    newChromosome.Genes[spot] = Roll;
                }
            }

            return newChromosome;
        }

        /// <summary>Кроссовер.</summary>
        /// <param name="chromosomeList">Список Хромосом.</param>
        /// <param name="times">Количество итераций.</param>
        /// <param name="functionName">Название функции.</param>
        /// <returns>Возвращает последнее поколение.</returns>
        public List<Chromosome> CrossoverTest(List<Chromosome> chromosomeList, int times, string functionName)
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
                        newChromosomesList2 = MappingTest(result[i], result[Roll]);
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
        /// <returns>Возвращает скрещенную особь.</returns>
        public List<Chromosome> MappingTest(Chromosome chromosome1, Chromosome chromosome2)
        {
            Random rnd = new Random();
            int locusSpot, roll, spot;
            int length = chromosome1.Genes.Length;
            

            List<Chromosome> chromosomesList = new List<Chromosome>();
            Chromosome newChromosome1 = new Chromosome();
            Chromosome newChromosome2 = new Chromosome();
            newChromosome1.Genes = new double[length];
            newChromosome2.Genes = new double[length];

            // Выбираем Локус/Место в Хромосоме
            locusSpot = rnd.Next(0, length);

            roll = rnd.Next(0, 2);
            if (roll == 0)
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

            
            // Мутация 1
            roll = rnd.Next(0, 7);
            if (roll == 0)
            {
                if (IsDouble)
                {
                    double newGene = rnd.NextDouble() * (Min - Max);
                    spot = rnd.Next(0, chromosome1.Genes.Length);
                    newChromosome1.Genes[spot] = newGene;
                }
                else
                {
                    Roll = rnd.Next(Min, Max);
                    spot = rnd.Next(0, chromosome1.Genes.Length);
                    newChromosome1.Genes[spot] = Roll;
                }
            }

            // Мутация 2
            roll = rnd.Next(0, 7);
            if (roll == 0)
            {
                if (IsDouble)
                {
                    double newGene = rnd.NextDouble() * (Min - Max);
                    spot = rnd.Next(0, chromosome1.Genes.Length);
                    newChromosome2.Genes[spot] = newGene;
                }
                else
                {
                    Roll = rnd.Next(Min, Max);
                    spot = rnd.Next(0, chromosome1.Genes.Length);
                    newChromosome2.Genes[spot] = Roll;
                }
            }
            
            chromosomesList.Add(newChromosome1);
            chromosomesList.Add(newChromosome2);
            return chromosomesList;
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
