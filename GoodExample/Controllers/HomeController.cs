using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasySale.Models;
using EasySale.Data;
using EasySale.Core;
using Newtonsoft.Json;

namespace EasySale.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private AppDbContext db = new AppDbContext();
         

        public ActionResult Index()
        {
            return View();
        }


        //public JsonResult getAll()
        //{
        //    var employeeList = db.stocks.Include("prices").ToList();
        //    var emp = JsonConvert.SerializeObject(employeeList, Formatting.Indented,
        //                    new JsonSerializerSettings
        //                    {
        //                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //                    });
        //    var replaceDatas = emp.Replace("\"", "");
        //    var againReplace = replaceDatas.Replace("\r\n", "");
        //    var againAagain = againReplace.Replace("\u0026", "");
        //    return Json(againAagain, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult getProductById(string Id)
        //{
        //    int no = Convert.ToInt32(Id);
        //    var list = db.stocks.Include("prices").Where(x => x.stock_id == no).FirstOrDefault();
        //    return Json(list, JsonRequestBehavior.AllowGet);
        //}
        ////public string UpdateEmployee(Employee Emp)
        ////{
        ////    if (Emp != null)
        ////    {
        ////        using (SampleDBEntities dataContext = new SampleDBEntities())
        ////        {
        ////            int no = Convert.ToInt32(Emp.Id);
        ////            var employeeList = dataContext.Employees.Where(x => x.Id == no).FirstOrDefault();
        ////            employeeList.name = Emp.name;
        ////            employeeList.Age = Emp.Age;
        ////            employeeList.email = Emp.email;
        ////            dataContext.SaveChanges();
        ////            return "Employee Updated";
        ////        }
        ////    }
        ////    else
        ////    {
        ////        return "Invalid Employee";
        ////    }
        ////}

        //public string AddRecord(stock_tb stock)
        //{
        //    if (stock != null)
        //    {
        //        db.stocks.Add(stock);
        //            db.SaveChanges();
        //            return "Product Added!";
        //    }
        //    else
        //    {
        //        return "Invalid Employee";
        //    }
        //}

        //public string deleteProduct(stock_tb stock)
        //{
        //    if (stock != null)
        //    {
        //        int no = Convert.ToInt32(stock.stock_id);
        //        var list = db.stocks.Include("prices").Where(x => x.stock_id == no).FirstOrDefault();
        //            db.stocks.Remove(list);
        //            db.SaveChanges();
        //            return "Product Deleted";
        //    }
        //    else
        //    {
        //        return "Invalid Product";
        //    }
        //}
    }
}
