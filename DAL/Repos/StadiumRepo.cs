using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StadiumRepo : Repo, IRepo<Stadium, int, bool>
    {
        public bool Create(Stadium obj)
        {
            db.Stadiums.Add(obj);
            //db.SaveChanges();
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var delete = Read(id);
            db.Stadiums.Remove(delete);
            return (db.SaveChanges() > 0);
        }

        public List<Stadium> Read()
        {
            return db.Stadiums.ToList();
        }

        public Stadium Read(int id)
        {
            return db.Stadiums.Find(id);
        }

        public bool Update(Stadium obj)
        {
            var edit = Read(obj.StadiumId);
            db.Entry(edit).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
