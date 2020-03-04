namespace ScheduleMaker.PSO
{
    public class Parameter
    {
        /// <summary>
        /// Минимальное значение Вектора.
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// Максимальное значение Вектора.
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="min">Минимальное значение Вектора.</param>
        /// <param name="max">Максимальное значение Вектора.</param>
        public Parameter(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}
