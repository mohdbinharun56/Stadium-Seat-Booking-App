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
    public class AccountService
    {
        public static List<AccountDTO> Get()
        {
            var data = DataAccessFactory.AccountData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Account, AccountDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AccountDTO>>(data);
            return mapped;
        }

        public static AccountDTO Get(int id)
        {
            var data = DataAccessFactory.AccountData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Account, AccountDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AccountDTO>(data);

            return mapped;
        }

        public static bool CreatePost(Account obj)
        {
            var res = DataAccessFactory.AccountData().Create(obj);
            return res;
        }

        public static bool DeletePost(int id)
        {
            var res = DataAccessFactory.AccountData().Delete(id);
            return res;
        }

        public static bool UpdatePost(Account obj)
        {

            var res = DataAccessFactory.AccountData().Update(obj);
            Get(obj.AccountId);
            return res;
        }
    }
}
