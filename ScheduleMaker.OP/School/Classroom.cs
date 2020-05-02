using System.Collections.Generic;

namespace ScheduleMaker.OP.School
{
    /// <summary>
    /// Школьный кабинет
    /// </summary>
    public class Classroom
    {
        /// <summary>
        /// Уникальный ключ
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер или название кабинета
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Смена 1/2
        /// </summary>
        public byte Shift { get; set; } // пока не используется

        /// <summary>
        /// Предметы, которые могут вестись в кабинете
        /// </summary>
        public Subject[] Subjects { get; set; }

        /// <summary>
        /// Уроки
        /// </summary>
        public Job[] Lessons { get; set; }
        public Classroom(int id, string name, Subject[] subjects)
        {
            Id = id;
            Name = name;
            Shift = 1;
            Lessons = new Job[60];
            Subjects = subjects;
        }
    }
}
