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
    public class INSCRIPTIONsController : Controller
    {
        private Institut_Ashralite_ADMEntities db = new Institut_Ashralite_ADMEntities();

        // GET: INSCRIPTIONs
        public ActionResult Index()
        {
            var iNSCRIPTION = db.INSCRIPTION.Include(i => i.INDIVIDU).Include(i => i.MATIERE);
            return View(iNSCRIPTION.ToList());
        }

        // GET: INSCRIPTIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSCRIPTION iNSCRIPTION = db.INSCRIPTION.Find(id);
            if (iNSCRIPTION == null)
            {
                return HttpNotFound();
            }
            return View(iNSCRIPTION);
        }



        // GET: INSCRIPTIONs/Create
        public ActionResult AjoutEleve(int id)
        {
            ViewBag.ID_ELEVE = new SelectList(db.INDIVIDU, "ID", "NOM");
            ViewBag.ID_MATIERE = new SelectList(db.MATIERE, "ID", "ABBREVIATION");
            return View();
        }
        public ActionResult CreateapartirMatiere(int id,string libele)
        {
            /*List<int>*/
            var tempIdList = db.INSCRIPTION.Where(x => x.ID_MATIERE == id).Select(x=>x.ID_ELEVE).ToList();

            var temp = db.INDIVIDU.Where(q => !tempIdList.Contains(q.ID));


            ViewBag.ID_ELEVE = new SelectList(db.INDIVIDU.Where(q => !tempIdList.Contains(q.ID)), "ID", "NOM");
           // var ss = new SelectList(temp, "ID", "ABBREVIATION");

            //ViewBag.ID_MATIERE = new SelectList(db.MATIERE, "ID", "ABBREVIATION");

           // ViewBag.ID_ELEVE = ss;
            ViewBag.ID_MATIERE = id;
            ViewBag.m = libele;


            return View();

        }

        // GET: INSCRIPTIONs/Create
        public ActionResult Create()
        {
            ViewBag.ID_ELEVE = new SelectList(db.INDIVIDU, "ID", "NOM");
            ViewBag.ID_MATIERE = new SelectList(db.MATIERE, "ID", "ABBREVIATION");
            return View();
        }

        // POST: INSCRIPTIONs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_MATIERE,ID_ELEVE,COMMENTAIRE,ACTIF,DATE_ACTIF,UTILISATEUR_CREATION,UTILISATEUR_MODIFICATION,DATE_CREATION,DATE_MODIFICATION")] INSCRIPTION iNSCRIPTION)
        {
            iNSCRIPTION.DATE_ACTIF = DateTime.Now;
            iNSCRIPTION.DATE_CREATION = DateTime.Now;
            iNSCRIPTION.DATE_MODIFICATION = DateTime.Now;
            iNSCRIPTION.UTILISATEUR_CREATION = "Yassine";
            iNSCRIPTION.UTILISATEUR_MODIFICATION = "Yassine";
            db.I_Ligne_Table_Presence(iNSCRIPTION.ID_MATIERE, iNSCRIPTION.ID_ELEVE);


            if (ModelState.IsValid)
            {
                db.INSCRIPTION.Add(iNSCRIPTION);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Index","COURS");

            }

            ViewBag.ID_ELEVE = new SelectList(db.INDIVIDU, "ID", "NOM", iNSCRIPTION.ID_ELEVE);
            ViewBag.ID_MATIERE = new SelectList(db.MATIERE, "ID", "ABBREVIATION", iNSCRIPTION.ID_MATIERE);

            //return View(iNSCRIPTION);
              return Redirect("COURS/Index"); 

        }

        // GET: INSCRIPTIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSCRIPTION iNSCRIPTION = db.INSCRIPTION.Find(id);
            if (iNSCRIPTION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ELEVE = new SelectList(db.INDIVIDU, "ID", "NOM", iNSCRIPTION.ID_ELEVE);
            ViewBag.ID_MATIERE = new SelectList(db.MATIERE, "ID", "ABBREVIATION", iNSCRIPTION.ID_MATIERE);
            return View(iNSCRIPTION);
        }

        // POST: INSCRIPTIONs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_MATIERE,ID_ELEVE,COMMENTAIRE,ACTIF,DATE_ACTIF,UTILISATEUR_CREATION,UTILISATEUR_MODIFICATION,DATE_CREATION,DATE_MODIFICATION")] INSCRIPTION iNSCRIPTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNSCRIPTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ELEVE = new SelectList(db.INDIVIDU, "ID", "NOM", iNSCRIPTION.ID_ELEVE);
            ViewBag.ID_MATIERE = new SelectList(db.MATIERE, "ID", "ABBREVIATION", iNSCRIPTION.ID_MATIERE);
            return View(iNSCRIPTION);
        }

        // GET: INSCRIPTIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INSCRIPTION iNSCRIPTION = db.INSCRIPTION.Find(id);
            if (iNSCRIPTION == null)
            {
                return HttpNotFound();
            }
            return View(iNSCRIPTION);
        }

        // POST: INSCRIPTIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INSCRIPTION iNSCRIPTION = db.INSCRIPTION.Find(id);
            db.INSCRIPTION.Remove(iNSCRIPTION);
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
