using Organization.DAL;
using Organization.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.BLL
{
   public class OrganizationBLL
    {
        DataContext db = new DataContext();
        public List<Organizations> GetOrganizations()
        {
            return db.Organizations.ToList();
        }

        public Organizations GetOrganization(int ID)
        {
            return db.Organizations.FirstOrDefault(x=>x.OrganizationID==ID);
        }


        public void AddOrganization(Organizations org)
        {
            db.Organizations.Add(org);
            db.SaveChanges();
        }
        public void AddOrgUsers(OrganizationsUsers org)
        {
            db.OrganizationsUsers.Add(org);
            db.SaveChanges();
        }
        public List<OrganizationsUsers> GetOrganizationsUsers(int Id)
        {
            List<OrganizationsUsers> org = db.OrganizationsUsers.Where(x => x.UserID == Id).ToList();
            return org;
        }

        public void DeleteUser(int Id)
        {
            OrganizationsUsers user = db.OrganizationsUsers.FirstOrDefault(x => x.UserID == Id);
            db.OrganizationsUsers.Remove(user);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            Organizations org = db.Organizations.FirstOrDefault(x => x.OrganizationID == Id);
            db.Organizations.Remove(org);
            db.SaveChanges();
        }

        public int GetNumofUsers(int Id)
        {
            if (db.OrganizationsUsers.Where(x => x.OrganizationID==Id).Sum(x=>x.NumberofUsers).HasValue)
            {
                return db.OrganizationsUsers.Where(x => x.OrganizationID == Id).Sum(x => x.NumberofUsers).Value;
            }
            return 0;
        }
    }
}
