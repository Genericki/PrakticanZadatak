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

        [StringLength(200)]
        public string Kategorija { get; set; }

        [StringLength(200)]
        public string Dobavljac { get; set; }

        [StringLength(200)]
        public string Proizvodjac { get; set; }

        [Column(TypeName = "money")]
        public decimal? Cena { get; set; }
    }
}
