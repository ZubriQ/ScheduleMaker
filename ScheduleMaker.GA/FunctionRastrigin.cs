using System;

namespace ScheduleMaker.GA
{
    public class FunctionRastrigin : ICalculator
    {
        public string FunctionName => "Растригин";

        public double Fitness(double[] values)
        {
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += Math.Pow(values[i], 2) - 10 * Math.Cos(2 * Math.PI * values[i]);
            }
            return sum + 10 * values.Length;
        }

        public double Fitness(double value)
        {
            double result = Math.Pow(value, 2) - 10 * Math.Cos(2 * Math.PI * value);
            return result;
        }
    }
}
