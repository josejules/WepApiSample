using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeDataModal> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("employee").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<EmployeeDataModal>>().Result;
            return View(empList);
        }

        public ActionResult AddorEdit(int id=0)
        {
            if (id == 0)
                return View(new EmployeeDataModal());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<EmployeeDataModal>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(EmployeeDataModal emp)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employee", emp).Result;
            TempData["SuccessMessage"] = "Saved Successfully";
            return RedirectToAction("Index");
        }
    }
}