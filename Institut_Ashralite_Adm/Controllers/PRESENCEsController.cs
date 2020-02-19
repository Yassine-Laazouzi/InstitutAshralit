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
    public class PRESENCEsController : Controller
    {
        private Institut_Ashralite_ADMEntities db = new Institut_Ashralite_ADMEntities();

        // GET: PRESENCEs
        public ActionResult Index(int id,int? NB)
        {
          
            
            var iNSCRIPTION = db.INSCRIPTION.Include(i => i.INDIVIDU).Include(i => i.MATIERE);
            List<string> Matiere = db.PRESENCE.Include(p => p.COURS).Include(p => p.INDIVIDU).Where(p => p.COURS.ID_MATIERE == id).Where(p => p.SEMAINE == 1 || p.SEMAINE == 2 || p.SEMAINE == 3 || p.SEMAINE == 4).Distinct().Select(x => x.INDIVIDU.NOM).ToList();

            string m = db.MATIERE.Find(id).ToString();


            //db.MATIERE.Where(x => x.ID == id).Select(x => x.LIBELLE).ToString();

            // ViewBag.ID_COURS = new SelectList(db.COURS, "ID", "LIBELLE");
            //ViewBag.ID_ELEVE = new SelectList(db.INDIVIDU, "ID", "NOM");
            //ViewBag.thisMatiere = m.First().ToString();
            //           ViewBag.thisMatiere = m.First().ToString();

           var ThisMatiere = db.MATIERE.Where(x => x.ID== id).Select(x => new { x.LIBELLE }).ToList();



            ViewBag.ThisMatiere = ThisMatiere.First().LIBELLE;
            ViewBag.id = id;
            ViewBag.Moi = 1;
            ViewBag.Matiere = Matiere.Distinct();
            //db.PRESENCE.Include(p => p.COURS).Include(p => p.INDIVIDU).Where(p => p.COURS.ID_MATIERE == id).Where(p => p.SEMAINE == 1 || p.SEMAINE == 2 || p.SEMAINE == 3 || p.SEMAINE == 4).Select(x => x.INDIVIDU.NOM).Distinct() ;

            int? M = NB * 4; ;
          
            var pRESENCE = db.PRESENCE.Include(p => p.COURS).Include(p => p.INDIVIDU).Where(p => p.COURS.ID_MATIERE == id).Where(p => p.SEMAINE == 1 || p.SEMAINE == 2 || p.SEMAINE == 3 || p.SEMAINE == 4);
            ViewBag.MOISS = "Janvier";

            if (NB != null)
            {
                pRESENCE = db.PRESENCE.Include(p => p.COURS).Include(p => p.INDIVIDU).Where(p => p.COURS.ID_MATIERE == id).Where(p => p.SEMAINE == M - 3 || p.SEMAINE == M - 2 || p.SEMAINE == M - 1 || p.SEMAINE == M);
                ViewBag.Moi = NB;
             //   DateTime now = DateTime.;
               // DateTime d1 = new DateTime(2020,(int)NB ,1);

             //   ViewBag.MOISS = now.AddMonths(5).ToString("MMMM");
                ViewBag.MOISS = new DateTime(2020, (int)NB, 1).ToString("MMMM");


            }


         



            //////  var pRESENCE = db.PRESENCE.Include(p => p.COURS).Include(p => p.INDIVIDU).Where(p => p.COURS.ID_MATIERE == id).Where(p => p.SEMAINE == 1 || p.SEMAINE == 2 || p.SEMAINE == 3 || p.SEMAINE == 4) ;

            //var pRESENCE = db.PRESENCE.Include(p => p.COURS).Include(p => p.INDIVIDU);

            return View(pRESENCE.ToList());
        }



        public ActionResult Mois(int NB,int id)
        {

            int x = NB * 4;
           

            var pRESENCE = db.PRESENCE.Include(p => p.COURS).Include(p => p.INDIVIDU).Where(p => p.COURS.ID_MATIERE == id).Where(p => p.SEMAINE == x-3 || p.SEMAINE == x-2 || p.SEMAINE == x-1 || p.SEMAINE == x);

            //var pRESENCE = db.PRESENCE.Include(p => p.COURS).Include(p => p.INDIVIDU);

            return View(pRESENCE.ToList());
        }











        [HttpPost]
        public ActionResult saveuser(int id, string propertyName, bool value)
        {
            var status = false;
            var message = "";
            string test;

            if (value)
            {
                test = "1";

            }
            else
            {
                test = "0";
            }

            //Update data to database 

            var P = db.PRESENCE.Find(id);

            object updateValue = value;
            bool isValid = true;
            var myList = new List<bool>();
            myList.Add(false);
            myList.Add(true);


            if (propertyName == "PRESENT2")
            {
                int newRoleID = 0;
                if (int.TryParse(test, out newRoleID))
                {
                    updateValue = newRoleID;
                    //Update value field

                    //value = myList.FirstOrDefault(); 

                }
                else
                {
                    isValid = false;
                }

            }

            if (P != null)
            {
                db.Entry(P).Property("PRESENT").CurrentValue = value;
                db.SaveChanges();
                status = true;

            }
            else
            {
                message = "Error!";
            }
            if (value)
                message = "Present";
            
                message = "Absent";
            var response = new { value = value, status = status, message = message };
            JObject o = JObject.FromObject(response);
            
            return Content(o.ToString());
        }



        public ActionResult GetUserRoles(int id)
        {
            return Content("{'true':'Present','False':'Absent'}");
        }

        //public void Proc(int id_matiere,int id_eleve)
        //{
            
        //}
        [HttpPost]
        public ActionResult Proc(int id_matiere, int id_eleve)
        {
            var status = false;
            var message = "success";
            var value = "";
            db.D_supprimer_eleve_dun_cours(id_matiere, id_eleve);

            
            //Update data to database 

            message = "Absent";
            var response = new { value = value, status = status, message = message };
            JObject o = JObject.FromObject(response);
           bool result = true;


            return Json(result, JsonRequestBehavior.AllowGet);


            //return Content(o.ToString());
        }





















































        // GET: PRESENCEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRESENCE pRESENCE = db.PRESENCE.Find(id);
            if (pRESENCE == null)
            {
                return HttpNotFound();
            }
            return View(pRESENCE);
        }

        // GET: PRESENCEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_COURS = new SelectList(db.COURS, "ID", "LIBELLE");
            ViewBag.ID_ELEVE = new SelectList(db.INDIVIDU, "ID", "NOM");
            return View();
        }

        // POST: PRESENCEs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_COURS,ID_ELEVE,PRESENT,COMMENTAIRE,ACTIF,DATE_ACTIF,UTILISATEUR_CREATION,UTILISATEUR_MODIFICATION,DATE_CREATION,DATE_MODIFICATION,SEMAINE")] PRESENCE pRESENCE)
        {
            if (ModelState.IsValid)
            {
                db.PRESENCE.Add(pRESENCE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_COURS = new SelectList(db.COURS, "ID", "LIBELLE", pRESENCE.ID_COURS);
            ViewBag.ID_ELEVE = new SelectList(db.INDIVIDU, "ID", "NOM", pRESENCE.ID_ELEVE);
            return View(pRESENCE);
        }

        // GET: PRESENCEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRESENCE pRESENCE = db.PRESENCE.Find(id);
            if (pRESENCE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_COURS = new SelectList(db.COURS, "ID", "LIBELLE", pRESENCE.ID_COURS);
            ViewBag.ID_ELEVE = new SelectList(db.INDIVIDU, "ID", "NOM", pRESENCE.ID_ELEVE);
            return View(pRESENCE);
        }

        // POST: PRESENCEs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_COURS,ID_ELEVE,PRESENT,COMMENTAIRE,ACTIF,DATE_ACTIF,UTILISATEUR_CREATION,UTILISATEUR_MODIFICATION,DATE_CREATION,DATE_MODIFICATION,SEMAINE")] PRESENCE pRESENCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRESENCE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_COURS = new SelectList(db.COURS, "ID", "LIBELLE", pRESENCE.ID_COURS);
            ViewBag.ID_ELEVE = new SelectList(db.INDIVIDU, "ID", "NOM", pRESENCE.ID_ELEVE);
            return View(pRESENCE);
        }

        // GET: PRESENCEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRESENCE pRESENCE = db.PRESENCE.Find(id);
            if (pRESENCE == null)
            {
                return HttpNotFound();
            }
            return View(pRESENCE);
        }

        // POST: PRESENCEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRESENCE pRESENCE = db.PRESENCE.Find(id);
            db.PRESENCE.Remove(pRESENCE);
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
