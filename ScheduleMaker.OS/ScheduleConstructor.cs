using ScheduleMaker.OS.School;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleMaker.OS
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
            ClearLessons(scheduleData);
            Job[] tempLessons = new Job[scheduleData.LessonsCount];
            InitializeSchedules(scheduleData.Syllabi);
            CopyAndSortLessons(scheduleData, tempLessons, priorities);
            // TODO: проверить: справятся ли учителя с нагрузкой
            int indexOfJob = 0;
            while (indexOfJob < tempLessons.Length)
            {
                Job lesson = tempLessons[indexOfJob];
                AddLesson(scheduleData, lesson);
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

        private void ClearLessons(ScheduleData scheduleData)
        {
            ClearTeachersLessons(scheduleData);
            ClearClassroomsLessons(scheduleData);
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
        /// Очистить уроки в кабинетах
        /// </summary>
        /// <param name="scheduleData">Кабинеты</param>
        private void ClearClassroomsLessons(ScheduleData scheduleData)
        {
            for (int i = 0; i < scheduleData.Classrooms.Count; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    scheduleData.Classrooms[i].Lessons[j] = null;
                }
            }
        }

        /// <summary>
        /// Добавить урок
        /// </summary>
        /// <param name="scheduleData">Данные об учителях</param>
        /// <param name="lesson">Урок</param>
        private void AddLesson(ScheduleData scheduleData, Job lesson)
        {
            // TODO: сделать словать план, предмет, учитель Dictionary< int, Dictionary<int, Teacher> >
            var teacherId = scheduleData.Syllabi[lesson.SyllabusId].Teachers
                                        .Single(x => x.Subject.Any(s => s.Id == lesson.Subject.Id)).Id;
            var teacher = scheduleData.Teachers.Single(x => x.Id == teacherId);
            var teacherIndex = Array.IndexOf(scheduleData.Teachers, teacher);
            int scheduleId = SchedulesList.Single(x => x.SyllabusId == lesson.SyllabusId).SyllabusId;
            // TODO: Выбирать менее занятый кабинет, так как один может быть переполнен
            int classroomId = scheduleData.Classrooms.First(x => x.Subjects.Any(s => s.Id == lesson.Subject.Id)).Id;
            for (int i = 0; i < 60; i++)
            {
                if (scheduleData.Teachers[teacherIndex].Lessons[i] == null && SchedulesList[scheduleId].Lessons[i] == null 
                    && scheduleData.Classrooms[classroomId].Lessons[i] == null)
                {
                    scheduleData.Teachers[teacherIndex].Lessons[i] = lesson;
                    SchedulesList[scheduleId].Lessons[i] = lesson;
                    scheduleData.Classrooms[classroomId].Lessons[i] = lesson;
                    break;
                }
            }
        }
    }
}
