using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMaker.WPF
{
    public class Day
    {
        public string[] Lessons { get; set; }

        public Day(string[] lessons)
        {
            Lessons = lessons;
            Name = "";
            GetLessons();
        }

        public string Name { get; set; }

        public void GetLessons()
        {
            for (int i = 0; i < Lessons.Length; i++)
            {
                Name += Lessons[i];
            }
        }
    }
}
