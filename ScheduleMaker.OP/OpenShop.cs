using ScheduleMaker.OP.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleMaker.OP
{
    public class OpenShop
    {
        /// <summary>
        /// Учителя.
        /// </summary>
        private Machine[] machines { get; }

        /// <summary>
        /// Расписания Учебных планов.
        /// </summary>
        private List<Schedule> schedules { get; }

        /// <summary>
        /// Счетчик id для <see cref="schedules"/>.
        /// </summary>
        private int scheduleCounter { get; set; }

        /// <summary>
        /// Конструктор Open Shop'a.
        /// </summary>
        /// <param name="teachers">Загрузка списка всех учителей в школе.</param>
        public OpenShop(Teacher[] teachers)
        {
            this.machines = new Machine[teachers.Length];
            this.schedules = new List<Schedule>();
            initializeMachines(teachers);
        }

        /// <summary>
        /// Преобразование учителей в машины.
        /// </summary>
        /// <param name="teachers">Учителя.</param>
        private void initializeMachines(Teacher[] teachers)
        {
            for (int i = 0; i < machines.Length; i++)
            {
                machines[i] = new Machine(i, teachers[i].Subject);
            }
        }

        /// <summary>
        /// Составить расписание для одного Учебного плана.
        /// </summary>
        /// <param name="syllabus">Учебный план.</param>
        /// <param name="numberOfDays">5 или 6 дневный план.</param>
        public Schedule MakeSchedule(Syllabus syllabus, int numberOfDays)
        {
            Schedule schedule = new Schedule(scheduleCounter, syllabus.Id, syllabus.ClassName);
            int lessonsPerDay = (int)Math.Ceiling((double)syllabus.LessonsCount / numberOfDays);
            int indexOfJob = 0;
            byte day = 0;
            // Проверка: справятся ли учителя с нагрузкой нового Учебного плана
            canTeachersHandle(syllabus);

            while (indexOfJob < syllabus.LessonsCount)
            {
                // Найти учителя, который ведет данный предмет 
                int machineId = machines.FirstOrDefault(x => x.Subject.Id == syllabus.Lessons[indexOfJob].Subject.Id).Id;
                // Перейти на следующий день?
                if (indexOfJob % lessonsPerDay == 0)
                {
                    day++;
                }
                addLesson(machineId, day, syllabus, schedule, indexOfJob);
                indexOfJob++;
                // Если день 6 и не будет места => Сделать день = 0 ?
            }
            // пока что есть добавление расписаний в лист. нужно ли?
            schedules.Add(schedule);
            scheduleCounter++;
            return schedule;
        }

        /// <summary>
        /// Проверяет справляются ли учителя с новым Учебным.
        /// </summary>
        /// <param name="syllabus">Учебный план.</param>
        private void canTeachersHandle(Syllabus syllabus)
        {
            for (int i = 0; i < machines.Length; i++)
            {
                int numberOfLessons = syllabus.SubjectPlans.FirstOrDefault(x => x.Subject.Id == machines[i].Subject.Id).Count;
                if (machines[i].CanHandle(numberOfLessons))
                {
                    throw new Exception($"Учитель id:{machines[i].Id} не справится с нагрузкой.");
                }
            }
        }

        private void addLesson(int machineId, byte day, Syllabus syllabus, Schedule schedule, int indexOfJob)
        {
            for (byte numberOfLesson = 0; numberOfLesson < 8; numberOfLesson++)
            {
                if (machines[machineId].Schedule[day - 1].ContainsKey(numberOfLesson))
                {
                    // Если у учителя уже есть урок в это время
                }
                else if (!string.IsNullOrEmpty(schedule.Lessons[day - 1, numberOfLesson]))
                {
                    // Если у класса уже есть урок в это время
                }
                // Добавляем урок учителю, расписанию, переход к другому уроку
                else
                {
                    machines[machineId].Schedule[day - 1].Add(numberOfLesson, syllabus.Lessons[indexOfJob]);
                    schedule.Lessons[day - 1, numberOfLesson] =
                        (numberOfLesson + 1) + ". " + syllabus.Lessons[indexOfJob].Subject.Name;
                    machines[machineId].LessonsCount++;
                    break;
                }
            }
        }

        #region output to console
        /// <summary>
        /// Вывод расписания для каждого преподавателя в консоль.
        /// </summary>
        public void OutputMachines()
        {
            for (int i = 0; i < machines.Length; i++)
            {
                Console.WriteLine($"Учитель. id: {machines[i].Id}, предмет: {machines[i].Subject.Name}");
                Console.WriteLine(machines[i]);
            }
        }
        
        /// <summary>
        /// Вывод расписания всех школьных классов в консоль.
        /// </summary>
        public void OutputSchedules()
        {
            for (int scheduleId = 0; scheduleId < schedules.Count; scheduleId++)
            {
                Console.WriteLine($"  Расписание {schedules[scheduleId].SyllabusId + 1} класса:");
                for (byte i = 0; i < 6; i++)
                {
                    for (byte j = 0; j < 8; j++)
                    {
                        // Чтобы не было пробелов.
                        if (!string.IsNullOrEmpty(schedules[scheduleId].Lessons[i, j]))
                        {
                            Console.Write($"{schedules[scheduleId].Lessons[i, j]} ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        #endregion

        public int MachinesCount => machines.Length;

        public Machine[] Machines => machines;

        public List<Schedule> Schedules => schedules;
    }
}
