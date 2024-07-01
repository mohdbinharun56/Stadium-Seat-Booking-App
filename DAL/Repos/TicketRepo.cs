using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TicketRepo : Repo, IRepo<Ticket, int, bool>
    {
        public int Count(int id)
        {
            throw new NotImplementedException();
        }

        public bool Create(Ticket obj)
        {
            /*throw new NotImplementedException();*/
            db.Tickets.Add(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            /*throw new NotImplementedException();*/
            var deleteTicket = Read(id);
            db.Tickets.Remove(deleteTicket);
            return (db.SaveChanges() > 0);
        }

        public List<Ticket> Read()
        {
            /*throw new NotImplementedException();*/
            return db.Tickets.ToList();
        }

        public Ticket Read(int id)
        {
            /*throw new NotImplementedException();*/
            return db.Tickets.Find(id);
        }

        public bool Update(Ticket obj)
        {
            /*throw new NotImplementedException();*/
            var edit = Read(obj.TicketId);
            db.Entry(edit).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
