namespace ScheduleMaker.GA
{
    public class Chromosome
    {
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
        /// <returns>Возвращает Приспособленность.</returns>
        public double Fitness(ICalculator calculator)
        {
            return calculator.Fitness(Genes);
        }
    }
}
