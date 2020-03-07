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

        /// <summary>
        /// Лучшая приспособленность за все время.
        /// </summary>
        public double BestKnownFitness { get; set; } 
        
        /// <summary>
        /// Приспособленность.
        /// </summary>
        public double Fitness { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dimensionSize">Количество измерений.</param>
        public Particle(int dimensionSize)
        {
            Position = new double[dimensionSize];
            Velocity = new double[dimensionSize];
            BestKnownPosition = new double[dimensionSize];
            Fitness = double.MaxValue;
            BestKnownFitness = double.MaxValue;
        }
    }
}
