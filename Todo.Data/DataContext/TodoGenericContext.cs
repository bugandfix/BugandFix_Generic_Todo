

namespace Todo.Data.DataContext;

using Microsoft.EntityFrameworkCore;
using Todo.Core.Entities;

public partial class ApplicationDataContext : DbContext
{
    public ApplicationDataContext()
    {
    }

    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todo> Todo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
            .HasColumnName("TodoId");

            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Description)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false);
        });
    }
}
