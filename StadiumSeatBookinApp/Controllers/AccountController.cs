using BLL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StadiumSeatBookinApp.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        [Route("api/accounts")]
        public HttpResponseMessage Accounts()
        {
            try
            {
                var data = AccountService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/accounts/{id}")]
        public HttpResponseMessage Accounts(int id)
        {
            try
            {
                var data = AccountService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/accounts/delete/{id}")]
        public HttpResponseMessage DeletePost(int id)
        {
            var res = AccountService.DeletePost(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        [HttpGet]
        [Route("api/accounts/create")]

        public HttpResponseMessage CreatePost(Account account)
        {
            var data = AccountService.CreatePost(account);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = data });
        }


        [HttpPut]
        [Route("api/accounts/update/{id}")]
        public HttpResponseMessage UpdatePost(Account obj)
        {
            /*var res = PostService.Get(obj.Id);*/
            var res = AccountService.UpdatePost(obj);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = res });
        }
    }
}
