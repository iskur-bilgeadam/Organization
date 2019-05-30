using Organization.DAL;
using Organization.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.BLL
{
   public class MessageBLL
    {
        DataContext db = new DataContext();
        public List<Messages> GetMessages()
        {
            return db.Messages.ToList();
        }

        public Messages GetMessages(int Id)
        {
            return db.Messages.Where(x=>x.MessageID==Id).FirstOrDefault();
        }

        public void AddMessage(Messages msj)
        {
             db.Messages.Add(msj);
            db.SaveChanges();
        }

    }
}
