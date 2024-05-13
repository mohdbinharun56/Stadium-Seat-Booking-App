using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, User>
    {
        public User Create(User obj)
        {
           db.Users.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            /*throw new NotImplementedException();*/
            var del = Read(id);
            if (del == null) return false;
            db.Users.Remove(del);
            return (db.SaveChanges() > 0);
        }

        public List<User> Read()
        {
            /* throw new NotImplementedException();*/
            return db.Users.ToList();
        }

        public User Read(string id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
            /*throw new NotImplementedException();*/
            var edit = Read(obj.Uname); 
            if (edit == null) return null;
            db.Entry(edit).CurrentValues.SetValues(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;

        }
    }
}
