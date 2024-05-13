using BLL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StadiumApp.Controllers
{
    public class StadiumController : ApiController
    {
        [HttpGet]
        [Route("api/stadiums")]
        public HttpResponseMessage Seats()
        {
            try
            {
                var data = StadiumService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/stadiums/{id}")]
        public HttpResponseMessage Seats(int id)
        {
            try
            {
                var data = StadiumService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/stadiums/delete/{id}")]
        public HttpResponseMessage DeletePost(int id)
        {
            var res = StadiumService.DeletePost(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        [HttpGet]
        [Route("api/stadiums/create")]

        public HttpResponseMessage CreatePost(Stadium s)
        {
            var data = StadiumService.CreatePost(s);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = data });
        }


        [HttpPut]
        [Route("api/stadiums/update/{id}")]
        public HttpResponseMessage UpdatePost(Stadium obj)
        {
            /*var res = PostService.Get(obj.Id);*/
            var res = StadiumService.UpdatePost(obj);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = res });
        }

    }
}
