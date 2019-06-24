using ListaProizvoda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ListaProizvoda.ViewModel
{
    public class ProizvodiEditModel
    {
        [Required]
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Opis { get; set; }

        public string Kategorija { get; set; }

        public string Proizvodjac { get; set; }

        public string Dobavljac { get; set; }

        public decimal? Cena { get; set; }

    }
}