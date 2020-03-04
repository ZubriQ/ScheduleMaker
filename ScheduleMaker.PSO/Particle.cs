namespace ScheduleMaker.PSO
{
    public class Particle
    {
        /// <summary>
        /// Позиция.
        /// </summary>
        public double Position { get; set; } // TODO: Должен быть массив как и с генами?

        /// <summary>
        /// Скорость.
        /// </summary>
        public double Velocity { get; set; }

        /// <summary>Лучшее из известных положений частицы.</summary>
        public double BestKnownPosition { get; set; }

        /// <summary>Конуструктор частицы.</summary>
        /// <param name="coordinateX">Координата Х.</param>
        /// <param name="speed">Скорость.</param>
        public Particle(double position)
        {
            Position = position;
            BestKnownPosition = position;
        }
    }
}
