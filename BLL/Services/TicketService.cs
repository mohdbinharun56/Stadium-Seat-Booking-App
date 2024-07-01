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
    public class TicketService
    {
        public static List<TicketDTO> Get()
        {
            var data = DataAccessFactory.TicketData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Ticket, TicketDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TicketDTO>>(data);
            return mapped;
        }

        public static TicketDTO Get(int id)
        {
            var data = DataAccessFactory.TicketData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Ticket, TicketDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TicketDTO>(data);

            return mapped;
        }

        public static bool CreatePost(Ticket obj)
        {
            var res = DataAccessFactory.TicketData().Create(obj);
            return res;
        }

        public static bool DeletePost(int id)
        {
            var res = DataAccessFactory.TicketData().Delete(id);
            return res;
        }

        public static bool UpdatePost(Ticket obj)
        {

            var res = DataAccessFactory.TicketData().Update(obj);
            Get(obj.TicketId);
            return res;
        }
       

    }
}
