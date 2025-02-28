using Microsoft.AspNetCore.Mvc;
using CrudOpreation.Entity;
using CrudOpreation.Entity.Model;
using CrudOpreation.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using CrudOpreation.Service;
namespace CrudOpreation.Controllers
{
    public class RegisterController : Controller
    {

        private readonly IRegisterServices Db;

        public RegisterController(IRegisterServices Db)
        {
            this.Db = Db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterIndex(int id = 0)
        {

            var Model = new RegisterTblDto();

            if (id > 0)
            {
                var Data = Db.Edit(id);
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
            var Data = Db.List();
            ViewData["RegisterData"] = Data;
        }
        public IActionResult RegisterList()
        {
            DataList();
            return View();

        }

        [HttpPost]
        public IActionResult RegisterIndex(RegisterTbl Model, int id)
        {
            if (id > 0)
            {

                var Data = Db.Edit(id);
                if (Data != null)
                {
                    Data.Name = Model.Name;
                    Data.Email = Model.Email;
                    string Msg = Db.Update(Model, id);
                    ViewBag.Msg = Msg;
                }
               
                else
                {
                  ViewBag.Msg = "User not found";
                }
                return View();


            }
            else
            {

                RegisterTbl RegisterMaster = new RegisterTbl()
                {
                    Name = Model.Name,
                    Email = Model.Email
                };

                string msg = Db.Add(RegisterMaster);
                ViewBag.Msg = msg;

                return View();

            }
        }
        public ActionResult Delete(int id = 0)
        {
            if (id > 0)
            {
                string msg = Db.Delete(id);
                ViewBag.Msg = msg;
            }



            DataList();
            return RedirectToAction("ManagaeList", "RegisterTbl");
        }
    }
}
