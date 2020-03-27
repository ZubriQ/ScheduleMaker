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
        /// Учебные планы.
        /// </summary>
        private Syllabus[] syllabuses { get; }

        /// <summary>
        /// Учителя.
        /// </summary>
        private Machine[] machines { get; }

        /// <summary>
        /// Операции.
        /// </summary>
        private int[][] operations { get; } // не используется пока что

        /// <summary>
        /// Конструктор Open Shop'a.
        /// </summary>
        /// <param name="teachers">Загрузка списка всех учителей в школе.</param>
        /// <param name="syllabuses">Учебные планы, для которых необходимо составить расписание.</param>
        public OpenShop(Teacher[] teachers, Syllabus[] syllabuses)
        {
            this.syllabuses = syllabuses;
            this.machines = new Machine[teachers.Length];
            this.operations = new int[teachers.Length][]; // для чего использовать???
            initializeMachines(teachers);
        }

        /// <summary>
        /// Преобразование учителей в машины.
        /// </summary>
        private void initializeMachines(Teacher[] teachers)
        {
            for (int i = 0; i < machines.Length; i++)
            {
                machines[i] = new Machine(i, teachers[i].SubjectName);
            }
        }

        /// <summary>
        /// Составить расписание для одного Учебного плана.
        /// </summary>
        public void MakeScheduleById(int syllabusId)
        {
            int lessonsPerDay = (int)Math.Ceiling((double)syllabuses[syllabusId].JobsCount / syllabuses[syllabusId].DaysCount);
            int indexOfJob = 0;
            int day = 0;
            
            while (indexOfJob < syllabuses[syllabusId].JobsCount)
            {
                // Найти учителя, который ведет данный предмет 
                int machineId = machines.FirstOrDefault(x => x.SubjectName == syllabuses[syllabusId].Jobs[indexOfJob].JobName).Id;

                // Перейти на следующий день?
                if (indexOfJob % lessonsPerDay == 0)
                {
                    day++;
                }
                // TODO: this
                for (int numberOfLesson = 0; numberOfLesson < 8; numberOfLesson++)
                {
                    // Если у учителя уже есть урок в это время
                    if (machines[machineId].Schedule[day - 1].ContainsKey(numberOfLesson))
                    {
                       
                    }
                    // Если у класса уже есть урок в это время
                    else if (!string.IsNullOrEmpty(syllabuses[syllabusId].Schedule[day - 1, numberOfLesson]))
                    {

                    }
                    else
                    {
                        // Добавляем урок
                        // Ключ машины, день, обрабатываемая в данный момент работа
                        machines[machineId].Schedule[day - 1].Add(numberOfLesson, syllabuses[syllabusId].Jobs[indexOfJob]);
                        syllabuses[syllabusId].Schedule[day - 1, numberOfLesson] =
                            (numberOfLesson + 1) + ". " + Syllabuses[syllabusId].Jobs[indexOfJob].JobName;
                        break;
                    }
                }
                indexOfJob++;
                // Если день 6 и не будет места => Сделать день = 0 ?
            }
        }
        
        /// <summary>
        /// Вывод расписания для каждого преподавателя.
        /// </summary>
        public void OutputMachines()
        {
            for (int i = 0; i < machines.Length; i++)
            {
                Console.WriteLine($"Учитель. id: {machines[i].Id}, предмет: {machines[i].SubjectName}");
                Console.WriteLine(machines[i]);
            }
        }

        public void OutputScheduleById(int syllabusId)
        {
            Console.WriteLine($"  Расписание {Syllabuses[syllabusId].ClassName} класса:");
            for (byte i = 0; i < 6; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    Console.Write($"{syllabuses[syllabusId].Schedule[i, j]} ");
                }
                Console.Write("\n");
            }
        }

        // TODO: complete this
        /*
        public void OutputAllSchedules()
        {
            Console.WriteLine("  Расписание:");
            for (byte i = 0; i < 6; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    Console.Write($"{syllabuses[syllabusid].Schedule[i, j]} ");
                }
                Console.Write("\n");
            }
        }*/

        public Syllabus[] Syllabuses => syllabuses;

        public int MachinesCount => machines.Length;

        public Machine[] Machines => machines;

        public int[][] Operations => operations;

        /*
        private int calculateJobsCount()
        {
            int sum = 0;
            for (int i = 0; i < syllabus.Subjects.Length; i++)
            {
                sum += syllabus.Subjects[i].Count;
            }
            return sum;
        }

        /// <summary>
        /// Преобразует уроки в работы.
        /// </summary>
        private void initializeJobs(int syllabusId)
        {
            jobs = new Job[jobsCount];
            int index = 0;
            for (int i = 0; i < syllabus.Subjects.Length; i++)
            {
                for (int j = 0; j < syllabus.Subjects[i].Count; j++)
                {
                    Job newJob = new Job(index, 
                        syllabus.Subjects[i].Name,
                        syllabus.Subjects[i].Difficulty,
                        syllabusId);
                    jobs[index] = newJob;
                    index++;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void initializeSchedule()
        {
            for (byte i = 0; i < 6; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    schedule[i, j] = -1;
                }
            }
        }*/
    }
}
