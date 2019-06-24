using ListaProizvoda.DAL;
using ListaProizvoda.Models;
using ListaProizvoda.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ListaProizvoda.Controllers
{
    public class ProizvodiController : Controller
    {
        ProizvodiViewModel viewModel = new ProizvodiViewModel();

        private ProizvodiRepository proizvodiRepository;

        public ProizvodiController()
        {
            proizvodiRepository = new ProizvodiRepository();
        }

        // GET: Proizvodi
        public ActionResult Index()
        {
            IQueryable<Proizvodi> data = proizvodiRepository.GetAll();

            //var data = (from proizvod in dataProizvodi
            //            join kategorija in dataKategorija
            //            on proizvod.KategorijaID equals kategorija.KategorijaID
            //            join dobavljac in dataDobavljac
            //            on proizvod.DobavljacID equals dobavljac.DobavljacID
            //            join proizvodjac in dataProizvodjac
            //            on proizvod.ProizvodjacID equals proizvodjac.ProizvodjacID
            //            select new ProizvodiViewModel
            //            {
            //                ProizvodiID = proizvod.ProizvodID,
            //                Proizvod = proizvod.Naziv,
            //                Opis = proizvod.Opis,
            //                Kategorija = kategorija.Naziv,
            //                Proizvodjac = proizvodjac.Naziv,
            //                Dobavljac = dobavljac.Naziv,
            //                Cena = proizvod.Cena
            //            }).ToList();

            viewModel.JsonStrings = JsonConvert.SerializeObject(data);
            viewModel.DataProizvod = data;

            return View(viewModel);
        }

        // GET: Proizvodi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Proizvodi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proizvodi/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "")] ProizvodiEditModel editModel)
        {
            //Prevesti u EditViewModel
            Proizvodi proizvod = new Proizvodi();

            try
            {
               
                if (ModelState.IsValid)
                {
                    proizvod.Naziv = editModel.Naziv;
                    proizvod.Opis = editModel.Opis;
                    proizvod.Kategorija = editModel.Kategorija;
                    proizvod.Proizvodjac = editModel.Proizvodjac;
                    proizvod.Dobavljac = editModel.Dobavljac;
                    proizvod.Cena = editModel.Cena;

                    proizvodiRepository.Add(proizvod);
                    proizvodiRepository.SaveChanges();

                    return RedirectToAction("Index");

                }

            }
            catch(DataException ex)
            {
                ModelState.AddModelError("", ex);
            }
            return View(proizvod);
        }

        // GET: Proizvodi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var proizvod = proizvodiRepository.FindBy(id);

            if (proizvod == null)
                return HttpNotFound();

            ProizvodiViewModel viewModel = new ProizvodiViewModel();

            viewModel.Id = id.Value;
            viewModel.Naziv = proizvod.Naziv;
            viewModel.Opis = proizvod.Opis;
            viewModel.Kategorija = proizvod.Kategorija;
            viewModel.Proizvodjac = proizvod.Proizvodjac;
            viewModel.Dobavljac = proizvod.Dobavljac;
            viewModel.Cena = proizvod.Cena;

            return View(viewModel);
        }

        // POST: Proizvodi/Edit/5
        [HttpPost]
        public ActionResult Edit(ProizvodiViewModel viewModel)
        {
            try
            {
                if(viewModel == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var proizvodi = proizvodiRepository.FindBy(viewModel.Id);

                try
                {
                    proizvodi.ProizvodID = viewModel.Id;
                    proizvodi.Naziv = viewModel.Naziv;
                    proizvodi.Opis = viewModel.Opis;
                    proizvodi.Kategorija = viewModel.Kategorija;
                    proizvodi.Proizvodjac = viewModel.Proizvodjac;
                    proizvodi.Dobavljac = viewModel.Dobavljac;
                    proizvodi.Cena = viewModel.Cena;

                    proizvodiRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    throw;
                }

                // TODO: Add update logic here
            }
            catch
            {
                return View();
            }
        }

        // GET: Proizvodi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proizvodi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
