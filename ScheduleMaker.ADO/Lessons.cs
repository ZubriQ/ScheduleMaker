//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScheduleMaker.ADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lessons
    {
        public Nullable<int> syllabus_id { get; set; }
        public int quarter { get; set; }
        public int day_of_week { get; set; }
        public int number_of_lesson { get; set; }
        public int subject_id { get; set; }
        public Nullable<int> classroom_id { get; set; }
        public Nullable<int> teacher_id { get; set; }
        public int class_id { get; set; }
    
        public virtual Classes Classes { get; set; }
        public virtual Classrooms Classrooms { get; set; }
        public virtual Subjects Subjects { get; set; }
        public virtual Teachers Teachers { get; set; }
    }
}
