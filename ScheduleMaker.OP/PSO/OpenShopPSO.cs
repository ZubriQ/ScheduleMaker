using ScheduleMaker.ADO;
using ScheduleMaker.GA;
using ScheduleMaker.OP.School;
using ScheduleMaker.PSO;
using System;
using System.Collections.Generic;

namespace ScheduleMaker.OP.PSO
{
    public class OpenShopPSO : ICalculator
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

        public Machine[] Teachers => ScheduleData.Teachers;

        public OpenShopPSO() 
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
            Parameter parameters = new Parameter(-150, 150, 40, ScheduleData.LessonsCount);
            PSOController = new PSOController(parameters, calculator);
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
        /// <returns>Учителя (Open Shop)</returns>
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
        /// <returns>Кабинеты (Open Shop)</returns>
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
                    Subject subject = new Subject(s.subject_id, s.name, Convert.ToInt32(s.difficulty));
                    subjects[i] = subject;
                    i++;
                }
                classroomsList.Add(new Classroom(classrooms[c].classroom_id, classrooms[c].name, subjects));
            }
            return classroomsList;
        }

        /// <summary>
        /// Найти лучшие приоритеты для вектора уроков.
        /// </summary>
        /// <returns>Возвращает наилучшие приоритеты расположения уроков.</returns>
        public double[] FindBestPriorities()
        {
            PSOController.InitializeParticleSwarm();
            PSOController.FindGlobalMinimum(0.729, 1.49445, 1.49445, 350);
            return PSOController.GlobalBestParticle.BestKnownPosition;
        }

        public double Fitness(double[] values)
        {
            ScheduleConstructor.MakeSchedules(ScheduleData, values);
            int gapsCount = ScheduleEvaluator.EstimateSchedule(ScheduleConstructor.SchedulesList);
            return gapsCount;
        }
    }
}
