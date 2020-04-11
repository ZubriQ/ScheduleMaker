namespace ScheduleMaker.GA
{
    public class Param
    {
        /// <summary>
        /// Минимальное значение Гена.
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// Максимальное значение Гена.
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// Количество Генов.
        /// </summary>
        public int GenesLength { get; set; }

        /// <summary>
        /// Шанс мутации.
        /// </summary>
        public double MutationChance { get; set; }

        /// <summary>
        /// Возможное смещение значения Гена (± дельта).
        /// </summary>
        public int Delta { get; set; }

        /// <summary>
        /// Количество поколений.
        /// </summary>
        public int IterationsNumber { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="min">Минимальное значение Гена.</param>
        /// <param name="max">Максимальное значение Гена.</param>
        /// <param name="genesLength">Количество Генов.</param>
        /// <param name="mutationChance">Шанс мутации.</param>
        /// <param name="delta">Возможное смещение значения Гена (± дельта).</param>
        public Param(int min, int max, int genesLength, double mutationChance, int delta)
        {
            Min = min;
            Max = max;
            GenesLength = genesLength;
            MutationChance = mutationChance;
            Delta = delta;
            IterationsNumber = 0;
        }
    }
}
