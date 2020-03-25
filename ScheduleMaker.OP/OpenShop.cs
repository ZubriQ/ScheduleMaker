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
        /// Учебный план.
        /// </summary>
        private Syllabus syllabus { get; } // private Syllabus[] syllabus { get; } должно быть много классов 10a 10б 10в*?

        /// <summary>
        /// Количество дней (5/6).
        /// </summary>
        private int daysCount { get; }

        /// <summary>
        /// Количество Учителей.
        /// </summary>
        private int machinesCount { get; }

        /// <summary>
        /// Количество Уроков.
        /// </summary>
        private int jobsCount { get; }

        /// <summary>
        /// Уроки.
        /// </summary>
        private Job[] jobs { get; set; }

        /// <summary>
        /// Учителя.
        /// </summary>
        private Machine[] machines { get; set; }

        /// <summary>
        /// Операции.
        /// </summary>
        private int[][] operations { get; } // не используется пока что

        public OpenShop(Syllabus syllabus, int daysCount)
        {
            this.syllabus = syllabus;
            this.daysCount = daysCount;
            this.machinesCount = syllabus.Teachers.Length;
            this.jobsCount = initializeJobsCount();
            this.operations = new int[machinesCount][]; // для чего использовать???
            initializeJobs(syllabus.Id);
            initializeMachines();
        }

        private int initializeJobsCount()
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
        /// Преобразует учителей в машины.
        /// </summary>
        private void initializeMachines()
        {
            machines = new Machine[machinesCount];
            for (int i = 0; i < machinesCount; i++)
            {
                machines[i] = new Machine(i, syllabus.Teachers[i].SubjectName);
            }
        }

        /// <summary>
        /// Составить расписание.
        /// </summary>
        public void MakeSchedule()
        {
            int lessonsPerDay = (int)Math.Ceiling((double)jobsCount / daysCount);
            int indexOfJob = 0;
            int day = 0;
            
            while (indexOfJob < jobsCount)
            {
                // Найти учителя, который ведет предмет
                int machineId = machines.FirstOrDefault(x => x.SubjectName == jobs[indexOfJob].JobName).Id;
                if (indexOfJob % lessonsPerDay == 0)
                {
                    day++;
                }
                // Ключ машины, день, обрабатываемая в данный момент работа
                machines[machineId].Jobs[day - 1].Add(machines[machineId].Jobs[day - 1].Count, jobs[indexOfJob]);
                // Перейти к обработке следующей работы
                indexOfJob++;
            }
        }
        
        /// <summary>
        /// Вывод расписания для каждого преподавателя.
        /// </summary>
        public void OutputMachines()
        {
            for (int i = 0; i < machinesCount; i++)
            {
                Console.WriteLine($"Учитель. id: {machines[i].Id}, предмет: {machines[i].SubjectName}");
                Console.WriteLine(machines[i]);
            }
        }

        public Syllabus Syllabus => syllabus;

        public int DaysCount => daysCount;

        public int MachinesCount => machinesCount;

        public int JobsCount => jobsCount;

        public Job[] Jobs => jobs;

        public Machine[] Machines => machines;

        public int[][] Operations => operations;
    }
}
