using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookingService
    {
        public static List<BookingDTO> Get()
        {
            var data = DataAccessFactory.BookingData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<BookingDTO>>(data);
            return mapped;
        }

        public static BookingDTO Get(int id)
        {
            var data = DataAccessFactory.BookingData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, BookingDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<BookingDTO>(data);

            return mapped;
        }

        public static bool CreatePost(Booking obj)
        {
            var res = DataAccessFactory.BookingData().Create(obj);
            return res;
        }

        public static bool DeletePost(int id)
        {
            var res = DataAccessFactory.BookingData().Delete(id);
            return res;
        }

        public static bool UpdatePost(Booking obj)
        {

            var res = DataAccessFactory.BookingData().Update(obj);
            //Get(obj.SeatId);
            return res;
        }

        public static int UserCount(int id)
        {
            var res = DataAccessFactory.BookingData().Count(id);
            return res;
        }
    }
}
