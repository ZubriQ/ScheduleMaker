/*using System.Collections.Generic;

namespace ScheduleMaker.OP.School
{
    public class Classroom
    {
        /// <summary>
        /// Номер кабинета.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Смена 1/2.
        /// </summary>
        public int Shift { get; set; }

        /// <summary>
        /// Уроки.
        /// </summary>
        public Dictionary<int, Job>[] Lessons { get; set; }

        public int[][] Processed { get; set; }

        public Classroom(string name, int shift)
        {
            Name = name;
            Shift = shift;
            // Инициализация для каждого дня (6) максимальное кол-во уроков (8)
            Lessons = new Dictionary<int, Job>[6];
            for (int i = 0; i < Lessons.Length; i++)
            {
                Lessons[i] = new Dictionary<int, Job>(8);
            }
        }

        public double PercentageOfFilled
    }
}
*/