using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SeatRepo : Repo, IRepo<Seat, int, bool>
    {
        public bool Create(Seat obj)
        {
           /* throw new NotImplementedException();*/
           db.Seats.Add(obj);
            if(db.SaveChanges()>0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            /*throw new NotImplementedException();*/
            var delete = Read(id);
            db.Seats.Remove(delete);
            return (db.SaveChanges() > 0);
        }

        public List<Seat> Read()
        {
            /*throw new NotImplementedException();*/
            return db.Seats.ToList();
        }

        public Seat Read(int id)
        {
            /*throw new NotImplementedException();*/
            return db.Seats.Find(id);
        }

        public bool Update(Seat obj)
        {
            /*throw new NotImplementedException();*/
            var edit = Read(obj.SeatId);
            db.Entry(edit).CurrentValues.SetValues(obj);
            if(db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
