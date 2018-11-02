using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPNETCoreMySQLConsoleApp
{
    public partial class animal_ownersContext : DbContext
    {
        public virtual DbSet<Animal> Animal { get; set; }

        public virtual DbSet<Owner> Owner { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=YourUser;password=YourPassword;database=animal_owners");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("animal", "animal_owners");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("owner", "animal_owners");

                entity.HasIndex(e => e.AnimalId)
                    .HasName("IX_Owner_AnimalId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AnimalId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Number).HasColumnType("int(11)");

                entity.Property(e => e.Value).HasColumnType("decimal(18,2)");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Owner)
                    .HasForeignKey(d => d.AnimalId)
                    .HasConstraintName("FK_Owner_Animal_AnimalId");
            });
        }
    }
}
