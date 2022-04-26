using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Test_Colleague.Models
{
    public partial class DB_COLLEAGUEContext : DbContext
    {
        public DB_COLLEAGUEContext()
        {
        }

        public DB_COLLEAGUEContext(DbContextOptions<DB_COLLEAGUEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TGroup> TGroups { get; set; }
        public virtual DbSet<TGroupUser> TGroupUsers { get; set; }
        public virtual DbSet<TMessage> TMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LJGGBBU\\SQLEXPRESS;Database=DB_COLLEAGUE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<TGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK__T_GROUP__149AF36AD1D745CC");

                entity.ToTable("T_GROUP");
            });

            modelBuilder.Entity<TGroupUser>(entity =>
            {
                entity.HasKey(e => e.GroupUserId)
                    .HasName("PK__T_GROUP___37F70716CE9B73DB");

                entity.ToTable("T_GROUP_USER");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TGroupUsers)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__T_GROUP_U__Group__4BAC3F29");
            });

            modelBuilder.Entity<TMessage>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .HasName("PK__T_MESSAG__C87C0C9C15C36E54");

                entity.ToTable("T_MESSAGE");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TMessages)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__T_MESSAGE__Group__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
