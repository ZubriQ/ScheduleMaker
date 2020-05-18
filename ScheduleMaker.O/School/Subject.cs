namespace ScheduleMaker.OP.School
{
    /// <summary>
    /// Предмет.
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Уникальный ключ.
        /// </summary>
        private int id { get; }

        /// <summary>
        /// Название предмета.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сложность предмета.
        /// </summary>
        public int Difficulty { get; set; } // пока что не используется

        /// <summary>
        /// Конструктор предмета.
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="name">Название предмета.</param>
        /// <param name="difficulty">Сложность предмета.</param>
        public Subject(int id, string name, int difficulty)
        {
            this.id = id;
            Name = name;
            Difficulty = difficulty;
        }

        public int Id => id;
    }
}
