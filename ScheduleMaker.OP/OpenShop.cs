﻿using ScheduleMaker.OP.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleMaker.OP
{
    public class OpenShop
    {
        private static readonly Random rnd = new Random();

        /// <summary>
        /// Все Учителя в школе.
        /// </summary>
        public Machine[] Teachers { get; set; }

        /// <summary>
        /// Расписания Учебных планов.
        /// </summary>
        public List<Schedule> SchedulesList { get; set; }

        /// <summary>
        /// Вектор со всеми уроками.
        /// </summary>
        public Job[] AllLessons { get; set; }

        /// <summary>
        /// Конструктор Open Shop'a.
        /// </summary>
        /// <param name="teachers">Загрузка списка всех учителей в школе.</param>
        public OpenShop(List<Teacher> teachers)
        {
            Teachers = new Machine[teachers.Count];
            initializeTeachers(teachers);
            SchedulesList = new List<Schedule>();
            AllLessons = null;
        }

        #region initializations
        /// <summary>
        /// Преобразование учителей в машины.
        /// </summary>
        /// <param name="teachers">Учителя.</param>
        private void initializeTeachers(List<Teacher> teachers)
        {
            for (int i = 0; i < this.Teachers.Length; i++)
            {
                this.Teachers[i] = new Machine(i, teachers[i].Subject);
            }
        }

        /// <summary>
        /// Инициализирует уроки.
        /// </summary>
        /// <param name="syllabuses">Учебные планы.</param>
        private void initializeAllLessons(Syllabus[] syllabuses)
        {
            AllLessons = new Job[calculateNumberOfLessons(syllabuses)];
            int i = 0;
            for (int s = 0; s < syllabuses.Length; s++)
            {
                for (int l = 0; l < syllabuses[s].LessonsCount; l++)
                {
                    AllLessons[i] = syllabuses[s].Lessons[l];
                    i++;
                }
            }
        }

        /// <summary>
        /// Подсчитывает сумму всех уроков в учебных планах.
        /// </summary>
        /// <param name="syllabuses">Учебные планы.</param>
        /// <returns>Возвращает сумму всех уроков в учебных плана.</returns>
        private int calculateNumberOfLessons(Syllabus[] syllabuses)
        {
            int sum = 0;
            for (int i = 0; i < syllabuses.Length; i++)
            {
                sum += syllabuses[i].LessonsCount;
            }
            return sum;
        }

        private void initializeSchedules(Syllabus[] syllabuses)
        {
            for (int i = 0; i < syllabuses.Length; i++)
            {
                Schedule schedule = new Schedule(SchedulesList.Count, syllabuses[i].Id, syllabuses[i].Class);
                SchedulesList.Add(schedule);
            }
        }
        #endregion

        #region making schedules
        /// <summary>
        /// Составить расписание для всех Учебных планов.
        /// </summary>
        /// <param name="syllabuses">Учебные планы.</param>
        public void MakeSchedules(Syllabus[] syllabuses)
        {
            initializeAllLessons(syllabuses);
            initializeSchedules(syllabuses);
            randomizeAllLessons();
            short indexOfJob = 0;
            // TODO: проверить: справятся ли учителя с нагрузкой
            while (indexOfJob < AllLessons.Length)
            {
                // Найти учителя, который ведет предмет
                int teacherId = Teachers.FirstOrDefault(x => x.Subject.Id == AllLessons[indexOfJob].Subject.Id).Id;
                // Найти расписание нужного класса
                int scheduleId = SchedulesList.FirstOrDefault(x => x.SyllabusId == AllLessons[indexOfJob].SyllabusId).SyllabusId;
                addLesson(teacherId, scheduleId, indexOfJob);
                indexOfJob++;
            }
            // тест найденных пробелов
            int gaps = findGapsInAllSchedules();
            int kek = 0;
        }

        /// <summary>
        /// Добавить урок.
        /// </summary>
        /// <param name="teacherId">Ключ учителя.</param>
        /// <param name="scheduleId">Ключ Учебного плана.</param>
        /// <param name="indexOfJob">Индекст текущего урока в векторе.</param>
        private void addLesson(int teacherId, int scheduleId, short indexOfJob)
        {
            for (int i = 0; i < 60; i++)
            {
                if (Teachers[teacherId].Lessons[i] == null && SchedulesList[scheduleId].Lessons[i] == null)
                {
                    Teachers[teacherId].Lessons[i] = AllLessons[indexOfJob];
                    SchedulesList[scheduleId].Lessons[i] = AllLessons[indexOfJob];
                    break;
                }
            }
        }

        /// <summary>
        /// Перемешать уроки в векторе.
        /// </summary>
        private void randomizeAllLessons()
        {
            var randomizedLessons = AllLessons.OrderBy(x => rnd.Next()).ToArray();
            AllLessons = randomizedLessons;
        }
        #endregion

        #region finding gaps in schedules
        /// <summary>
        /// Подсчитать кол-во пробелов во всех расписаниях.
        /// </summary>
        /// <returns>Возвращает кол-во пробелов.</returns>
        private int findGapsInAllSchedules()
        {
            int gapsCount = 0;
            for (int i = 0; i < SchedulesList.Count; i++)
            {
                findGaps(i, ref gapsCount);
            }
            return gapsCount;
        }

        /// <summary>
        /// Находит пробелы в одном расписании.
        /// </summary>
        /// <param name="scheduleId">Расписание, в котором идет подсчет.</param>
        /// <param name="gapsCount">Кол-во пробелов.</param>
        private void findGaps(int scheduleId, ref int gapsCount)
        {
            int[] left = new int[6];
            int[] right = new int[6];
            for (byte day = 0; day < 6; day++)
            {
                findFirstLesson(ref left, day, scheduleId);
                findLastLesson(ref right, day, scheduleId);
            }
            calculateGaps(left, right, ref gapsCount, scheduleId);
        }

        /// <summary>
        /// Узнать индекс начального урока в дне.
        /// </summary>
        /// <param name="left">Массив со значением для каждого дня. Индекс самого левого урока.</param>
        /// <param name="day">День.</param>
        /// <param name="scheduleId">Расписание, в котором идет подсчет.</param>
        private void findFirstLesson(ref int[] left, byte day, int scheduleId)
        {
            for (byte job = 0; job < 10; job++)
            {
                if (SchedulesList[scheduleId].Lessons[day + (job * 6)] != null)
                {
                    left[day] = day + job * 6;
                    break;
                }
            }
        }

        /// <summary>
        /// Узнать индекс последнего урока в дне.
        /// </summary>
        /// <param name="right">Массив со значением для каждого дня. Индекс самого правого урока.</param>
        /// <param name="day">День.</param>
        /// <param name="scheduleId">Расписание, в котором идет подсчет.</param>
        private void findLastLesson(ref int[] right, byte day, int scheduleId)
        {
            for (sbyte job = 9; job >= 0; job--)
            {
                if (SchedulesList[scheduleId].Lessons[day + (job * 6)] != null)
                {
                    right[day] = day + job * 6;
                    break;
                }
            }
        }

        /// <summary>
        /// Подсчет пробелов в каждом дне между/>
        /// </summary>
        /// <param name="left">Левое значение.</param>
        /// <param name="right">Правое значение.</param>
        /// <param name="gapsCount">Кол-во пробелов.</param>
        /// <param name="scheduleId">Расписание, в котором идет подсчет.</param>
        private void calculateGaps(int[] left, int[] right, ref int gapsCount, int scheduleId)
        {
            for (int day = 0; day < 6; day++)
            {
                for (int job = left[day]; job < right[day]; job += 6)
                {
                    if (SchedulesList[scheduleId].Lessons[job] == null)
                    {
                        gapsCount++;
                    }
                }
            }
        }
        #endregion

        #region output to console
        /// <summary>
        /// Вывод расписания для каждого преподавателя в консоль.
        /// </summary>
        public void OutputMachines()
        {
            for (int i = 0; i < Teachers.Length; i++)
            {
                Console.WriteLine($"  Учитель. id: {Teachers[i].Id}, предмет: {Teachers[i].Subject.Name}");
                Console.WriteLine(Teachers[i]);
            }
        }
        
        /// <summary>
        /// Вывод расписания всех школьных классов в консоль.
        /// </summary>
        public void OutputClassSchedules()
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
                Console.WriteLine($"Учитель. id: {Teachers[t].Id}, предмет: {Teachers[t].Subject.Name}");
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