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
        /// Наилучшее известная позиция Частицы Роя в целом.
        /// </summary>
        public Particle GlobalBestParicle { get; set; }
        /// <summary>
        /// Момент.
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Рой.
        /// </summary>
        public Particle[] Particles { get; set; }

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
            Particles = new Particle[Parameters.Count];
            GlobalBestParicle = null;
        }
        
        /// <summary>
        /// Создать Рой.
        /// </summary>
        /// <param name="numberOfParticles">Количество частиц.</param>
        public void InitializeSwarm()
        {
            for (int i = 0; i < Parameters.Count; i++)
            {
                Particles[i] = CreateParticle();
            }
            GlobalBestParicle = Particles[0];
            FindBestPosition();
        }

        /// <summary>
        /// Создать частицу.
        /// </summary>
        /// <returns>Возвращает частицу.</returns>
        private Particle CreateParticle()
        {
            Particle particle = new Particle(Parameters.DimensionSize);
            for (int i = 0; i < Parameters.DimensionSize; i++)
            {
                // Случайная позиция
                particle.Position[i] = rnd.NextDouble() * (Parameters.Max - Parameters.Min) + Parameters.Min;
                // Начальная скорость
                double lo = Parameters.Min * 0.1;
                double hi = Parameters.Max * 0.1;
                particle.Velocity[i] = rnd.NextDouble() * (hi - lo) + lo;
            }
            particle.BestKnownPosition = particle.Position;
            return particle;
        }

        /// <summary>
        /// Основная функция алгоритма.
        /// </summary>
        /// <param name="inertia">Инерция.</param>
        /// <param name="constantOfSpeed1">Константа скорости 1.</param>
        /// <param name="constantOfSpeed2">Константа скорости 2.</param>
        /// <param name="iterationsNumber">Количество повторений.</param>
        public void FindGlobalMinimum(double inertia, double constantOfSpeed1, double constantOfSpeed2, int iterationsNumber)
        {
            while (Time < iterationsNumber)
            {
                UpdateVelocities(inertia, constantOfSpeed1, constantOfSpeed2);
                UpdatePositions();
                // TODO: update Calculations
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
        /// <param name="intertia">Инерция.</param>
        /// <param name="constant1">Константа скорости 1.</param>
        /// <param name="constant2">Константа скорости 2.</param>
        private void UpdateVelocities(double intertia, double constant1, double constant2)
        {
            for (int i = 0; i < Particles.Length; i++)
            {
                for (int j = 0; j < Parameters.DimensionSize; j++)
                {
                    double r1 = rnd.NextDouble();
                    double r2 = rnd.NextDouble();
                    Particles[i].Velocity[j] = intertia * Particles[i].Velocity[j] +
                        constant1 * r1 * (Particles[i].BestKnownPosition[j] - Particles[i].Position[j]) +
                        constant2 * r2 * (GlobalBestParicle.Position[j] - Particles[i].Position[j]);
                }
            }
        }

        /// <summary>
        /// Обновить позиции Частиц в Рое.
        /// </summary>
        private void UpdatePositions()
        {
            for (int i = 0; i < Particles.Length; i++)
            {
                for (int j = 0; j < Parameters.DimensionSize; j++)
                {
                    Particles[i].Position[j] += Particles[i].Velocity[j];
                }
            }
        }

        /// <summary>
        /// Найти наилучшие значения для Частиц и Роя.
        /// </summary>
        private void SetBests()
        {
            FindPersonalBests();
            FindBestPosition();
        }

        /// <summary>
        /// Найти наилучшие значения для Частиц.
        /// </summary>
        private void FindPersonalBests()
        {
            for (int i = 0; i < Particles.Length; i++)
            {
                double currentFitness = Calculator.Fitness(Particles[i].Position);
                if (currentFitness < Particles[i].Fitness)
                {
                    Particles[i].BestKnownPosition = Particles[i].Position;
                    Particles[i].Fitness = currentFitness;
                }
            }
        }

        /// <summary>
        /// Найти наилучшее значение для Роя.
        /// </summary>
        private void FindBestPosition()
        {
            for (int i = 0; i < Particles.Length; i++)
            {
                double currentFitness = Calculator.Fitness(Particles[i].Position);
                if (currentFitness < GlobalBestParicle.Fitness)
                {
                    GlobalBestParicle.Position = Particles[i].BestKnownPosition;
                    GlobalBestParicle.Fitness = currentFitness;
                }
            }
        }

        /// <summary>
        /// Вывод данных.
        /// </summary>
        public void OutputParticles()
        {
            /*
            for (int i = 0; i < Swarm.Count; i++)
            {
                
                Console.WriteLine($"[{i + 1}]: pos:");
                // Позиции
                for (int j = 0; j < Parameters.DimensionsNumber; j++)
                {
                    Console.Write($"{Swarm[i].Position[j]} ");
                }
                // Скорости
                Console.WriteLine("\tvel: ");
                for (int j = 0; j < Parameters.DimensionsNumber; j++)
                {
                    Console.Write($"{Swarm[i].Velocity[j]} ");
                }
                //Лучшее
                Console.WriteLine("\tbest: ");
                for (int j = 0; j < Parameters.DimensionsNumber; j++)
                {
                    Console.Write($"{Swarm[i].BestKnownPosition[j]} ");
                }
                
            }
            */
            Console.WriteLine($"Лучшая позиция Роя: ");
            for (int j = 0; j < Parameters.DimensionSize; j++)
            {
                Console.Write($"{GlobalBestParicle.Position[j]} ");
            }
            Console.WriteLine();
        }
    }
}
