using Liga.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Liga.Data
{
    public partial class LIGAContext : DbContext
    {
        public LIGAContext()
        {
        }

        public LIGAContext(DbContextOptions<LIGAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asistenti> Asistentis { get; set; }
        public virtual DbSet<Igrac> Igracs { get; set; }

        public virtual DbSet<Kartonirani> Kartoniranis { get; set; }
        public virtual DbSet<Klub> Klubs { get; set; }
        public virtual DbSet<Kola> Kolas { get; set; }
        public virtual DbSet<Mjesto> Mjestos { get; set; }
        public virtual DbSet<Pozicija> Pozicijas { get; set; }
        public virtual DbSet<Rezultat> Rezultats { get; set; }
        public virtual DbSet<Strijelci> Strijelcis { get; set; }
        public virtual DbSet<Utakmice> Utakmices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            modelBuilder.Entity<Asistenti>(entity =>
            {
                entity.Property(e => e.IdIgrac).ValueGeneratedNever();

                entity.HasOne(d => d.IdIgracNavigation)
                    .WithOne(p => p.Asistenti)
                    .HasForeignKey<Asistenti>(d => d.IdIgrac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASISTENTI_IGRAC");
            });

            modelBuilder.Entity<Igrac>(entity =>
            {
                entity.Property(e => e.Ime).IsUnicode(false);

                entity.Property(e => e.Prezime).IsUnicode(false);

                entity.HasOne(d => d.IdKlubNavigation)
                    .WithMany(p => p.Igracs)
                    .HasForeignKey(d => d.IdKlub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IGRAC_KLUB");

                entity.HasOne(d => d.IdPozicijaNavigation)
                    .WithMany(p => p.Igracs)
                    .HasForeignKey(d => d.IdPozicija)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IGRAC_POZICIJA");
            });

            modelBuilder.Entity<Kartonirani>(entity =>
            {
                entity.Property(e => e.IdIgrac).ValueGeneratedNever();

                entity.HasOne(d => d.IdIgracNavigation)
                    .WithOne(p => p.Kartonirani)
                    .HasForeignKey<Kartonirani>(d => d.IdIgrac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KARTONIRANI_IGRAC");
            });

            modelBuilder.Entity<Klub>(entity =>
            {
                entity.Property(e => e.Naziv).IsUnicode(false);

                entity.HasOne(d => d.IdMjestoNavigation)
                    .WithMany(p => p.Klubs)
                    .HasForeignKey(d => d.IdMjesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KLUB_MJESTO");
            });

            modelBuilder.Entity<Kola>(entity =>
            {
                entity.Property(e => e.RedniBroj).IsUnicode(false);
            });

            modelBuilder.Entity<Mjesto>(entity =>
            {
                entity.Property(e => e.NazivMjesta).IsUnicode(false);
            });

            modelBuilder.Entity<Pozicija>(entity =>
            {
                entity.Property(e => e.NazivPozicije).IsUnicode(false);
            });

            modelBuilder.Entity<Rezultat>(entity =>
            {
                entity.HasKey(e => new { e.IdUtakmica, e.IdKlub1, e.IdKlub2 });

                entity.Property(e => e.Rezultat1).IsUnicode(false);

                entity.HasOne(d => d.IdKlub1Navigation)
                    .WithMany(p => p.RezultatIdKlub1Navigations)
                    .HasForeignKey(d => d.IdKlub1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REZULTAT_KLUB1");

                entity.HasOne(d => d.IdKlub2Navigation)
                    .WithMany(p => p.RezultatIdKlub2Navigations)
                    .HasForeignKey(d => d.IdKlub2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REZULTAT_KLUB2");

                entity.HasOne(d => d.IdUtakmicaNavigation)
                    .WithMany(p => p.Rezultats)
                    .HasForeignKey(d => d.IdUtakmica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REZULTAT_UTAKMICE");
            });

            modelBuilder.Entity<Strijelci>(entity =>
            {
                entity.Property(e => e.IdIgrac).ValueGeneratedNever();

                entity.HasOne(d => d.IdIgracNavigation)
                    .WithOne(p => p.Strijelci)
                    .HasForeignKey<Strijelci>(d => d.IdIgrac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STRIJELCI_IGRAC");
            });

            modelBuilder.Entity<Utakmice>(entity =>
            {
                entity.HasOne(d => d.IdKoloNavigation)
                    .WithMany(p => p.Utakmices)
                    .HasForeignKey(d => d.IdKolo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UTAKMICE_KOLA");

                entity.HasOne(d => d.IdMjestoNavigation)
                    .WithMany(p => p.Utakmices)
                    .HasForeignKey(d => d.IdMjesto)
                    .HasConstraintName("FK_UTAKMICE_MJESTO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
