using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasySale.Models;
using EasySale.Data;

namespace EasySale.Controllers
{
    public class SalesController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult getAll()
        {
            using (AppDbContext dataContext = new AppDbContext())
            {
                var employeeList = dataContext.sales.ToList();
                var jsonResult =  Json(employeeList, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
        }

        //public JsonResult getEmployeeByNo(string EmpNo)
        //{
        //    using (SampleDBEntities dataContext = new SampleDBEntities())
        //    {
        //        int no = Convert.ToInt32(EmpNo);
        //        var employeeList = dataContext.Employees.Find(no);
        //        return Json(employeeList, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //public string UpdateEmployee(Employee Emp)
        //{
        //    if (Emp != null)
        //    {
        //        using (SampleDBEntities dataContext = new SampleDBEntities())
        //        {
        //            int no = Convert.ToInt32(Emp.Id);
        //            var employeeList = dataContext.Employees.Where(x => x.Id == no).FirstOrDefault();
        //            employeeList.name = Emp.name;
        //            employeeList.Age = Emp.Age;
        //            employeeList.email = Emp.email;
        //            dataContext.SaveChanges();
        //            return "Employee Updated";
        //        }
        //    }
        //    else
        //    {
        //        return "Invalid Employee";
        //    }
        //}
        //public string AddEmployee(Employee Emp)
        //{
        //    if (Emp != null)
        //    {
        //        using (SampleDBEntities dataContext = new SampleDBEntities())
        //        {
        //            dataContext.Employees.Add(Emp);
        //            dataContext.SaveChanges();
        //            return "Employee Updated";
        //        }
        //    }
        //    else
        //    {
        //        return "Invalid Employee";
        //    }
        //}


        //public string DeleteEmployee(Employee Emp)
        //{
        //    if (Emp != null)
        //    {
        //        using (SampleDBEntities dataContext = new SampleDBEntities())
        //        {
        //            int no = Convert.ToInt32(Emp.Id);
        //            var employeeList = dataContext.Employees.Where(x => x.Id == no).FirstOrDefault();
        //            dataContext.Employees.Remove(employeeList);
        //            dataContext.SaveChanges();
        //            return "Employee Deleted";
        //        }
        //    }
        //    else
        //    {
        //        return "Invalid Employee";
        //    }
        //}
    }
}
