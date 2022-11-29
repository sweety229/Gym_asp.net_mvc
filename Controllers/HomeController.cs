using GymProjectMvc.Models;
using GymProjectMvc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymProjectMvc.Controllers
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

        public ActionResult DataTable()
        {
            GymService service = new GymService();
            List<GymModel> list = service.getMemberList();
            return View(list);
        }

        public ActionResult AddMember(GymModel gymmodels)
        {
            GymService service = new GymService();
            int status = service.insertMember(gymmodels);

            return Redirect("/Home/DataTable");
        }

        public ActionResult edit(string id)
        {
            GymService service = new GymService();
            List<GymModel> list = service.getById(id);
            return View(list);

        }

        public ActionResult UpdateMember(GymModel gymmodels)
        {
            GymService service = new GymService();
            int status = service.UpdateMember(gymmodels);
            return Redirect("/Home/DataTable");
        }

        public ActionResult delete(string id)
        {
            GymService service = new GymService();
            int status = service.delete(id);
            return Redirect("/Home/DataTable");
        }
    }
}