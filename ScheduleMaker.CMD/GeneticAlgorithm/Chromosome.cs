using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleMaker.CMD.GeneticAlgorithm
{
    public class Chromosome
    {
        public int Gene1 { get; set; }

        public int Gene2 { get; set; }

        public int Gene3 { get; set; }

        public double Fitness()
        {
            return Gene1 + Gene2 + Gene3 / 8;
        }
    }
}
