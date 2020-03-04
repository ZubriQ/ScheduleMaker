using ScheduleMaker.GA;
using System;
using System.Collections.Generic;

namespace ScheduleMaker.PSO
{
    public class PSOController
    {
        public ICalculator Calculator { get; set; }

        private static readonly Random rnd = new Random();

        /// <summary>
        /// Наилучшее известное состояние Роя в целом.
        /// </summary>
        public double BestSwarmCondition { get; set; }
        
        /// <summary>
        /// Момент.
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Рой.
        /// </summary>
        public List<Particle> Swarm { get; set; }

        /// <summary>
        /// Параметры.
        /// </summary>
        public Parameter Parameters { get; set; }

        public PSOController() { }

        public PSOController(Parameter parameters, ICalculator calculator)
        {
            Parameters = parameters;
            Calculator = calculator;
        }
        
        public void InitializeSwarm(int numberOfParticles)
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                Swarm.Add(CreateParticle());
                if (Swarm[i].BestKnownPosition < BestSwarmCondition)
                {
                    BestSwarmCondition = Swarm[i].BestKnownPosition;
                }
            }
        }

        private Particle CreateParticle()
        {
            double position = rnd.NextDouble() * (Parameters.Max - Parameters.Min) + Parameters.Min;
            Particle particle = new Particle(position);
            return particle;
        }

        private void MoveParticles()
        {
            for (int i = 0; i < Swarm.Count; i++)
            {
                //Swarm[i].Position = Swarm[i].Position + 
            }
            Time++;
        }

        public void CreateRandomVector()
        {

        }
    }
}
