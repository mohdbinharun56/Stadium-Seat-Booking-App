using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SeatService
    {
        public static List<SeatDTO> Get()
        {
            var data = DataAccessFactory.SeatData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Seat,SeatDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SeatDTO>>(data);
            return mapped;
        }

        public static SeatDTO Get(int id)
        {
            var data = DataAccessFactory.SeatData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Seat, SeatDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SeatDTO>(data);

            return mapped;
        }

        public static bool CreatePost(Seat obj)
        {
            var res = DataAccessFactory.SeatData().Create(obj);
            return res;
        }

        public static bool DeletePost(int id)
        {
            var res = DataAccessFactory.SeatData().Delete(id);
            return res;
        }

        public static bool UpdatePost(Seat obj)
        {

            var res = DataAccessFactory.SeatData().Update(obj);
            Get(obj.SeatId);
            return res;
        }



    }
}
