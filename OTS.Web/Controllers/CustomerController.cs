using System.Collections.Generic;
using System.Web.Mvc;
using OTS.BusinessLayer.Manager;
using OTS.Models;

namespace OTS.Web.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            return View(GetAllCustomers());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerModel customerModel)
        {
            CustomerManager customerMgr = new CustomerManager();
            customerMgr.SaveCustomerDetails(customerModel);
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            CustomerManager customerMgr = new CustomerManager();
            CustomerModel customerModel = customerMgr.GetCustomerById(id);

            return View(customerModel);
        }

        [HttpPost]
        public ActionResult Edit(CustomerModel customerModel)
        {
            CustomerManager customerMgr = new CustomerManager();
            customerMgr.SaveCustomerDetails(customerModel);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            CustomerManager customerMgr = new CustomerManager();
            customerMgr.DeleteCustomer(id);

            return RedirectToAction("Index");
        }

        private IList<CustomerModel> GetAllCustomers()
        {
            CustomerManager customerMgr = new CustomerManager();
            return customerMgr.GetCustomerDetails();
        }
    }
}