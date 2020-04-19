using ScheduleMaker.OP.School;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleMaker.OP
{
    public class ScheduleConstructor
    {
        /// <summary>
        /// Расписания.
        /// </summary>
        public List<Schedule> SchedulesList;

        public ScheduleConstructor()
        {
            SchedulesList = new List<Schedule>();
        }

        /// <summary>
        /// Инициализировать расписания.
        /// </summary>
        /// <param name="syllabi">Учебные планы.</param>
        private void InitializeSchedules(List<Syllabus> syllabi)
        {
            SchedulesList.Clear();
            for (int i = 0; i < syllabi.Count; i++)
            {
                Schedule schedule = new Schedule(SchedulesList.Count, syllabi[i].Id, syllabi[i].Class);
                SchedulesList.Add(schedule);
            }
        }

        /// <summary>
        /// Создать расписания на основе данных об учебных планах и приоритетах.
        /// </summary>
        /// <param name="scheduleData">Данные для расписаний.</param>
        /// <param name="priorities">Приоритеты.</param>
        public void MakeSchedules(ScheduleData scheduleData, double[] priorities)
        {
            ClearTeachersLessons(scheduleData);
            Job[] tempLessons = new Job[scheduleData.LessonsCount];
            InitializeSchedules(scheduleData.Syllabi);
            CopyAndSortLessons(scheduleData, tempLessons, priorities);
            // TODO: проверить: справятся ли учителя с нагрузкой
            int indexOfJob = 0;
            while (indexOfJob < tempLessons.Length)
            {
                AddLesson(scheduleData, tempLessons, indexOfJob);
                indexOfJob++;
            }
        }
        
        /// <summary>
        /// Построить вектор по приоритетам.
        /// </summary>
        /// <param name="scheduleData">Вектор всех уроков.</param>
        /// <param name="tempLessons">Вектор, который построится.</param>
        /// <param name="priorities">Приоритеты.</param>
        private void CopyAndSortLessons(ScheduleData scheduleData, Job[] tempLessons, double[] priorities)
        {
            double[] temp = new double[priorities.Length];
            for (int i = 0; i < priorities.Length; i++)
            {
                temp[i] = priorities[i];
            }
            Array.Copy(scheduleData.AllLessons, tempLessons, scheduleData.AllLessons.Length);
            Array.Sort(temp, tempLessons);
        }

        /// <summary>
        /// Очистить уроки учителей.
        /// </summary>
        /// <param name="scheduleData">Учителя.</param>
        private void ClearTeachersLessons(ScheduleData scheduleData)
        {
            for (int i = 0; i < scheduleData.Teachers.Length; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    scheduleData.Teachers[i].Lessons[j] = null;
                }
            }
        }

        /// <summary>
        /// Добавить урок.
        /// </summary>
        /// <param name="scheduleData">Данные об учителях.</param>
        /// <param name="tempLessons">Временный вектор уроков.</param>
        /// <param name="indexOfJob">Индекс текущего урока.</param>
        private void AddLesson(ScheduleData scheduleData, Job[] tempLessons, int indexOfJob)
        {
            // Найти учителя, который ведет предмет
            int teacherId = scheduleData.Teachers.FirstOrDefault(x => x.Subject.Any(s => s.Id == tempLessons[indexOfJob].Subject.Id)).Id;
            // Найти расписание нужного класса
            int scheduleId = SchedulesList.FirstOrDefault(x => x.SyllabusId == tempLessons[indexOfJob].SyllabusId).SyllabusId;
            // Добавить урок
            for (int i = 0; i < 60; i++)
            {
                if (scheduleData.Teachers[teacherId].Lessons[i] == null && SchedulesList[scheduleId].Lessons[i] == null)
                {
                    scheduleData.Teachers[teacherId].Lessons[i] = tempLessons[indexOfJob];
                    SchedulesList[scheduleId].Lessons[i] = tempLessons[indexOfJob];
                    break;
                }
            }
        }
    }
}
