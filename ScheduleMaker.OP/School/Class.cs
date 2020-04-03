namespace ScheduleMaker.OP.School
{
    /// <summary>
    /// Школьный класс (группа школьников).
    /// </summary>
    public class Class
    {
        private int id { get; }

        public int Id => id;

        private string name { get; }

        public string Name => name;

        /// <summary>
        /// Школьный класс (группа школьников).
        /// </summary>
        /// <param name="id">Ключ.</param>
        /// <param name="name">Название.</param>
        public Class(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
