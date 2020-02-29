namespace ScheduleMaker.GA
{
    public interface ICalculator
    {
        /// <summary>Название функции.</summary>
        /// <returns>Название функции.</returns>
        string FunctionName { get; }

        /// <summary>Приспособленность особи.</summary>
        /// <param name="value">Значение.</param>
        /// <returns>Приспособленность особи.</returns>
        double Fitness(double[] values);
    }
}
