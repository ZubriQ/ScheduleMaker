using ScheduleMaker.OP.School;
using System;
using System.Collections.Generic;

namespace ScheduleMaker.OP
{
    /// <summary>
    /// Исходные данные для создания расписаний
    /// </summary>
    public class ScheduleData
    {
        /// <summary>
        /// Все Учителя в школе.
        /// </summary>
        public Machine[] Teachers { get; set; }

        /// <summary>
        /// Учебные планы.
        /// </summary>
        public List<Syllabus> Syllabi { get; set; }

        /// <summary>
        /// Вектор со всеми уроками.
        /// </summary>
        public Job[] AllLessons { get; set; }

        /// <summary>
        /// Количество уроков со всех Учебных планов.
        /// </summary>
        public int LessonsCount { get; set; }

        /// <summary>
        /// Кабинеты.
        /// </summary>
        public List<Classroom> Classrooms { get; set; }

        /// <summary>
        /// Необходимые данные для создания расписания
        /// </summary>
        /// <param name="teachers">Учителя.</param>
        /// <param name="syllabi">Нагрузка с учебных планов.</param>
        /// <param name="classrooms">Кабинеты.</param>
        public ScheduleData(List<Teacher> teachers, List<Syllabus> syllabi, List<Classroom> classrooms)
        {
            Teachers = new Machine[teachers.Count];
            InitializeTeachers(teachers);
            Syllabi = syllabi;
            InitializeLessonsCount(syllabi);
            InitializeAllLessons();
            Classrooms = classrooms;
        }

        /// <summary>
        /// Необходимые данные для создания расписания
        /// </summary>
        /// <param name="teachers">Учителя.</param>
        /// <param name="syllabi">Нагрузка с учебных планов.</param>
        /// <param name="classrooms">Кабинеты.</param>
        public ScheduleData(Machine[] teachers, List<Syllabus> syllabi, List<Classroom> classrooms)
        {
            Teachers = teachers;
            Syllabi = syllabi;
            InitializeLessonsCount(syllabi);
            InitializeAllLessons();
            Classrooms = classrooms;
        }

        /// <summary>
        /// Преобразование учителей в машины.
        /// </summary>
        /// <param name="teachers">Учителя.</param>
        private void InitializeTeachers(List<Teacher> teachers)
        {
            for (int i = 0; i < this.Teachers.Length; i++)
            {
                this.Teachers[i] = new Machine(i, teachers[i].Subject);
            }
        }

        /// <summary>
        /// Подсчитывает сумму всех уроков в учебных планах.
        /// </summary>
        /// <param name="syllabi">Учебные планы.</param>
        public void InitializeLessonsCount(List<Syllabus> syllabi)
        {
            LessonsCount = 0;
            for (int i = 0; i < syllabi.Count; i++)
            {
                LessonsCount += syllabi[i].LessonsCount;
            }
        }

        /// <summary>
        /// Инициализирует уроки.
        /// </summary>
        private void InitializeAllLessons()
        {
            AllLessons = new Job[LessonsCount];
            int i = 0;
            for (int s = 0; s < Syllabi.Count; s++)
            {
                for (int l = 0; l < Syllabi[s].LessonsCount; l++)
                {
                    AllLessons[i] = Syllabi[s].Lessons[l];
                    i++;
                }
            }
        }

        #region output to console
        /// <summary>
        /// Вывод расписания всех школьных классов в консоль.
        /// </summary>
        public void OutputClassSchedules(List<Schedule> SchedulesList)
        {
            for (int id = 0; id < SchedulesList.Count; id++)
            {
                Console.WriteLine($"  Расписание {SchedulesList[id].SyllabusId + 1} класса:");
                for (byte i = 0; i < 60; i++)
                {
                    if (SchedulesList[id].Lessons[i] != null)
                    {
                        Console.Write($"i:{i}. {SchedulesList[id].Lessons[i].Subject.Name} ");
                        if ((i + 1) % 8 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод расписания всех школьных классов в консоль.
        /// </summary>
        public void OutputTeachersSchedules()
        {
            for (int t = 0; t < Teachers.Length; t++)
            {
                Console.WriteLine($"Учитель. id: {Teachers[t].Id}, предмет: {Teachers[t].AllSubjects}");
                for (byte i = 0; i < 60; i++)
                {
                    if (Teachers[t].Lessons[i] != null)
                    {
                        Console.Write($"i:{i}. {Teachers[t].Lessons[i].Subject.Name} ");
                        if ((i + 1) % 8 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion
    }
}
