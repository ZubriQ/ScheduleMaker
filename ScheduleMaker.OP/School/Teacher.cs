namespace ScheduleMaker.OP.School
{
    /// <summary>
    /// Учитель
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Уникальный ключ
        /// </summary>
        private int id { get; }

        /// <summary>
        /// Предметы, который ведет учитель
        /// </summary>
        public Subject[] Subject { get; set; }

        /// <summary>
        /// Возвращает список всех предметов
        /// </summary>
        public string AllSubjects
        {
            get
            {
                string result = "";
                for (int i = 0; i < Subject.Length; i++)
                {
                    result += Subject[i].Name;
                    if (i < Subject.Length - 1)
                    {
                        result += ", ";
                    }
                }
                return result;
            }
        }

        //private string teacherName

        /// <summary>
        /// Учитель
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="subject">Предметы.</param>
        public Teacher(int id, Subject[] subject)
        {
            this.id = id;
            Subject = subject;
        }

        /// <summary>
        /// Редактирование
        /// </summary>
        /// <param name="subject">Предметы.</param>
        public void Update(Subject[] subject)
        {
            Subject = subject;
        }

        public int Id => id;
    }
}
