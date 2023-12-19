using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RecruitementManagementApp.Models
{
    public class RecruitementDbContext : DbContext
    {


        public RecruitementDbContext(DbContextOptions options) : base(options)
        { }
        public virtual DbSet<Candidat> Candidats { get; set; }
        public virtual DbSet<Rh> RHs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Offre> Offres { get; set;}
        public DbSet<CandidatOffre> candidatOffres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("recruitement");

            modelBuilder.Entity<Candidat>().ToTable("TCandidat");
            modelBuilder.Entity<Candidat>().HasKey(p => p.IdCandidat);
            modelBuilder.Entity<Offre>().ToTable("TOffre");
            modelBuilder.Entity<Offre>().HasKey(p => p.codeOffre);
            modelBuilder.Entity<CandidatOffre>()
                .HasKey(bc => new { bc.IdCandidat, bc.codeOffre });

            modelBuilder.Entity<CandidatOffre>()
                .HasOne(bc => bc.Candidat)
                .WithMany(b => b.candidatOffres)
                .HasForeignKey(bc => bc.IdCandidat);

            modelBuilder.Entity<CandidatOffre>()
                .HasOne(bc => bc.Offre)
                .WithMany(c => c.candidatOffres)
                .HasForeignKey(bc => bc.codeOffre);


           modelBuilder.Entity<Rh>().ToTable("TRh");
            modelBuilder.Entity<Rh>().HasKey(p => p.IdRh);
            modelBuilder.Entity<Rh>()
             .HasMany(p => p.Offres)
             .WithOne(r => r.LeRh)
             .HasForeignKey(p => p.nameRh)
             .IsRequired();

            modelBuilder.Entity<User>().Property(p => p.Name)
                .HasColumnName("NomUser")
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Email)
                .HasColumnName("EmailUser")
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<User>().Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Numero)
          .HasColumnName("NumeroUser")
          .HasMaxLength(8)
          .IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Password)
          .HasColumnName("PasswordUser")
          .HasMaxLength(20)
          .IsRequired();
        }


    }
}
