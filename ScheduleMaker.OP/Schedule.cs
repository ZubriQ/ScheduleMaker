using ScheduleMaker.OP.School;
using System;
using System.Collections.Generic;

namespace ScheduleMaker.OP
{
    /// <summary>
    /// Расписание Учебного плана.
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Уникальный ключ.
        /// </summary>
        private int id { get; }

        /// <summary>
        /// Ключ Учебного плана.
        /// </summary>
        private int syllabusId { get; }

        /// <summary>
        /// Школьный класс.
        /// </summary>
        public Class Class { get; }

        /// <summary>
        /// Уроки.
        /// </summary>
        private Job[] lessons { get; }

        /// <summary>
        /// Конструктор расписания.
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="syllabusId">Ключ Учебного плана.</param>
        /// <param name="class">Школьный класс.</param>
        public Schedule(int id, int syllabusId, Class @class)
        {
            this.id = id;
            this.syllabusId = syllabusId;
            this.Class = @class;
            this.lessons = new Job[60];
        }

        /*
        /// <summary>
        /// Инициализация матрицы расписания.
        /// </summary>
        private void initializeSchedule()
        {
            for (byte i = 0; i < 6; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    lessons[i, j] = null;
                }
            }
        }
        /// <summary>
        /// Вывод расписания в консоль.
        /// </summary>
        public void OutputSchedule()
        {
            Console.WriteLine($"  Расписание {SyllabusId} класса:");
            for (byte i = 0; i < 6; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    Console.Write($"{Lessons[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }*/

        public int Id => id;

        public int SyllabusId => syllabusId;

        public Job[] Lessons => lessons;
    }
}
