namespace ScheduleMaker.OP.School
{
    /// <summary>
    /// Школьный класс (группа школьников).
    /// </summary>
    public class Class
    {
        private int id { get; }

        public int Id => id;

        public string Name { get; set; }

        /// <summary>
        /// Школьный класс (группа школьников).
        /// </summary>
        /// <param name="id">Ключ.</param>
        /// <param name="name">Название.</param>
        public Class(int id, string name)
        {
            this.id = id;
            Name = name;
        }
    }
}
