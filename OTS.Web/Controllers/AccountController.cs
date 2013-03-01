using System.Collections.Generic;
using System.Web.Mvc;
using OTS.Models;

namespace OTS.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View(GetAllAccounts());
        }

        public ActionResult Details()
        {
            return View(GetAllAccounts());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AccountModel model)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        private IList<AccountModel> GetAllAccounts()
        {
           return new List<AccountModel>();
        }
    }
}