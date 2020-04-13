namespace ScheduleMaker.GA
{
    public interface ICalculator
    {
        /// <summary>
        /// Приспособленность особи с несколькими значениями.
        /// </summary>
        /// <param name="values">Значения.</param>
        /// <returns>Возвращает Приспособленность.</returns>
        double Fitness(double[] values);
    }
}
