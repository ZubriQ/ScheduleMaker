using System;
using System.Text;

namespace ScheduleMaker.ADO
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

        public string FullName
        {
            get
            {
                StringBuilder result = new StringBuilder();
                result.Append(second_name);
                result.Append(" ");
                result.Append(first_name[0]);
                result.Append(".");
                if (!string.IsNullOrWhiteSpace(middle_name))
                {
                    result.Append(middle_name[0]);
                    result.Append(".");
                }
                return result.ToString();
            }
        }
    }

    public partial class Syllabi
    {
        public string AllSubjects
        {
            get
            {
                StringBuilder result = new StringBuilder();
                byte i = 0;
                foreach (var s in StudyLoad)
                {
                    result.Append(s.Subjects.name);
                    result.Append(" (");
                    result.Append(s.lessons_count);
                    result.Append(')');
                    if (i < StudyLoad.Count - 1)
                    {
                        result.Append(", ");
                    }
                    i++;
                }
                return result.ToString();
            }
        }

        public int LessonsCount
        {
            get
            {
                int lessonsCount = 0;
                foreach (var s in StudyLoad)
                {
                    lessonsCount += s.lessons_count;
                }
                return lessonsCount;
            }
        }

        public string AllClasses
        {
            get
            {
                StringBuilder result = new StringBuilder();
                byte i = 0;
                foreach (var s in Classes)
                {
                    result.Append(s.name);
                    if (i < Classes.Count - 1)
                    {
                        result.Append(", ");
                    }
                    i++;
                }
                return (result.ToString() == "") ? "Классы еще не назначены." : result.ToString();
            }
        }

        public short Load
        {
            get
            {
                short sum = 0;
                foreach (var s in StudyLoad)
                {
                    sum += Convert.ToInt16(s.lessons_count);
                }
                return sum;
            }
        }
    }

    public partial class Classes
    {
        public string AllTeachers
        {
            get
            {
                StringBuilder result = new StringBuilder();
                byte i = 0;
                foreach (var s in Teachers)
                {
                    result.Append(s.FullName);
                    if (i < Teachers.Count - 1)
                    {
                        result.Append(", ");
                    }
                    i++;
                }
                return (result.ToString() == "") ? "Учителя еще не назначены." : result.ToString();
            }
        }
    }

    public partial class Classrooms
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
                return (result == "") ? "Предметы еще не назначены." : result;
            }
        }
    }
}
