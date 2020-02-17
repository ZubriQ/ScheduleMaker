using System;
using System.Collections.Generic;

namespace ScheduleMaker.GA
{
    public class GeneticAlgorithmController
    {
        public static Random rnd = new Random();

        public int Roll;

        public int Min { get; set; }

        public int Max { get; set; }
        /*
        public List<Chromosome> Crossover(List<Chromosome> chromosomeList, int times)
        {
            if (chromosomeList.Count % 2 != 0)
                throw new IndexOutOfRangeException("Хромосом должно быть четное кол-во");
            List<Chromosome> result = chromosomeList;

            for (int k = 0; k < times; k++)
            {
                List<Chromosome> newChromosomeList = new List<Chromosome>();
                for (int i = 0; i < chromosomeList.Count; i += 2)
                {
                    Chromosome newChromosome1 = Chromosome.Mapping(result[i], result[i + 1]);
                    Chromosome newChromosome2 = Chromosome.Mapping(result[i], result[i + 1]);
                    newChromosomeList.Add(newChromosome1);
                    newChromosomeList.Add(newChromosome2);
                }
                // Упорядочивание -ထ - +ထ
                newChromosomeList.Sort((x, y) => x.RosenbrockFitness.CompareTo(y.RosenbrockFitness));

                Chromosome bestChromosome = newChromosomeList[0];
                Array.Reverse(bestChromosome.Genes);
                newChromosomeList[chromosomeList.Count - 1] = bestChromosome;

                result = newChromosomeList;
            }
            return result;
        }*/

        public List<Chromosome> Crossover(List<Chromosome> chromosomeList, int times)
        {
            List<Chromosome> result = chromosomeList;

            for (int k = 0; k < times; k++)
            {
                List<Chromosome> newChromosomeList = new List<Chromosome>();
                for (int i = 0; i < chromosomeList.Count; i++)
                {
                    Roll = rnd.Next(0, chromosomeList.Count - 1);
                    Chromosome newChromosome = Chromosome.Mapping(result[i], result[Roll]);
                    newChromosomeList.Add(newChromosome);
                }
                // Упорядочивание -ထ - +ထ
                newChromosomeList.Sort((x, y) => x.RosenbrockFitness.CompareTo(y.RosenbrockFitness));

                /* // Инверсия и замена слабой Хромосомы
                Chromosome bestChromosome = newChromosomeList[0];
                Array.Reverse(bestChromosome.Genes);
                newChromosomeList[chromosomeList.Count - 1] = bestChromosome;*/

                
                Chromosome bestChromosome = new Chromosome();
                bestChromosome.Genes = new double[chromosomeList[0].Genes.Length];

                for (int j = 0; j < chromosomeList[0].Genes.Length; j++)
                {
                    Roll = rnd.Next(Min, Max);
                    bestChromosome.Genes[j] = Roll;
                }
                
                newChromosomeList[chromosomeList.Count - 1] = bestChromosome;


                /*
                Chromosome bestChromosome2 = new Chromosome();
                bestChromosome2.Genes = new double[chromosomeList[0].Genes.Length];

                for (int j = 0; j < chromosomeList[0].Genes.Length; j++)
                {
                    Roll = rnd.Next(Min, Max);
                    bestChromosome2.Genes[j] = Roll;
                }

                newChromosomeList[chromosomeList.Count - 2] = bestChromosome2;*/

                result = newChromosomeList;
            }
            return result;
        }

        /// <summary>Сгенерировать начальные данные.</summary>
        /// <param name="number">Количество Хромосом.</param>
        /// <param name="arraySize">Количество Генов.</param>
        /// <param name="min">Минимальное значение Гена.</param>
        /// <param name="max">Максимальное значение Гена.</param>
        /// <returns>Список хромосом.</returns>
        public List<Chromosome> GenerateData(int number, int arraySize, int min, int max)
        {
            List<Chromosome> chromosomeList = new List<Chromosome>();
            Min = min;
            Max = max;
            for (int i = 0; i < number; i++)
            {
                Chromosome newChromosome = new Chromosome();
                newChromosome.Genes = new double[arraySize];

                for (int k = 0; k < arraySize; k++)
                {
                    Roll = rnd.Next(min, max);
                    newChromosome.Genes[k] = Roll;
                }
                chromosomeList.Add(newChromosome);
            }
            return chromosomeList;
        }
    }
}
