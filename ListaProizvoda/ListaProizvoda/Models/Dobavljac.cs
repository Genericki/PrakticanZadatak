namespace ListaProizvoda.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dobavljac")]
    public partial class Dobavljac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dobavljac()
        {
            Proizvodis = new HashSet<Proizvodi>();
        }

        public int DobavljacID { get; set; }

        [StringLength(200)]
        public string Naziv { get; set; }

        [StringLength(50)]
        public string Kontakt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proizvodi> Proizvodis { get; set; }
    }
}
