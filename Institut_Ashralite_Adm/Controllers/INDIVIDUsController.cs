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
    public class INDIVIDUsController : Controller
    {
        private Institut_Ashralite_ADMEntities db = new Institut_Ashralite_ADMEntities();

        // GET: INDIVIDUs
        public ActionResult Index()
        {
            var iNDIVIDU = db.INDIVIDU.Include(i => i.REF_CIVILITE);
          

            ViewData["COURS"] = db.COURS.Include(c => c.INDIVIDU).Include(c => c.MATIERE).ToList(); 

            return View(iNDIVIDU.ToList());
        }

        public ActionResult Eleve()
        {
            var iNDIVIDU = db.INDIVIDU.Include(i => i.REF_CIVILITE);


            ViewData["COURS"] = db.COURS.Include(c => c.INDIVIDU).Include(c => c.MATIERE).ToList();

            return View(iNDIVIDU.ToList());

            //return View(iNDIVIDU.ToList());
        }

        // GET: INDIVIDUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INDIVIDU iNDIVIDU = db.INDIVIDU.Find(id);
            if (iNDIVIDU == null)
            {
                return HttpNotFound();
            }
            return View(iNDIVIDU);
        }

        // GET: INDIVIDUs/Create
        public ActionResult Create(int id, string titre)
        {

            ViewBag.id = id;
            ViewBag.titre = titre;
            ViewBag.ID_CIVILITE = new SelectList(db.REF_CIVILITE, "ID", "ABBREVIATION");
            return View();
        }

        // POST: INDIVIDUs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_CIVILITE,ID_METIER,NOM,PRENOM,EMAIL,PORTABLE,COMMENTAIRE,ACTIF,DATE_ACTIF,UTILISATEUR_CREATION,UTILISATEUR_MODIFICATION,DATE_CREATION,DATE_MODIFICATION,SEMAINE")] INDIVIDU iNDIVIDU)
        {
            iNDIVIDU.ACTIF = true;
            iNDIVIDU.DATE_ACTIF = DateTime.Now;
            iNDIVIDU.DATE_CREATION = DateTime.Now;
            iNDIVIDU.DATE_MODIFICATION = DateTime.Now;
            iNDIVIDU.UTILISATEUR_CREATION = "Yassine";
            iNDIVIDU.UTILISATEUR_MODIFICATION = "Yassine";

            if (ModelState.IsValid)
            {
                db.INDIVIDU.Add(iNDIVIDU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CIVILITE = new SelectList(db.REF_CIVILITE, "ID", "ABBREVIATION", iNDIVIDU.ID_CIVILITE);
            return View(iNDIVIDU);
        }

        // GET: INDIVIDUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INDIVIDU iNDIVIDU = db.INDIVIDU.Find(id);
            if (iNDIVIDU == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CIVILITE = new SelectList(db.REF_CIVILITE, "ID", "ABBREVIATION", iNDIVIDU.ID_CIVILITE);
            return View(iNDIVIDU);
        }

        // POST: INDIVIDUs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_CIVILITE,ID_METIER,NOM,PRENOM,EMAIL,PORTABLE,COMMENTAIRE,ACTIF,DATE_ACTIF,UTILISATEUR_CREATION,UTILISATEUR_MODIFICATION,DATE_CREATION,DATE_MODIFICATION,SEMAINE")] INDIVIDU iNDIVIDU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNDIVIDU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CIVILITE = new SelectList(db.REF_CIVILITE, "ID", "ABBREVIATION", iNDIVIDU.ID_CIVILITE);
            return View(iNDIVIDU);
        }

        // GET: INDIVIDUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INDIVIDU iNDIVIDU = db.INDIVIDU.Find(id);
            if (iNDIVIDU == null)
            {
                return HttpNotFound();
            }
            return View(iNDIVIDU);
        }

        // POST: INDIVIDUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INDIVIDU iNDIVIDU = db.INDIVIDU.Find(id);
            db.INDIVIDU.Remove(iNDIVIDU);
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
