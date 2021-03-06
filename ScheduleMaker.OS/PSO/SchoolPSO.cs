using ScheduleMaker.ADO;
using ScheduleMaker.GA;
using ScheduleMaker.OS.School;
using ScheduleMaker.PSO;
using System;
using System.Collections.Generic;

namespace ScheduleMaker.OS.PSO
{
    public class SchoolPSO : ICalculator
    {
        /// <summary>
        /// Данные для создания расписаний.
        /// </summary>
        public ScheduleData ScheduleData;

        /// <summary>
        /// Констурктор расписаний.
        /// </summary>
        public ScheduleConstructor ScheduleConstructor;
        
        /// <summary>
        /// Оценщик расписаний.
        /// </summary>
        public ScheduleEvaluator ScheduleEvaluator;

        /// <summary>
        /// PSO.
        /// </summary>
        public PSOController PSOController;
        public GeneticAlgorithmController GAC;

        public Machine[] Teachers => ScheduleData.Teachers;

        /// <summary>
        /// Оценочный балл
        /// </summary>
        public double EstimationScore = Double.MaxValue;

        public SchoolPSO() 
        {
            ScheduleConstructor = new ScheduleConstructor();
            ScheduleEvaluator = new ScheduleEvaluator();
        }

        /// <summary>
        /// Фитнесс функция.
        /// </summary>
        /// <param name="calculator">Фитнесс функция.</param>
        public void SetFunction(ICalculator calculator)
        {
            Parameter parameters = new Parameter(-300, 300, 50, ScheduleData.LessonsCount);
            PSOController = new PSOController(parameters, calculator);

            // Genetic algorithm
            //Param param = new Param(-150, 150, ScheduleData.LessonsCount, 0.75, 5);
            //GAC = new GeneticAlgorithmController(param, calculator);
        }

        /// <summary>
        /// Конвертация под данные алгоритма и назначение данных
        /// </summary>
        /// <param name="teachers">Учителя</param>
        /// <param name="classrooms">Кабинеты</param>
        /// <param name="syllabi">Учебные планы</param>
        public void SetData(List<Teachers> teachers, List<Classrooms> classrooms, List<Syllabus> syllabi)
        {
            ScheduleData = new ScheduleData(ConvertTeachers(teachers),
                                            ConvertClassrooms(classrooms),
                                            syllabi);
        }

        /// <summary>
        /// Конвертация учителей БД в учителей алгоритма
        /// </summary>
        /// <param name="teachers">Учителя (БД)</param>
        /// <returns>Учителя (SchoolShop)</returns>
        private Machine[] ConvertTeachers(List<Teachers> teachers)
        {
            Machine[] machines = new Machine[teachers.Count];
            for (int t = 0; t < machines.Length; t++)
            {
                // Добавление уроков, которые может вести учитель
                Subject[] subjects = new Subject[teachers[t].Subjects.Count];
                int i = 0;
                foreach (var s in teachers[t].Subjects)
                {
                    Subject subject = new Subject(s.subject_id, s.name, Convert.ToInt32(s.difficulty));
                    subjects[i] = subject;
                    i++;
                }
                machines[t] = new Machine(teachers[t].teacher_id, subjects);
            }
            return machines;
        }

        /// <summary>
        /// Конверация кабинетов БД в кабинеты алгоритма
        /// </summary>
        /// <param name="classrooms">Кабинеты (БД)</param>
        /// <returns>Кабинеты (SchoolShop)</returns>
        private List<Classroom> ConvertClassrooms(List<Classrooms> classrooms)
        {
            List<Classroom> classroomsList = new List<Classroom>();
            for (int c = 0; c < classrooms.Count; c++)
            {
                // Добавление уроков, которые допускаются в кабинете
                Subject[] subjects = new Subject[classrooms[c].Subjects.Count];
                int i = 0;
                foreach (var s in classrooms[c].Subjects)
                {
                    Subject subject = new Subject(s.subject_id, s.name, 
                                                  Convert.ToInt32(s.difficulty));
                    subjects[i] = subject;
                    i++;
                }
                classroomsList.Add(new Classroom(classrooms[c].classroom_id, 
                                                 classrooms[c].name, subjects));
            }
            return classroomsList;
        }

        /// <summary>
        /// Найти лучшие приоритеты для вектора уроков.
        /// </summary>
        /// <returns>Возвращает наилучшие приоритеты расположения уроков.</returns>
        public double[] FindBestPriorities()
        {
            // Genetic algorithm
            /*
            GAC.InitializePopulation(120);
            GAC.Evolution(400);
            EstimationScore = GAC.BestChromosome.Fitness(GAC.Calculator);
            return GAC.BestChromosome.Genes;
            */
            PSOController.InitializeParticleSwarm();
            PSOController.FindGlobalMinimum(0.5, 0.9, 0.6, 500);
            EstimationScore = PSOController.GlobalBestParticle.Fitness;
            return PSOController.GlobalBestParticle.BestKnownPosition;
            
        }

        public double Fitness(double[] values)
        {
            ScheduleConstructor.MakeSchedules(ScheduleData, values);
            double gapsCount = ScheduleEvaluator.EstimateSchedule(ScheduleConstructor.SchedulesList);
            return gapsCount;
        }
    }
}
