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

            modelBuilder.Entity<Kategorija>()
                .Property(e => e.Naziv)
                .IsUnicode(false);

            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Naziv)
                .IsUnicode(false);

            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Cena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Proizvodjac>()
                .Property(e => e.Naziv)
                .IsUnicode(false);
        }
    }
}
