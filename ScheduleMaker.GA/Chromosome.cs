using System;

namespace ScheduleMaker.GA
{
    public class Chromosome
    {
        //TODO : Переместить Fitness-функции в Контроллер? :thinking:
        /// <summary>Гены.</summary>
        public double[] Genes { get; set; }

        public Chromosome() { }

        /// <summary>Конструктор.</summary>
        /// <param name="genes">Параметры хромосом.</param>
        public Chromosome(double[] genes)
        {
            Genes = genes;
        }

        /// <summary>Приспособленность.</summary>
        /// <param name="name">Розенброк/Сфера/Растригин.</param>
        /// <returns>Возвращает Приспособленность.</returns>
        public double Fitness(string name)
        {
            if (name == "Розенброк") return Rosenbrock(Genes);
            else if (name == "Сфера") return Sphere(Genes);
            else if (name == "Растригин") return Rastrigin(Genes);
            else throw new Exception("Неверное название функции");
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

        public static double Rastrigin(double[] numbers)
        {
            double sum = 0;
            for (int i = 0; i<numbers.Length; i++)
            {
                sum += Math.Pow(numbers[i], 2) - 10 * Math.Cos(2 * Math.PI * numbers[i]);
            }
            return sum + 10 * numbers.Length;
        }
    }
}
