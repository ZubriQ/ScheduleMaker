using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMaker.WPF
{
    public partial class Teachers
    {
        public string AllSubjects
        {
            get
            {
                string result = "";
                byte i = 0;
                foreach (var s in Subjects)
                {
                    result += s.name;
                    if (i < Subjects.Count - 1)
                    {
                        result += ", ";
                    }
                    i++;
                }
                return result;
            }
        }
    }
}
