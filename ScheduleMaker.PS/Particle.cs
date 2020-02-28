namespace ScheduleMaker.PS
{
    public class Particle
    {
        /// <summary>Координата Х.</summary>
        //public double CoordinateX { get; set; }

        /// <summary>Вектор Местоположения/Скорость?.</summary>
        public Vector Vector { get; set; }

        /// <summary>Скорость.</summary>
        public double Speed { get; set; }

        /// <summary>Лучшее из известных положений частицы.</summary>
        public double BestKnownPosition { get; set; }

        /// <summary>Конуструктор частицы.</summary>
        /// <param name="coordinateX">Координата Х.</param>
        /// <param name="speed">Скорость.</param>
        public Particle(double coordinateX, double speed)
        {
            CoordinateX = coordinateX;
            Speed = speed;
        }
    }
}
