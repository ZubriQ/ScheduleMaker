using ScheduleMaker.GA;
using System;

namespace ScheduleMaker.PSO
{
    public class PSOController
    {
        public ICalculator Calculator { get; set; }

        private static readonly Random rnd = new Random();

        /// <summary>
        /// Наилучшее известная позиция Частицы Роя в целом.
        /// </summary>
        public Particle GlobalBestParticle { get; set; }

        /// <summary>
        /// Рой.
        /// </summary>
        public Particle[] Particles { get; set; }

        /// <summary>
        /// Параметры.
        /// </summary>
        public Parameter Parameters { get; set; }

        public PSOController(Parameter parameters, ICalculator calculator)
        {
            Parameters = parameters;
            Calculator = calculator;
            Particles = new Particle[Parameters.ParticleCount];
            GlobalBestParticle = null;
        }
        
        /// <summary>
        /// Создать Рой Частиц.
        /// </summary>
        public void InitializeParticleSwarm()
        {
            for (int i = 0; i < Parameters.ParticleCount; i++)
            {
                Particles[i] = CreateParticle();
            }
            GlobalBestParticle = Particles[0];
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
                double min = Parameters.Min * 0.1;
                double max = Parameters.Max * 0.1;
                particle.Velocity[i] = rnd.NextDouble() * (max - min) + min;
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
            int i = 0; 
            while (i < iterationsNumber)
            {
                UpdateFitnessValues();
                SetBests();
                UpdateVelocities(inertia, constantOfSpeed1, constantOfSpeed2);
                UpdatePositions();
                i++;
            }
                OutputParticles();
        }
        void UpdateFitnessValues()
        {
            for (int i = 0; i < Particles.Length; i++)
            {
                Particles[i].Fitness = Calculator.Fitness(Particles[i].Position);
            }
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
                        constant2 * r2 * (GlobalBestParticle.Position[j] - Particles[i].Position[j]);
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
                if (Particles[i].Fitness < Particles[i].BestKnownFitness)
                {
                    double[] best = new double[Parameters.DimensionSize];
                    Particles[i].Position.CopyTo(best, 0);
                    Particles[i].BestKnownPosition = best;
                    Particles[i].BestKnownFitness = Particles[i].Fitness;
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
                if (Particles[i].Fitness < GlobalBestParticle.Fitness)
                {
                    GlobalBestParticle = Particles[i];
                }
            }
        }

        /// <summary>
        /// Вывод данных.
        /// </summary>
        public void OutputParticles()
        {
            Console.WriteLine($"Лучшая позиция Роя: ");
            for (int j = 0; j < Parameters.DimensionSize; j++)
            {
                Console.Write($"{GlobalBestParticle.BestKnownPosition[j]} ");
            }
            Console.WriteLine($"Лучшее значение: {GlobalBestParticle.BestKnownFitness}");
            Console.WriteLine();
        }
    }
}
