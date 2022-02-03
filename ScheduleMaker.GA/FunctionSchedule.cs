using System;

namespace ScheduleMaker.GA
{
    // Test function
    public class FunctionSchedule : ICalculator
    {
        public string FunctionName => "Расписание";

        public double Fitness(double[] values)
        {
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += Math.Pow(values[i], 2);
            }
            return sum;
        }
    }
}
