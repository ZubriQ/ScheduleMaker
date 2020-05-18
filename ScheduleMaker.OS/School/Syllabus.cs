using System.Collections.Generic;

namespace ScheduleMaker.OS.School
{
    /// <summary>
    /// Учебный план.
    /// </summary>
    public class Syllabus
    {
        /// <summary>
        /// Уникальный ключ.
        /// </summary>
        private int id { get; }

        /// <summary>
        /// Школьный класс (группа школьников).
        /// </summary>
        public Class Class { get; set; }

        /// <summary>
        /// Уроки.
        /// </summary>
        public List<SubjectPlan> SubjectPlans { get; set; }

        /// <summary>
        /// Учителя.
        /// </summary>
        public List<Teacher> Teachers { get; set; }

        /// <summary>
        /// Уроки (работы).
        /// </summary>
        private Job[] lessons { get; set; }

        /// <summary>
        /// Общее количество уроков в неделю.
        /// </summary>
        private int lessonsCount { get; }

        /// <summary>
        /// Вывод списка всех предметов
        /// </summary>
        public string AllSubjects
        {
            get
            {
                string result = "";
                for (int i = 0; i < SubjectPlans.Count; i++)
                {
                    result += SubjectPlans[i].Name;
                    if (i < SubjectPlans.Count - 1)
                    {
                        result += ", ";
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Конструктор Учебного плана.
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="class">Школьный класс.</param>
        /// <param name="subjects">Предметы.</param>
        /// <param name="teachers">Учителя, которые ведут данный Учебный план.</param>
        public Syllabus(int id, Class @class, List<SubjectPlan> subjects, List<Teacher> teachers)
        {
            this.id = id;
            Class = @class;
            SubjectPlans = subjects;
            Teachers = teachers;
            this.lessonsCount = calculateLessonsCount();
            lessons = new Job[lessonsCount];
            initializeLessons();
        }

        /// <summary>
        /// Преобразует уроки в работы.
        /// </summary>
        private void initializeLessons()
        {
            int index = 0;
            for (int i = 0; i < SubjectPlans.Count; i++)
            {
                for (int j = 0; j < SubjectPlans[i].Count; j++)
                {
                    Job newLesson = new Job(index,
                        SubjectPlans[i].Subject,
                        id);

                    lessons[index] = newLesson;
                    index++;
                }
            }
        }

        /// <summary>
        /// Общее количество уроков.
        /// </summary>
        /// <returns>Общее количество уроков.</returns>
        private int calculateLessonsCount()
        {
            int sum = 0;
            for (int i = 0; i < SubjectPlans.Count; i++)
            {
                sum += SubjectPlans[i].Count;
            }
            return sum;
        }

        public void SetLessons(Job[] lessons)
        {
            this.lessons = lessons;
        }

        public int Id => id;

        public Job[] Lessons => lessons;

        public int LessonsCount => lessonsCount;
    }
}
