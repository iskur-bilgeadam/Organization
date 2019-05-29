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
    public class OrganizationController : Controller
    {
        OrganizationBLL organizationBLL = new OrganizationBLL();
        public ActionResult Index()
        {
            List<Organizations> organizations = organizationBLL.GetOrganizations();
            return View(organizations);
        }

        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(Organizations org)
        {
            Users user = Session["Login"] as Users;
            org.UserID = user.UserID;
            organizationBLL.AddOrganization(org);
            return RedirectToAction("Index");
        }


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
                    return RedirectToAction("Index");
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


        public ActionResult MyOrganization()
        {
            Users user = Session["Login"] as Users;
            List<OrganizationsUsers> organize = organizationBLL.GetOrganizationsUsers(user.UserID);
            return View(organize);
        }

        public ActionResult LeaveOrganization(int Id)
        {
            organizationBLL.DeleteUser(Id);
            return RedirectToAction("MyOrganization");
        }
    }
}