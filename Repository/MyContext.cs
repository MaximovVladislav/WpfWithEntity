using System.Data.Entity;
using Model;

namespace Repository
{
    /// <summary>
    /// Контекст данных
    /// </summary>
    [DbConfigurationType(typeof(MyDbConfiguration))]
    internal class MyContext : DbContext
    {
        private static readonly string ConnectionString = ConnectionManager.GetConnectionString();

        public MyContext() : base(ConnectionString)
        {
            
        }

        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Маппинг сущностей к таблицам
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.FirstName).HasColumnName("FirstName");
            modelBuilder.Entity<User>().Property(x => x.LastName).HasColumnName("LastName");
            modelBuilder.Entity<User>().Property(x => x.DateOfBirth).HasColumnName("DateOfBirth");

            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}