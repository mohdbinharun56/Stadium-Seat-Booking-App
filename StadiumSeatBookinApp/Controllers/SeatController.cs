using BLL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;

namespace StadiumSeatBookinApp.Controllers
{
    public class SeatController : ApiController
    {
        [HttpGet]
        [Route("api/seats")]
        public HttpResponseMessage Seats()
        {
            try
            {
                var data = SeatService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/seats/{id}")]
        public HttpResponseMessage Seats(int id)
        {
            try
            {
                var data = SeatService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/seats/delete/{id}")]
        public HttpResponseMessage DeletePost(int id)
        {
            var res = SeatService.DeletePost(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        [HttpGet]
        [Route("api/seats/create")]

        public HttpResponseMessage CreatePost(Seat seat )
        {
            var data = SeatService.CreatePost(seat);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = data });
        }


        [HttpPut]
        [Route("api/seats/update/{id}")]
        public HttpResponseMessage UpdatePost(Seat obj)
        {
            /*var res = PostService.Get(obj.Id);*/
            var res = SeatService.UpdatePost(obj);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = res });
        }
    }
}
