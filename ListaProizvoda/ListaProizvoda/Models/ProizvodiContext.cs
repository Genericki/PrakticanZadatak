namespace ListaProizvoda.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProizvodiContext : DbContext
    {
        public ProizvodiContext()
            : base("name=ProizvodiContext")
        {
        }

        public virtual DbSet<Dobavljac> Dobavljacs { get; set; }
        public virtual DbSet<Kategorija> Kategorijas { get; set; }
        public virtual DbSet<Proizvodi> Proizvodis { get; set; }
        public virtual DbSet<Proizvodjac> Proizvodjacs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dobavljac>()
                .Property(e => e.Naziv)
                .IsUnicode(false);

            modelBuilder.Entity<Dobavljac>()
                .Property(e => e.Kontakt)
                .IsUnicode(false);

            modelBuilder.Entity<Dobavljac>()
                .HasMany(e => e.Proizvodis)
                .WithMany(e => e.Dobavljacs)
                .Map(m => m.ToTable("ProizvodDobavljac").MapLeftKey("DobavljacID").MapRightKey("ProizvodID"));

            modelBuilder.Entity<Kategorija>()
                .Property(e => e.Naziv)
                .IsUnicode(false);

            modelBuilder.Entity<Kategorija>()
                .HasMany(e => e.Proizvodis)
                .WithRequired(e => e.Kategorija)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Naziv)
                .IsUnicode(false);

            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Cena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Proizvodi>()
                .HasMany(e => e.Proizvodjacs)
                .WithMany(e => e.Proizvodis)
                .Map(m => m.ToTable("ProizvodProizvodjac").MapLeftKey("ProizvodID").MapRightKey("ProizvodjacID"));

            modelBuilder.Entity<Proizvodjac>()
                .Property(e => e.Naziv)
                .IsUnicode(false);
        }
    }
}
