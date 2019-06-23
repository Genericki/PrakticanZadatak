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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proizvodi()
        {
            Dobavljacs = new HashSet<Dobavljac>();
            Proizvodjacs = new HashSet<Proizvodjac>();
        }

        [Key]
        public int ProizvodID { get; set; }

        [StringLength(200)]
        public string Naziv { get; set; }

        [StringLength(50)]
        public string Opis { get; set; }

        public int KategorijaID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Cena { get; set; }

        public virtual Kategorija Kategorija { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dobavljac> Dobavljacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proizvodjac> Proizvodjacs { get; set; }
    }
}
