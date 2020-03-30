using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMaker.WPF
{
    public class Lesson
    {
        public string Name { get; set; }

        public Lesson(string name)
        {
            Name = name;
        }
    }
}
