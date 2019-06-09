using Organization.BLL;
using Organization.ENTITY;
using Organization.UI.Filters;
using Organization.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Organization.UI.Controllers
{
    public class OrganizationController : Controller
    {
        OrganizationBLL organizationBLL = new OrganizationBLL();
        MessageBLL mbll = new MessageBLL();

        [MyAuthenticationFilter]
        public ActionResult Index()
        {
            List<Organizations> organizations = organizationBLL.GetOrganizations();
            return View(organizations);
        }

        [MyAuthenticationFilter]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Organizations org , HttpPostedFileBase Resim)
        {
            Users user = Session["Login"] as Users;
            if (ModelState.IsValid)
            {
                if (Resim!=null)
                {
                    WebImage img = new WebImage(Resim.InputStream);
                    FileInfo imginfo = new FileInfo(Resim.FileName);

                    string newimg = Guid.NewGuid().ToString() + imginfo.Extension;

                    img.Save("~/Content/images/Newimages/" + newimg);
                    org.Image = "/Content/images/Newimages/" + newimg;
                }

                org.UserID = user.UserID;
                organizationBLL.AddOrganization(org);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [MyAuthenticationFilter]
        public ActionResult Detail(int Id)
        {
            Organizations org = organizationBLL.GetOrganization(Id);
            OrganizationModel model = new OrganizationModel
            {
                Organizations = org
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult RegisterOrg(OrganizationModel model)
        {
            Users user = Session["Login"] as Users;

            List<OrganizationsUsers> organizations = organizationBLL.GetOrganizationsUsers(user.UserID);

            foreach (var item in organizations)
            {
                if (user.UserID == item.UserID && model.Organizations.OrganizationID == item.OrganizationID)
                {
                    return RedirectToAction("Detail", "Organization",new { id=model.Organizations.OrganizationID});
                }
            }
            OrganizationsUsers organizationsUsers = new OrganizationsUsers
            {
                OrganizationID = model.Organizations.OrganizationID,
                UserID = user.UserID,
                Date = DateTime.Now,
                NumberofUsers = model.NumberofUsers
            };

            organizationBLL.AddOrgUsers(organizationsUsers);

            return RedirectToAction("Index");
        }

        [MyAuthenticationFilter]
        public ActionResult MyOrganization()
        {
            Users user = Session["Login"] as Users;
            List<OrganizationsUsers> organize = organizationBLL.GetOrganizationsUsers(user.UserID);
            return View(organize);
        }

        [MyAuthenticationFilter]
        public ActionResult LeaveOrganization(int Id)
        {
            organizationBLL.DeleteUser(Id);
            return RedirectToAction("MyOrganization");
        }
    }
}