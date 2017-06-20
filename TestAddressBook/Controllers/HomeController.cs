using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestAddressBook.Models;
using TestAddressBook.Helpers;

namespace TestAddressBook.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        #region simple view methods
        public ActionResult About()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {                
                throw ExceptionTools.PropagateDetailsException(ex);
            }
            
        }

        public ActionResult Contact()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {                
                throw ExceptionTools.PropagateDetailsException(ex);;
            }
            
        }

        public ActionResult Error()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }
        #endregion

        #region CRUD operations
        // GET: Home
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await db.Consumers.ToListAsync());
            }
            catch (Exception ex)
            {                
                throw ExceptionTools.PropagateDetailsException(ex);
            }
            
        }

        // GET: Home/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Consumer consumer = await db.Consumers.FindAsync(id);
                if (consumer == null)
                {
                    return HttpNotFound();
                }
                return View(consumer);
            }
            catch (Exception ex)
            {                
                throw ExceptionTools.PropagateDetailsException(ex);
            }
            
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consumers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Surname,TelephoneNumber,Address")] Consumer consumer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Consumers.Add(consumer);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(consumer);
            }
            catch (Exception ex)
            {
                throw ExceptionTools.PropagateDetailsException(ex);
            }
            
        }

        // GET: Home/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Consumer consumer = await db.Consumers.FindAsync(id);
                if (consumer == null)
                {
                    return HttpNotFound();
                }
                return View(consumer);
            }
            catch (Exception ex)
            {                
                throw ExceptionTools.PropagateDetailsException(ex);
            }
           
        }

        // POST: Consumers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Surname,TelephoneNumber,Address")] Consumer consumer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(consumer).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(consumer);
            }
            catch (Exception ex)
            {

                throw ExceptionTools.PropagateDetailsException(ex);
            }
            
        }

        // GET: Home/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Consumer consumer = await db.Consumers.FindAsync(id);
                if (consumer == null)
                {
                    return HttpNotFound();
                }
                return View(consumer);
            }
            catch (Exception ex)
            {
                throw ExceptionTools.PropagateDetailsException(ex);
            }
            
        }

        // POST: Consumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {

            try
            {
                Consumer consumer = await db.Consumers.FindAsync(id);
                db.Consumers.Remove(consumer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ExceptionTools.PropagateDetailsException(ex);
            }
            
        }

        /// <summary>
        /// Checks if user exists in DataBase
        /// </summary>
        /// <param name="Surname">Customer surname</param>
        /// /// <param name="Name">Customer name</param>
        /// <returns>true if exists else flase</returns>
        public JsonResult CheckUserSurname(string Surname, string Name)
        {
            try
            {
                var result = true;
                var user = db.Consumers.Where(x => x.Surname == Surname && x.Name == Name).FirstOrDefault();

                if (user != null)
                    result = false;

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ExceptionTools.PropagateDetailsException(ex);
            }
        }
        #endregion

        #region print
        [HttpGet]
        public async Task<ActionResult> Print(int? id)
        {
            try
            {
                if (id == null)
                    return RedirectToAction("Index");

                var consumer = db.Consumers.Where(x => x.Id == id).FirstOrDefault();

                return new Rotativa.MVC.PartialViewAsPdf("_Print", consumer) { FileName = string.Format("consumer-{0}.pdf", consumer.Id), RotativaOptions = new Rotativa.Core.DriverOptions() { PageOrientation = Rotativa.Core.Options.Orientation.Portrait } };
            }
            catch (Exception ex)
            {
                throw ExceptionTools.PropagateDetailsException(ex);
            }
        }

        public async Task<ActionResult> PrintList(int[] ids)
        {
            try
            {
                if (ids == null)
                    return RedirectToAction("Index");

                var consumers = db.Consumers.Where(x => ids.Contains(x.Id)).ToList();

                return new Rotativa.MVC.PartialViewAsPdf("_PrintList", consumers) { FileName = string.Format("consumers.pdf", consumers), RotativaOptions = new Rotativa.Core.DriverOptions() { PageOrientation = Rotativa.Core.Options.Orientation.Portrait } };
            }
            catch (Exception ex)
            {
                throw ExceptionTools.PropagateDetailsException(ex);
            }
        }
        #endregion

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
