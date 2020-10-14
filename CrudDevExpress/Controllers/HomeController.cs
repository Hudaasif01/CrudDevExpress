using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudDevExpress.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        CrudDevExpress.Models.testEntities db = new CrudDevExpress.Models.testEntities();

        [ValidateInput(false)]
        public ActionResult GridView1Partial()
        {
            var model = db.customers;
            return PartialView("_GridView1Partial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] CrudDevExpress.Models.customer item)
        {
            var model = db.customers;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] CrudDevExpress.Models.customer item)
        {
            var model = db.customers;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.CustomerId == item.CustomerId);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] int CustomerId)
        {
            var model = db.customers;
            if (CustomerId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.CustomerId == CustomerId);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView1Partial", model.ToList());
        }
    }
}