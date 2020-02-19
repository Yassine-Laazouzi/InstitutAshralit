using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Institut_Ashralite_Adm.Models;
using Newtonsoft.Json.Linq;

namespace Institut_Ashralite_Adm.Controllers
{
    public class COURSController : Controller
    {
        private Institut_Ashralite_ADMEntities db = new Institut_Ashralite_ADMEntities();

        // GET: COURS
        public ActionResult Index()
        {
            var cOURS = db.COURS.Include(c => c.INDIVIDU).Include(c => c.MATIERE);
            return View(cOURS.ToList());
        }

        // GET: COURS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURS cOURS = db.COURS.Find(id);
            if (cOURS == null)
            {
                return HttpNotFound();
            }
            return View(cOURS);
        }

        // GET: COURS/Create
        public ActionResult Create()
        {
            ViewBag.ID_ENCADREUR = new SelectList(db.INDIVIDU.Where(i=> i.ID_METIER ==1), "ID", "NOM"); 
            ViewBag.ID_MATIERE = new SelectList(db.MATIERE, "ID", "ABBREVIATION");
            return View();
        }


        [HttpPost]
        public ActionResult Proc(int id_matiere)
        {
            var status = false;
            var message = "success";
            var value = "";
            db.D_supprimer_Matiere_avec_eleve(id_matiere);
        
            //Update data to database 

            message = "Absent";
            var response = new { value = value, status = status, message = message };
            JObject o = JObject.FromObject(response);
            bool result = true;


            return Json(result, JsonRequestBehavior.AllowGet);


            //return Content(o.ToString());
        }



        // POST: COURS/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_MATIERE,ID_ENCADREUR,LIBELLE,DATE_COURS,HEURE_DEBUT,HEURE_FIN,COMMENTAIRE,ACTIF,DATE_ACTIF,UTILISATEUR_CREATION,UTILISATEUR_MODIFICATION,DATE_CREATION,DATE_MODIFICATION")] COURS cOURS)
        {
            cOURS.DATE_ACTIF = DateTime.Now;
            cOURS.DATE_CREATION = DateTime.Now;
            cOURS.DATE_ACTIF = DateTime.Now;
            cOURS.DATE_COURS = DateTime.Now;
           

            cOURS.LIBELLE = db.MATIERE.Where(m => m.ID == cOURS.ID_MATIERE).Select(m => m.LIBELLE).FirstOrDefault();
            if (ModelState.IsValid)
            {
                db.COURS.Add(cOURS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ENCADREUR = new SelectList(db.INDIVIDU, "ID", "NOM", cOURS.ID_ENCADREUR);
            ViewBag.ID_MATIERE = new SelectList(db.MATIERE, "ID", "ABBREVIATION", cOURS.ID_MATIERE);
            return View(cOURS);
        }

        // GET: COURS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURS cOURS = db.COURS.Find(id);
            if (cOURS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ENCADREUR = new SelectList(db.INDIVIDU, "ID", "NOM", cOURS.ID_ENCADREUR);
            ViewBag.ID_MATIERE = new SelectList(db.MATIERE, "ID", "ABBREVIATION", cOURS.ID_MATIERE);
            return View(cOURS);
        }

        // POST: COURS/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_MATIERE,ID_ENCADREUR,LIBELLE,DATE_COURS,HEURE_DEBUT,HEURE_FIN,COMMENTAIRE,ACTIF,DATE_ACTIF,UTILISATEUR_CREATION,UTILISATEUR_MODIFICATION,DATE_CREATION,DATE_MODIFICATION")] COURS cOURS)
        {
            cOURS.LIBELLE = db.MATIERE.Where(m => m.ID == cOURS.ID_MATIERE).Select(m => m.LIBELLE).FirstOrDefault();
            cOURS.DATE_ACTIF = DateTime.Now;
            cOURS.UTILISATEUR_MODIFICATION = "Yassine";
            cOURS.UTILISATEUR_CREATION = db.COURS.Where(m => m.ID == cOURS.ID).Select(m => m.UTILISATEUR_CREATION).FirstOrDefault(); 
            cOURS.DATE_CREATION = db.COURS.Where(m => m.ID == cOURS.ID).Select(m => m.DATE_CREATION).FirstOrDefault(); 
            cOURS.DATE_MODIFICATION = DateTime.Now;
            cOURS.DATE_ACTIF = DateTime.Now;
            cOURS.DATE_COURS = DateTime.Now;
            cOURS.DATE_MODIFICATION = DateTime.Now;
            cOURS.ACTIF = true;
            
            if (ModelState.IsValid)
            {
                db.Entry(cOURS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ENCADREUR = new SelectList(db.INDIVIDU, "ID", "NOM", cOURS.ID_ENCADREUR);
            ViewBag.ID_MATIERE = new SelectList(db.MATIERE, "ID", "ABBREVIATION", cOURS.ID_MATIERE);
            return View(cOURS);
        }

        // GET: COURS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURS cOURS = db.COURS.Find(id);
            if (cOURS == null)
            {
                return HttpNotFound();
            }
            return View(cOURS);
        }

        // POST: COURS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COURS cOURS = db.COURS.Find(id);
            db.COURS.Remove(cOURS);
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
