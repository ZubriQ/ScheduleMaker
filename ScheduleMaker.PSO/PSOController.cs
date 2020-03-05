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
            Time = 0;
            Swarm = new List<Particle>();
        }
        
        /// <summary>
        /// Создать Рой.
        /// </summary>
        /// <param name="numberOfParticles">Количество частиц.</param>
        public void InitializeSwarm(int numberOfParticles)
        {
            Swarm.Add(CreateParticle());
            BestSwarmCondition = Swarm[0].BestKnownPosition;
            for (int i = 1; i < numberOfParticles; i++)
            {
                Swarm.Add(CreateParticle());
            }
            FindBestCondition();
        }

        /// <summary>
        /// Создать частицу.
        /// </summary>
        /// <returns>Возвращает частицу.</returns>
        private Particle CreateParticle()
        {
            double position = rnd.NextDouble() * (Parameters.Max - Parameters.Min) + Parameters.Min;
            Particle particle = new Particle(position);
            return particle;
        }

        /// <summary>
        /// Основная функция алгоритма.
        /// </summary>
        /// <param name="constantOfSpeed1">Константа скорости 1.</param>
        /// <param name="constantOfSpeed2">Константа скорости 2.</param>
        /// <param name="iterationsNumber">Количество повторений.</param>
        public void FindCriteria(double constantOfSpeed1, double constantOfSpeed2, int iterationsNumber)
        {
            while (Time < iterationsNumber)
            {
                UpdateVelocities(constantOfSpeed1, constantOfSpeed2);
                UpdatePositions();
                SetBests();
                // Вывод
                OutputParticles();
                Time++;
            }
            //OutputParticles();
        }

        /// <summary>
        /// Обновить скорости Частиц в Рое.
        /// </summary>
        /// <param name="constant1">Константа скорости 1.</param>
        /// <param name="constant2">Константа скорости 2.</param>
        private void UpdateVelocities(double constant1, double constant2)
        {
            for (int i = 0; i < Swarm.Count; i++)
            {
                double r1 = rnd.NextDouble();
                double r2 = rnd.NextDouble();
                Swarm[i].Velocity += constant1 * r1 * (Swarm[i].BestKnownPosition - Swarm[i].Position) + 
                    constant2 * r2 * (BestSwarmCondition - Swarm[i].Position);
            }
        }

        /// <summary>
        /// Обновить позиции Частиц в Рое.
        /// </summary>
        private void UpdatePositions()
        {
            for (int i = 0; i < Swarm.Count; i++)
            {
                Swarm[i].Position += Swarm[i].Velocity;
            }
        }

        /// <summary>
        /// Найти наилучшие значения для Частиц и Роя.
        /// </summary>
        private void SetBests()
        {
            FindBestParticle();
            FindBestCondition();
        }

        /// <summary>
        /// Найти наилучшие значения для Частиц.
        /// </summary>
        private void FindBestParticle()
        {
            for (int i = 0; i < Swarm.Count; i++)
            {
                if (Calculator.Fitness(Swarm[i].Position) < Calculator.Fitness(Swarm[i].BestKnownPosition))
                {
                    Swarm[i].BestKnownPosition = Swarm[i].Position;
                }
            }
        }

        /// <summary>
        /// Найти наилучшее значение для Роя.
        /// </summary>
        private void FindBestCondition()
        {
            for (int i = 0; i < Swarm.Count; i++)
            {
                if (Calculator.Fitness(Swarm[i].BestKnownPosition) < Calculator.Fitness(BestSwarmCondition))
                {
                    BestSwarmCondition = Swarm[i].BestKnownPosition;
                }
            }
        }

        public void OutputParticles()
        {
            for (int i = 0; i < Swarm.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]: pos:{Swarm[i].Position}\tvel:{Swarm[i].Velocity}\tbest:{Swarm[i].BestKnownPosition}");
            }
            Console.WriteLine($"Лучшая позиция Роя: {BestSwarmCondition}\n");
        }
    }
}
