using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BookingRepo : Repo, IRepo<Booking, int, bool>
    {
        Booking Booking { get; set; }
        public bool Create(Booking obj)
        {
            /*throw new NotImplementedException();*/

            db.Bookings.Add(obj);
            //db.SaveChanges();
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            /*throw new NotImplementedException();*/
            var delete = Read(id);
            db.Bookings.Remove(delete);
            return (db.SaveChanges() > 0);
        }

        public List<Booking> Read()
        {
            /*throw new NotImplementedException();*/
            return db.Bookings.ToList();

        }

        public Booking Read(int id)
        {
            /*throw new NotImplementedException();*/
            
            return db.Bookings.Find(id);
        }

        public bool Update(Booking obj)
        {
            /*throw new NotImplementedException();*/
            var edit = Read(obj.BookingId);
            var seat = edit.SeatId;
            /*if(seat == null) return false;*/
            db.Entry(edit).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return true;
            return false;
        }
        public int Count(int id)
        {
            int count = 0;
            foreach (var booking in db.Bookings)
            {
                
                if(booking.UserId == id)
                {
                    count = count + 1;
                }
            }
           /* var userCount = db.Bookings.Count(b => b.UserId == id);*/
            return count;
        }
    }
}
