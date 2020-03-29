namespace ScheduleMaker.OP.School
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
        /// Название класса.
        /// </summary>
        private string className { get; }

        /// <summary>
        /// Уроки.
        /// </summary>
        private SubjectPlan[] subjectPlans { get; }

        /// <summary>
        /// Учителя.
        /// </summary>
        private Teacher[] teachers { get; }

        /// <summary>
        /// Уроки (работы).
        /// </summary>
        private Job[] lessons { get; }

        /// <summary>
        /// Общее количество уроков в неделю.
        /// </summary>
        private int lessonsCount { get; }

        /// <summary>
        /// Конструктор Учебного плана.
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="className">Наименование школьного класса.</param>
        /// <param name="subjects">Предметы.</param>
        /// <param name="teachers">Учителя.</param>
        public Syllabus(int id, string className, SubjectPlan[] subjects, Teacher[] teachers)
        {
            this.id = id;
            this.className = className;
            this.subjectPlans = subjects;
            this.teachers = teachers;
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
            for (int i = 0; i < SubjectPlans.Length; i++)
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
            for (int i = 0; i < SubjectPlans.Length; i++)
            {
                sum += SubjectPlans[i].Count;
            }
            return sum;
        }

        public int Id => id;

        public string ClassName => className;

        public SubjectPlan[] SubjectPlans => subjectPlans;

        public Teacher[] Teachers => teachers;

        public Job[] Lessons => lessons;

        public int LessonsCount => lessonsCount;
    }
}
