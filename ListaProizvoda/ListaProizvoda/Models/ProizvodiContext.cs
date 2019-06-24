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

        public virtual DbSet<Proizvodi> Proizvodis { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Naziv)
                .IsUnicode(false);

            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Kategorija)
                .IsUnicode(false);

            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Dobavljac)
                .IsUnicode(false);

            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Proizvodjac)
                .IsUnicode(false);

            modelBuilder.Entity<Proizvodi>()
                .Property(e => e.Cena)
                .HasPrecision(19, 4);
        }

        public System.Data.Entity.DbSet<ListaProizvoda.ViewModel.ProizvodiViewModel> ProizvodiViewModels { get; set; }
    }
}
