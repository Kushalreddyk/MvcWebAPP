using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using solution2.Models;
using LoggerFactory;
using solution2;

namespace solution2.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new PatientModel());
            else
            {
                try
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Patient/" + id.ToString()).Result;
                    return View(response.Content.ReadAsAsync<PatientModel>().Result);
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Factory.LogException(ex);
                    // Handle the exception as per your application's requirement
                    throw;
                }
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(PatientModel patientModel)
        {
            try
            {
                if (patientModel.Id == 0)
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Patient", patientModel).Result;
                    return RedirectToAction("Index");
                }
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Patient/" + patientModel.Id, patientModel).Result;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Factory.LogException(ex);
                // Handle the exception as per your application's requirement
                throw;
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Patient/" + id.ToString()).Result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception
                Factory.LogException(ex);
                // Handle the exception as per your application's requirement
                throw;
            }
        }

        public ActionResult LoadTable()
        {
            try
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Patient").Result;
                IEnumerable<PatientModel> patientModels = response.Content.ReadAsAsync<IEnumerable<PatientModel>>().Result;

                return Json(new { data = patientModels }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Log the exception
                Factory.LogException(ex);
                // Handle the exception as per your application's requirement
                throw;
            }
        }
        public ActionResult SimulateException()
        {
            try
            {
                // Simulate some operation that might throw an exception
                throw new Exception("This is a simulated exception for testing purposes.");
            }
            catch (Exception ex)
            {
                // Log the exception
                LoggerFactory.Factory.LogException(ex);
                // Re-throw the exception to let the application handle it further
                throw;
            }
        }

    }
}
