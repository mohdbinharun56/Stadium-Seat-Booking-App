using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AccountRepo : Repo, IRepo<Account, int, bool>
    {
        public int Count(int id)
        {
            throw new NotImplementedException();
        }

        public bool Create(Account obj)
        {
            var userId = db.Accounts.Find(obj.UserId);
            if(userId == null)
            {
                db.Accounts.Add(obj);
                if (db.SaveChanges() > 0) return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var delete = Read(id);
            db.Accounts.Remove(delete);
            return (db.SaveChanges() > 0);
        }

        public List<Account> Read()
        {
            return db.Accounts.ToList();
        }

        public Account Read(int id)
        {
            return db.Accounts.Find(id);
        }

        public bool Update(Account obj)
        {
            var edit = Read(obj.AccountId);
            db.Entry(edit).CurrentValues.SetValues(obj);
            if (db.SaveChanges()>0) return true;
            return false;
        }

    }
}
