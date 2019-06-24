using ListaProizvoda.Models;
using ListaProizvoda.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ListaProizvoda.DAL
{
    public class ProizvodiRepository : DataRepository<ProizvodiContext, Proizvodi>
    {
        public override IQueryable<Proizvodi> GetAll()
        {
            return base.GetAll();
        }

        public override void Add(Proizvodi entity)
        {
            base.Add(entity);
        }

        public override void Edit(Proizvodi entity)
        {
            base.Edit(entity);
        }

        public Proizvodi FindBy(int? id)
        {
            var query = GetAll().FirstOrDefault(x => x.ProizvodID == id);
            return query;
        }

    }
}