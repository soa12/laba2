using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PostgreSQLRepository;
using DomainModel;


namespace WebApplication.Controllers
{
    public class RecordsController : Controller
    {
        //private RecordContext db = new RecordContext();

        //private MSSQLRepository db = new MSSQLRepository();
        //private PostgreSQLRepository.PostgreSQLRepository db = new PostgreSQLRepository.PostgreSQLRepository();
        //private JsonRepository. db = new RecordRepository();

        private IPhoneBookRepository db = null;

        public RecordsController(IPhoneBookRepository rp)
        {
            this.db = rp;
        }

        public RecordsController()
        { }


        // GET: Records
        public ActionResult Index(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {

                return View(db.GetRecords(searchString));
            }
            //return View(db.Records.ToList());
            return View(db.GetRecords());
        }

        // GET: Records/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Record record = db.Read(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Records/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,PhoneNumber,Birthday")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Create(record);
                //db.Save();
                return RedirectToAction("Index");
            }

            return View(record);
        }

        // GET: Records/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Record record = db.Read(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Records/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,PhoneNumber,Birthday")] Record record)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(record).State = EntityState.Modified;
                //db.SaveChanges();
                db.Update(record);
                return RedirectToAction("Index");
            }
            return View(record);
        }

        // GET: Records/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Record record = db.Read(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Record record = db.Records.Find(id);
            //db.Records.Remove(record);
            //db.SaveChanges();
            db.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Report(int day=1)
        {

            //var record = db.GetRecords(day);
            //day = 7;
            return View(db.GetRecords(day));

        }


        //public ActionResult Test()
        //{
        //    ViewBag.Head = db.Test();
        //    //var days = db.Test();
        //    return View();
        //}


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
