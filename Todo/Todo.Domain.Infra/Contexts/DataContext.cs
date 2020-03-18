using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoItem>().ToTable("Todo");
            builder.Entity<TodoItem>().Property(x => x.Id);
            builder.Entity<TodoItem>().Property(x => x.User).HasColumnType("varchar(120)");
            builder.Entity<TodoItem>().Property(x => x.Title).HasColumnType("varchar(160)");
            builder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit");
            builder.Entity<TodoItem>().Property(x => x.Date);
            builder.Entity<TodoItem>().HasIndex(u => u.User);
        }
    }
}
