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
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/users")]
        public HttpResponseMessage Users()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public HttpResponseMessage Seats(int id)
        {
            try
            {
                var data = UserService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/users/delete/{id}")]
        public HttpResponseMessage DeletePost(int id)
        {
            var res = UserService.DeletePost(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        [HttpGet]
        [Route("api/users/create")]

        public HttpResponseMessage CreatePost(User user)
        {
            var data = UserService.CreatePost(user);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = data });
        }


        [HttpPut]
        [Route("api/user/update/{id}")]
        public HttpResponseMessage UpdatePost(User obj)
        {
            /*var res = PostService.Get(obj.Id);*/
            var res = UserService.UpdatePost(obj);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = res });
        }
    }
}
