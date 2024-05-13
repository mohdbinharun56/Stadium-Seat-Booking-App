using DAL.Interface;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User,string,User> UserData()
        {
            return new UserRepo();
        }

        public static IRepo<Event, int, bool> EventData()
        {
            return new EventRepo();
        }

        public static IRepo<Seat, int, bool> SeatData()
        {
            return new SeatRepo();
        }

        public static IRepo<Booking, int, bool> BookingData()
        {
            return new BookingRepo();
        }

        public static IRepo<Account,int,bool> AccountData()
        {
            return new AccountRepo();
        }

        public static IRepo<Stadium, int, bool> StadiumData()
        {
            return new StadiumRepo();
        }
    }
}
