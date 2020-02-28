using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleMaker.PS
{
    public class ParticleSwarmController
    {
        private static readonly Random rnd = new Random();

        /// <summary>Наилучшее известное состояние роя в целом.</summary>
        public static double BestSwarmCondition { get; set; }

        /// <summary>Частицы.</summary>
        public List<Particle> ParticlesList { get; set; }

        public ParticleSwarmController() { }

        public void GenerateData(int number, int maxCoordinateX, int maxSpeed)
        {
            for (int i = 0; i < number; i++)
            {
                double coordinateX = rnd.NextDouble() + rnd.Next(0, maxCoordinateX);
                double speed = rnd.NextDouble() + rnd.Next(0, maxSpeed);
                Particle particle = new Particle(coordinateX, speed);
                ParticlesList.Add(particle);
            }
        }

        public void CreateRandomVector()
        {

        }
    }
}
