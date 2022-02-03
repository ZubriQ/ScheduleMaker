using System;

namespace ScheduleMaker.GA
{
    // Test function
    public class FunctionRosenbrock : ICalculator
    {
        public string FunctionName => "Розенброк";

        public double Fitness(double[] values)
        {
            double sum = 0;
            for (int i = 0; i < values.Length - 1; i++)
            {
                sum += 100 * Math.Pow(values[i + 1] - Math.Pow(values[i], 2), 2)
                    + Math.Pow(values[i] - 1, 2);
            }
            return sum;
        }
    }
}
