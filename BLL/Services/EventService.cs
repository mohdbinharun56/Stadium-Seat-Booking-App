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
    public class EventService
    {
        public static List<EventDTO> Get()
        {
            var data = DataAccessFactory.EventData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Event, EventDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<EventDTO>>(data);
            return mapped;
        }

        public static EventDTO Get(int id)
        {
            var data = DataAccessFactory.EventData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Event, EventDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EventDTO>(data);

            return mapped;
        }

        public static bool CreatePost(Event obj)
        {
            var res = DataAccessFactory.EventData().Create(obj);
            return res;
        }

        public static bool DeletePost(int id)
        {
            var res = DataAccessFactory.EventData().Delete(id);
            return res;
        }

        public static bool UpdatePost(Event obj)
        {

            var res = DataAccessFactory.EventData().Update(obj);
            Get(obj.EventId);
            return res;
        }
    }
}
