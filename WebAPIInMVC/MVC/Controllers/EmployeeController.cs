using MVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployeeModel> empList;

            HttpResponseMessage response = GlobalVariables.WebApiCLient.GetAsync("Employee").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            return View(empList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcEmployeeModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiCLient.GetAsync("Employee/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcEmployeeModel>().Result);
            }

        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcEmployeeModel emp)
        {
            if (emp.EmployeeID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiCLient.PostAsJsonAsync("Employee", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiCLient.PutAsJsonAsync("Employee/"+emp.EmployeeID,emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiCLient.DeleteAsync("Employee/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");

        }

    }
}