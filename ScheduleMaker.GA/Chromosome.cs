using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleMaker.GA
{
    public class Chromosome
    {
        /// <summary>Гены.</summary>
        public double[] Genes { get; set; }

        public Chromosome() { }

        /// <summary>Создать хромосому.</summary>
        /// <param name="genes">Параметры хромосом</param>
        public Chromosome(double[] genes)
        {
            Genes = genes;
        }

        /// <summary>Для упорядочивания по приспособленности</summary>
        public double RosenbrockFitness
        {
            get
            {
                return Rosenbrock(Genes);
            }
        }

        /// <summary>Для порядочивания по приспособленности</summary>
        public double SphereFitness
        {
            get
            {
                return Rosenbrock(Genes);
            }
        }

        /// <summary>Создание новой хромосомы.</summary>
        /// <param name="chromosome1">Первая хромосома.</param>
        /// <param name="chromosome2">Вторая хромосома.</param>
        /// <returns></returns>
        public static Chromosome Mapping(Chromosome chromosome1, Chromosome chromosome2)
        {
            Random rnd = new Random();
            int roll;

            Chromosome newChromosome = new Chromosome();
            newChromosome.Genes = new double[chromosome1.Genes.Length];

            for (int i = 0; i < chromosome1.Genes.Length; i++)
            {
                roll = rnd.Next(0, 2);
                if (roll == 0)
                {
                    newChromosome.Genes[i] = chromosome1.Genes[i];
                }
                else newChromosome.Genes[i] = chromosome2.Genes[i];
            }
            return newChromosome;
        }

        public static double Rosenbrock(double[] numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                sum += 100 * Math.Pow(numbers[i + 1] - Math.Pow(numbers[i], 2), 2)
                    + Math.Pow(numbers[i] - 1, 2);
            }
            return sum;
        }

        public static double Sphere(double[] numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += Math.Pow(numbers[i], 2);
            }
            return sum;
        }
    }
}
