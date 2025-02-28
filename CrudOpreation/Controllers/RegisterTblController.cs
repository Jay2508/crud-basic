using CrudOpreation.Entity;
using CrudOpreation.Entity.Model;
using CrudOpreation.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace CrudOpreation.Controllers
{
    public class RegisterTblController : Controller
    {

        private EntityDbContext db;

        public RegisterTblController(EntityDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public IActionResult FormAdd(int id = 0)
        {

            var Model = new RegisterTblDto();

            if (id > 0)
            {
                var Data = db.RegisterTbls.Find(id);
                if (Data != null)
                {
                    Model.RegId = Data.RegId;
                    Model.Name = Data.Name;
                    Model.Email = Data.Email;

                }

                return View(Model);
            }
            return View();

        }
        void DataList()
        {
            var Data = db.RegisterTbls.ToList();
            ViewData["RegisterData"] = Data;
        }
        public IActionResult ManagaeList()
        {
            DataList();
            return View();

        }

        [HttpPost]
        public IActionResult FormAdd(RegisterTblDto model, int id)
        {
            if (id > 0)
            {

                var UpdateData = db.RegisterTbls.Find(id);
                if (UpdateData != null)
                {

                    UpdateData.Name = model.Name;
                    UpdateData.Email = model.Email;

                    db.SaveChanges();
                    ViewBag.Msg = "Your data was successfully updated.";
                }
                else
                {
                    ViewBag.NotMsg = "User not found";
                }
                return View();


            }
            else
            {

                db.RegisterTbls.Add(new RegisterTbl()
                {
                    Name = model.Name,
                    Email = model.Email
                });
                db.SaveChanges();
                ViewBag.Msg = "Successfully Store Data";
                return View();
            }
        }
        public ActionResult Delete(int id = 0)
        {
            if (id > 0)
            {
                var Data = db.RegisterTbls.Find(id);
                if (Data == null)
                {
                    ViewBag.Msg = "Data Not Find";
                }
                else
                {
                    db.RegisterTbls.Remove(Data);
                    db.SaveChanges();
                    ViewBag.Msg = "Your Data Successfully Delete.....";
                }

            }
            else
            {
                ViewBag.Msg = "Error in Db";

            }

            DataList();
            return RedirectToAction("ManagaeList", "RegisterTbl");
        }
    }
}