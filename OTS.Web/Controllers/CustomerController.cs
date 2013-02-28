using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using OTS.Web.Models;

namespace OTS.Web.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            return View(GetAllCustomers());
        }

        public ActionResult Create(CustomerModel model)
        {
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        private IList<CustomerModel> GetAllCustomers()
        {
            return new List<CustomerModel>();
        }
    }
}
