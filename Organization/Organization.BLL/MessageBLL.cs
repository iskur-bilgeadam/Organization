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
        public List<Messages> GetMessages(int id)
        {
            return db.Messages.Where(x=>x.OrgID==id).ToList();
        }
        public List<Messages> SentMessages(int id)
        {
            return db.Messages.Where(x =>x.SenderID==id).ToList();
        }
        public List<Messages> IncomingMessages(int id)
        {
            return db.Messages.Where(x => x.ReceiverID == id).ToList();
        }

        public List<Messages> GetMessage(int Id)
        {
            return db.Messages.Where(x => x.Users.UserID == Id).ToList();
        }

        public void AddMessage(Messages msj)
        {

            db.Messages.Add(msj);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            Messages messages = db.Messages.Where(x => x.MessageID == Id).FirstOrDefault();
            db.Messages.Remove(messages);
            db.SaveChanges();
        }

    }
}
