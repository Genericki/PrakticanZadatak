namespace ListaProizvoda.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proizvodi")]
    public partial class Proizvodi
    {
        [Key]
        public int ProizvodID { get; set; }

        [StringLength(200)]
        public string Naziv { get; set; }

        [StringLength(50)]
        public string Opis { get; set; }

        public int? KategorijaID { get; set; }

        public int? DobavljacID { get; set; }

        public int? ProizvodjacID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Cena { get; set; }

        public virtual Dobavljac Dobavljac { get; set; }

        public virtual Kategorija Kategorija { get; set; }

        public virtual Proizvodjac Proizvodjac { get; set; }
    }
}
