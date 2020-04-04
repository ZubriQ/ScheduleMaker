using ScheduleMaker.OP.School;
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
        }

        /// <summary>
        /// Добавить урок.
        /// </summary>
        /// <param name="teacherId">Ключ учителя.</param>
        /// <param name="scheduleId">Ключ Учебного плана.</param>
        /// <param name="indexOfJob">Индекст текущего урока в векторе.</param>
        private void addLesson(int teacherId, int scheduleId, short indexOfJob)
        {
            for (int i = 0; i < 48; i++)
            {
                if (Teachers[teacherId].Lessons[i] == null && SchedulesList[scheduleId].Lessons[i] == null)
                {
                    Teachers[teacherId].Lessons[i] = AllLessons[indexOfJob];
                    SchedulesList[scheduleId].Lessons[i] = AllLessons[indexOfJob];
                    break;
                }
                else
                {

                }
            }
        }

        /*/// <summary>
        /// Найти следующее пустое место в расписании.
        /// </summary>
        /// <param name="day">День.</param>
        /// <param name="numberOfLesson">Номер урока.</param>
        private void findGap(ref sbyte day, ref sbyte numberOfLesson)
        {

        }*/

        /// <summary>
        /// Перемешать уроки в векторе.
        /// </summary>
        private void randomizeAllLessons()
        {
            var randomizedLessons = AllLessons.OrderBy(x => rnd.Next()).ToArray();
            AllLessons = randomizedLessons;
        }

        /*
        #region make schedule for Many syllabuses
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
            // TODO: проверить: справятся ли учителя с нагрузкой.
            while (indexOfJob < AllLessons.Length)
            {
                // Найти учителя, который ведет предмет
                int teacherId = Teachers.FirstOrDefault(x => x.Subject.Id == AllLessons[indexOfJob].Subject.Id).Id;
                // Найти расписание нужного класса
                int scheduleId = SchedulesList.FirstOrDefault(x => x.Key == AllLessons[indexOfJob].SyllabusId).Key;
                addLesson(teacherId, scheduleId, indexOfJob);
                indexOfJob++;
            }
        }

        /// <summary>
        /// Добавить урок.
        /// </summary>
        /// <param name="teacherId">Ключ учителя.</param>
        /// <param name="scheduleId">Ключ Учебного плана.</param>
        /// <param name="indexOfJob">Индекст текущего урока в векторе.</param>
        private void addLesson(int teacherId, int scheduleId, short indexOfJob)
        {
            sbyte numberOfLesson = 0;
            for (sbyte day = 0; day < 6; day++)
            {
                if (Teachers[teacherId].Schedule[day].ContainsKey(numberOfLesson)
                || !string.IsNullOrEmpty(SchedulesList[scheduleId].Lessons[day, numberOfLesson]))
                {
                    // Дальше искать пустое место, если у Учителя или Класса уже есть урок в это время
                    if (day == 5)
                    {
                        if (numberOfLesson < 7)
                        {
                            numberOfLesson++;
                        }
                        else
                        {
                            numberOfLesson = 0;
                        }
                        day = -1;
                    }
                }
                else
                {
                    Teachers[teacherId].Schedule[day].Add(numberOfLesson, AllLessons[indexOfJob]);
                    SchedulesList[scheduleId].Lessons[day, numberOfLesson] =
                        (numberOfLesson + 1) + ". " + AllLessons[indexOfJob].Subject.Name;
                    Teachers[teacherId].LessonsCount++;
                    break;
                }
            }
        }

        /// <summary>
        /// Найти следующее пустое место в расписании.
        /// </summary>
        /// <param name="day">День.</param>
        /// <param name="numberOfLesson">Номер урока.</param>
        private void findGap(ref sbyte day, ref sbyte numberOfLesson)
        {
            
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

        #region schedule for 1 syllabus
        /// <summary>
        /// Составить расписание для одного Учебного плана.
        /// </summary>
        /// <param name="syllabus">Учебный план.</param>
        /// <param name="numberOfDays">5 или 6 дневный план.</param>
        public Schedule MakeSchedule(Syllabus syllabus, int numberOfDays)
        {
            Schedule schedule = new Schedule(ScheduleCounter, syllabus.Id, syllabus.Class);
            int lessonsPerDay = (int)Math.Ceiling((double)syllabus.LessonsCount / numberOfDays);
            int indexOfJob = 0;
            byte day = 0;
            // Проверка: справятся ли учителя с нагрузкой нового Учебного плана
            canTeachersHandle(syllabus);
            while (indexOfJob < syllabus.LessonsCount)
            {
                // Найти учителя, который ведет данный предмет 
                int machineId = Teachers.FirstOrDefault(x => x.Subject.Id == syllabus.Lessons[indexOfJob].Subject.Id).Id;
                // Перейти на следующий день?
                if (indexOfJob % lessonsPerDay == 0)
                {
                    day++;
                }
                addLesson(machineId, day, syllabus, schedule, indexOfJob);
                indexOfJob++;
            }
            //schedules.Add(schedule);// пока что есть добавление расписаний в лист. нужно ли?
            ScheduleCounter++;
            return schedule;
        }

        /// <summary>
        /// Добавить урок.
        /// </summary>
        /// <param name="machineId">Ключ учителя.</param>
        /// <param name="day">День.</param>
        /// <param name="syllabus">Учебный план.</param>
        /// <param name="schedule">Расписание.</param>
        /// <param name="indexOfJob">Индекс урока (работы).</param>
        private void addLesson(int machineId, byte day, Syllabus syllabus, Schedule schedule, int indexOfJob)
        {
            for (sbyte numberOfLesson = 0; numberOfLesson < 8; numberOfLesson++)
            {
                if (Teachers[machineId].Schedule[day - 1].ContainsKey(numberOfLesson)
                    || !string.IsNullOrEmpty(schedule.Lessons[day - 1, numberOfLesson]))
                {
                    // Если у Учителя уже есть урок в это время или у Класса уже есть урок в это время
                    nextDay(ref numberOfLesson, ref day);
                }
                else
                {
                    Teachers[machineId].Schedule[day - 1].Add(numberOfLesson, syllabus.Lessons[indexOfJob]);
                    schedule.Lessons[day - 1, numberOfLesson] =
                        (numberOfLesson + 1) + ". " + syllabus.Lessons[indexOfJob].Subject.Name;
                    Teachers[machineId].LessonsCount++;
                    break;
                }
            }
        }

        /// <summary>
        /// Переход к следующему дню, 
        /// Если в этом дне не нашлось места для урока.
        /// </summary>
        /// <param name="numberOfLesson">Номер урока.</param>
        /// <param name="day">Номер дня.</param>
        private void nextDay(ref sbyte numberOfLesson, ref byte day)
        {
            if (numberOfLesson == 7)
            {
                if (day < 6)
                {
                    day++;
                }
                else
                {
                    day = 1;
                }
                numberOfLesson = -1;
            }
        }

        /// <summary>
        /// Проверяет справляются ли учителя с новым Учебным планом.
        /// </summary>
        /// <param name="syllabus">Учебный план.</param>
        private void canTeachersHandle(Syllabus syllabus)
        {
            for (int i = 0; i < Teachers.Length; i++)
            {
                int numberOfLessons = syllabus.SubjectPlans.FirstOrDefault(x => x.Subject.Id == Teachers[i].Subject.Id).Count;
                if (Teachers[i].CanHandle(numberOfLessons))
                {
                    throw new Exception($"Учитель id:{Teachers[i].Id} не справится с нагрузкой.");
                }
            }
        }
        #endregion
        */
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
