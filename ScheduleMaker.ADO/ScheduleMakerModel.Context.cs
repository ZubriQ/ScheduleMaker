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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ScheduleMakerEntities : DbContext
    {
        public ScheduleMakerEntities()
            : base("name=ScheduleMakerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Classrooms> Classrooms { get; set; }
        public virtual DbSet<Lessons> Lessons { get; set; }
        public virtual DbSet<StudyLoad> StudyLoad { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Syllabi> Syllabi { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
    }
}
