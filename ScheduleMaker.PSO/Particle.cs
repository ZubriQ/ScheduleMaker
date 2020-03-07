namespace ScheduleMaker.PSO
{
    public class Particle
    {
        /// <summary>
        /// Позиция.
        /// </summary>
        public double[] Position { get; set; }

        /// <summary>
        /// Скорость.
        /// </summary>
        public double[] Velocity { get; set; }

        /// <summary>
        /// Лучшее из известных положений частицы.
        /// </summary>
        public double[] BestKnownPosition { get; set; }

        public double BestKnownFitness { get; set; } = double.MaxValue;
        
        /// <summary>
        /// Приспособленность.
        /// </summary>
        public double Fitness { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dimensionCount">Количество измерений.</param>
        public Particle(int dimensionCount)
        {
            Position = new double[dimensionCount];
            Velocity = new double[dimensionCount];
            BestKnownPosition = new double[dimensionCount];
            Fitness = double.MaxValue;
        }
    }
}
