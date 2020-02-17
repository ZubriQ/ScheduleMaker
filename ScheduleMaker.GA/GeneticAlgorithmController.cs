using System;
using System.Collections.Generic;

namespace ScheduleMaker.GA
{
    public class GeneticAlgorithmController
    {
        public static Random rnd = new Random();

        public int Roll { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        /// <summary>Кроссовер</summary>
        /// <param name="chromosomeList">Список Хромосом</param>
        /// <param name="times">Количество итераций</param>
        /// <returns>Возвращает последнее поколение.</returns>
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
                
                newChromosomeList[chromosomeList.Count - 1] = CreateChromosome(chromosomeList[0].Genes.Length);

                result = newChromosomeList;
            }
            return result;
        }

        /// <summary>Сгенерировать начальные данные.</summary>
        /// <param name="number">Количество Хромосом.</param>
        /// <param name="arraySize">Количество Генов.</param>
        /// <param name="min">Минимальное значение Гена.</param>
        /// <param name="max">Максимальное значение Гена.</param>
        /// <returns>Возвращает список Хромосом.</returns>
        public List<Chromosome> GenerateData(int number, int arraySize, int min, int max)
        {
            List<Chromosome> chromosomeList = new List<Chromosome>();
            Min = min;
            Max = max;
            for (int i = 0; i < number; i++)
            {
                Chromosome newChromosome = CreateChromosome(arraySize);
                chromosomeList.Add(newChromosome);
            }
            return chromosomeList;
        }

        /// <summary></summary>
        /// <param name="arraySize">Количество Генов.</param>
        /// <returns>Возвращает Хромосому.</returns>
        public Chromosome CreateChromosome(int arraySize)
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
    }
}
