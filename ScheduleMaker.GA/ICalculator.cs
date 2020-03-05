namespace ScheduleMaker.GA
{
    public interface ICalculator
    {
        /// <summary>Название функции.</summary>
        /// <returns>Название функции.</returns>
        string FunctionName { get; }

        /// <summary>
        /// Приспособленность особи с несколькими значениями.
        /// </summary>
        /// <param name="values">Значение.</param>
        /// <returns>Возвращает Приспособленность.</returns>
        double Fitness(double[] values);

        /// <summary>
        /// Приспособленность особи с одним значением.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Возвращает Приспособленность.</returns>
        double Fitness(double value);
    }
}
