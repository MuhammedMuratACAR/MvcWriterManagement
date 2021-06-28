using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WriterManagement.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            var InMessage = messageManager.GetListInBox();
            return View(InMessage);
        }

        public ActionResult SendBox()
        {
            var sendMessage = messageManager.GetListSendBox();
            return View(sendMessage);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValue = messageManager.GetByID(id);
            return View(messageValue);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            messageManager.MessageAdd(message);
            return View();
        }
    }
}