using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EventRepo : Repo, IRepo<Event, int, bool>
    {
        public bool Create(Event obj)
        {
            /*throw new NotImplementedException();*/
            db.Events.Add(obj);
            //db.SaveChanges();
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            /*throw new NotImplementedException();*/
            var delete = Read(id);
            db.Events.Remove(delete);
            return (db.SaveChanges() > 0);
        }

        public List<Event> Read()
        {
            /*throw new NotImplementedException();*/
            return db.Events.ToList();
        }

        public Event Read(int id)
        {
            /*throw new NotImplementedException();*/
            return db.Events.Find(id);
        }

        public bool Update(Event obj)
        {
            /*throw new NotImplementedException();*/
            var edit = Read(obj.EventId);
            db.Entry(edit).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
