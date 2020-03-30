using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMaker.WPF
{
    public class Day
    {
        /// <summary>
        /// Номер дня.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Уроки дня.
        /// </summary>
        public Lesson[] Lessons { get; set; }

        
        public Day(int id, Lesson[] lessons)
        {
            Id = id;
            Lessons = lessons;
            Name = "";
            GetLessons();
        }

        public string Name { get; set; }

        public void GetLessons()
        {
            for (int i = 0; i < Lessons.Length; i++)
            {
                Name += Lessons[i].Name;
            }
        }
    }
}
