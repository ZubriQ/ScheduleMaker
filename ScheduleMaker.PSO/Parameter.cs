namespace ScheduleMaker.PSO
{
    public class Parameter
    {
        /// <summary>
        /// Минимальное значение Частицы.
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// Максимальное значение Частицы.
        /// </summary>
        public int Max { get; set; }
        
        /// <summary>
        /// Количество Частиц.
        /// </summary>
        public int ParticleCount { get; set; }

        /// <summary>
        /// Количество измерений.
        /// </summary>
        public int DimensionSize { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="min">Минимальное значение Вектора.</param>
        /// <param name="max">Максимальное значение Вектора.</param>
        /// <param name="dimensionsNumber">Количество измерений.</param>
        public Parameter(int min, int max, int count, int dimensionsNumber)
        {
            Min = min;
            Max = max;
            DimensionSize = dimensionsNumber;
            ParticleCount = count;
        }
    }
}