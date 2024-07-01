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
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;
        }

        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);

            return mapped;
        }

        public static bool CreatePost(User obj)
        {
            var res = DataAccessFactory.UserData().Create(obj);
            return res;
        }

        public static bool DeletePost(int id)
        {
            var res = DataAccessFactory.UserData().Delete(id);
            return res;
        }

        public static bool UpdatePost(User obj)
        {

            var res = DataAccessFactory.UserData().Update(obj);
            Get(obj.UserId);
            return res;
        }
    }
}
