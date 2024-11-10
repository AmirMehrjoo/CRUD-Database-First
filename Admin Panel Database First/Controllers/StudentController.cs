using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin_Panel_Database_First.Models;
using System.Net;
using System.IO;
using System.Data.Entity;

namespace Admin_Panel_Database_First.Controllers
{
    public class StudentController : Controller
    {
        db_StudentsEntities db = new db_StudentsEntities();

        public ActionResult Index()
        {
            return View(db.T_Students.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = db.T_Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Family, Age, PhoneNumber, Password, Email, Gender, Marital")] T_Students student, HttpPostedFileBase ImageUpload, string repeatPassword)
        {
            if (ModelState.IsValid)
            {
                if (student.Password != repeatPassword)
                {
                    ModelState.AddModelError("Password", "رمز شما با تکرار آن تفاوت دارد !");
                    return View(student);
                }

                string newImageName = "user.Png";

                if (ImageUpload != null)
                {
                    if (ImageUpload.ContentType != "image/jpeg" && ImageUpload.ContentType != "image/png")
                    {
                        ModelState.AddModelError("ImageName", "فرمت فایل شما باید png یا jpg باشد");
                        return View(student);
                    }
                    if (ImageUpload.ContentLength > 600000)
                    {
                        ModelState.AddModelError("ImageName", "حجم تصویر ارسالی شما باید حداکثر 600 کیلوبایت باشد");
                        return View(student);
                    }
                    newImageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(ImageUpload.FileName);
                    ImageUpload.SaveAs(Server.MapPath("/Images/") + newImageName);
                }

                student.ImageName = newImageName;
                student.RegisterDate = DateTime.Now;
                student.Status = true;
                db.T_Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = db.T_Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Name, Family, Age, PhoneNumber, Password, Email, Gender, Marital, ImageName, RegisterDate, Status")] T_Students student, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImageUpload != null)
                {
                    if (ImageUpload.ContentType != "image/jpeg" && ImageUpload.ContentType != "image/png")
                    {
                        ModelState.AddModelError("ImageName", "فرمت فایل شما باید png یا jpg باشد");
                        return View(student);
                    }
                    if (ImageUpload.ContentLength > 600000)
                    {
                        ModelState.AddModelError("ImageName", "حجم تصویر ارسالی شما باید حداکثر 600 کیلوبایت باشد");
                        return View(student);
                    }
                    string newImageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(ImageUpload.FileName);
                    ImageUpload.SaveAs(Server.MapPath("/Images/") + newImageName);
                    student.ImageName = newImageName;
                }
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = db.T_Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = db.T_Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            if (student != null)
            {
                db.T_Students.Remove(student);
                db.SaveChanges();

                if (student.ImageName != "user.png")
                {
                    if (System.IO.File.Exists(Server.MapPath("/Images/" + student.ImageName)))
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/" + student.ImageName));
                    }
                }               
                return RedirectToAction("Index");
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Route("AboutUs/{name}/{family}/{age}")] //changes the Route Address of this action and
                                                 //can get inputs with a costume Route arrange
        public ActionResult AboutUs(string name, string family, string age)
        {
            ViewBag.Name = name;
            ViewBag.Family = family;
            ViewBag.Age = age;

            return View();
        }
    }
}
