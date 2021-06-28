using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WriterManagement.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator validationRules = new ContactValidator();
        public ActionResult Index()
        {
            var contactValue = contactManager.GetList();
            return View(contactValue);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValue = contactManager.GetByID(id);
            return View(contactValue);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}