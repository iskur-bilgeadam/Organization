using Organization.BLL;
using Organization.ENTITY;
using Organization.UI.Filters;
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
        [MyAuthenticationFilter]
        public ActionResult Sent()
        {
            Users user = Session["Login"] as Users;
            List<Messages> messages = messageBLL.SentMessages(user.UserID);
            return View(messages);
        }


        [MyAuthenticationFilter]
        public ActionResult Incoming()
        {
            Users user = Session["Login"] as Users;
            List<Messages> messages = messageBLL.IncomingMessages(user.UserID);
            return View(messages);
        }

        [HttpPost]
        public ActionResult SendMessage(OrganizationModel model)
        {
            Users user = Session["Login"] as Users;

            Organizations org = organizationBLL.GetOrganization(model.Organizations.OrganizationID);

            Messages message = new Messages
            {
                ReceiverID = org.UserID,
                SenderID = user.UserID,
                Body=model.Message.Body,
                Subject=model.Message.Subject,
                Date=DateTime.Now,
                OrgID=org.OrganizationID
            };
           
            messageBLL.AddMessage(message);
            return RedirectToAction("Detail","Organization",new { id=model.Organizations.OrganizationID});
        }

        [HttpPost]
        public ActionResult Reply(OrganizationModel model)
        {
            Users user = Session["Login"] as Users;

            Organizations org = organizationBLL.GetOrganization(model.Organizations.OrganizationID);

            Messages message = new Messages
            {
                ReceiverID = user.UserID,
                SenderID = org.UserID,
                Body = model.Message.Body,
                Subject = model.Message.Subject,
                Date = DateTime.Now,
                OrgID = org.OrganizationID
            };

            messageBLL.AddMessage(message);
            return RedirectToAction("Detail", "Organization", new { id = model.Organizations.OrganizationID });
        }

        public ActionResult Delete(int Id)
        {
            messageBLL.Delete(Id);
            return RedirectToAction("Sent");
        }
    }
}