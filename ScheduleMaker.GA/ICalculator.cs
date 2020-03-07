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
        /// <param name="values">Значения.</param>
        /// <returns>Возвращает Приспособленность.</returns>
        double Fitness(double[] values);
    }
}
