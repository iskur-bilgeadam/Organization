using Organization.BLL;
using Organization.ENTITY;
using Organization.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organization.UI.Controllers
{
    public class MessageController : Controller
    {
        MessageBLL messageBLL = new MessageBLL();
        OrganizationBLL organizationBLL = new OrganizationBLL();
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(OrganizationModel model)
        {
            Users user = Session["Login"] as Users;

            Organizations org = organizationBLL.GetOrganization(model.Organizations.OrganizationID);

            List<Messages> messages = messageBLL.GetMessages();

            Messages message = new Messages
            {
                ReceiverID = org.UserID,
                SenderID = user.UserID,
                Body=model.Message.Body,
                Subject=model.Message.Subject,
                Date=DateTime.Now
            };
           
            messageBLL.AddMessage(message);
            return RedirectToAction("Detail","Organization",new { id=model.Organizations.OrganizationID});
        }
    }
}