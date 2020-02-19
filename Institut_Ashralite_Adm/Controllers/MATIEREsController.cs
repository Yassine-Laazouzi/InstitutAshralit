using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Institut_Ashralite_Adm.Models;

namespace Institut_Ashralite_Adm.Controllers
{
    public class MATIEREsController : Controller
    {
        private Institut_Ashralite_ADMEntities db = new Institut_Ashralite_ADMEntities();

        // GET: MATIEREs
        public ActionResult Index()
        {
            return View(db.MATIERE.ToList());
        }

        // GET: MATIEREs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATIERE mATIERE = db.MATIERE.Find(id);
            if (mATIERE == null)
            {
                return HttpNotFound();
            }
            return View(mATIERE);
        }

        public ActionResult CreateProfesseur()
        {
            ViewBag.ID_CIVILITE = new SelectList(db.REF_CIVILITE, "ID", "ABBREVIATION");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProfesseur([Bind(Include = "ID,ID_CIVILITE,ID_METIER,NOM,PRENOM,EMAIL,PORTABLE,COMMENTAIRE,ACTIF,DATE_ACTIF,UTILISATEUR_CREATION,UTILISATEUR_MODIFICATION,DATE_CREATION,DATE_MODIFICATION,SEMAINE")] INDIVIDU iNDIVIDU)
        {
            if (ModelState.IsValid)
            {
                db.INDIVIDU.Add(iNDIVIDU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CIVILITE = new SelectList(db.REF_CIVILITE, "ID", "ABBREVIATION", iNDIVIDU.ID_CIVILITE);
            return View(iNDIVIDU);
        }






        // GET: MATIEREs/Create
        public ActionResult Create()
        {

            ViewBag.Prof = new SelectList(db.INDIVIDU.Where(i => i.ID_METIER == 1), "ID", "NOM").ToList(); 
            return View();
        }


        // POST: MATIEREs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ABBREVIATION,LIBELLE,COMMENTAIRE,ACTIF,DATE_ACTIF,UTILISATEUR_CREATION,UTILISATEUR_MODIFICATION,DATE_CREATION,DATE_MODIFICATION")] MATIERE mATIERE)
        {
            mATIERE.DATE_ACTIF = DateTime.Now;
            mATIERE.DATE_CREATION = DateTime.Now;
            mATIERE.DATE_MODIFICATION = DateTime.Now;
            mATIERE.UTILISATEUR_CREATION = "Yassine";
            mATIERE.UTILISATEUR_MODIFICATION = "Yassine";
            mATIERE.LIBELLE = mATIERE.ABBREVIATION;
            mATIERE.ACTIF = true;

            if (ModelState.IsValid)
            {
                db.MATIERE.Add(mATIERE);
                int id = mATIERE.ID;
                db.SaveChanges();
                db.I_Ajout_Matiere(id);
               
        
                return RedirectToAction("Index");
            }

           
            return View(mATIERE);
        }

        // GET: MATIEREs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATIERE mATIERE = db.MATIERE.Find(id);
            if (mATIERE == null)
            {
                return HttpNotFound();
            }
            return View(mATIERE);
        }

        // POST: MATIEREs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ABBREVIATION,LIBELLE,COMMENTAIRE,ACTIF,DATE_ACTIF,UTILISATEUR_CREATION,UTILISATEUR_MODIFICATION,DATE_CREATION,DATE_MODIFICATION")] MATIERE mATIERE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mATIERE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mATIERE);
        }

        // GET: MATIEREs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATIERE mATIERE = db.MATIERE.Find(id);
            if (mATIERE == null)
            {
                return HttpNotFound();
            }
            return View(mATIERE);
        }

        // POST: MATIEREs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MATIERE mATIERE = db.MATIERE.Find(id);
            db.MATIERE.Remove(mATIERE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
