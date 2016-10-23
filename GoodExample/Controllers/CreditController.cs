using EasySale.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasySale.Controllers
{
    public class CreditController : Controller
    {
        //
        // GET: /Credit/
        private AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getAll()
        {
            var list = db.creditDetails.ToList();
                var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
        }
    }
}
