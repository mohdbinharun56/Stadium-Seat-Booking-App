using BLL.Services;
using DAL.Models;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.Http;
using BookingService = BLL.Services.BookingService;

namespace StadiumSeatBookinApp.Controllers
{
    public class BookingController : ApiController
    {
        [HttpGet]
        [Route("api/bookings")]
        public HttpResponseMessage Bookings()
        {
            try
            {
                var data = BookingService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/seats/booking/{id}")]
        public HttpResponseMessage Bookings(int id)
        {
            try
            {
                var booking = BookingService.Get(id);
                int seatID = booking.SeatId;
                var seat = SeatService.Get(seatID);
                var response = new
                {
                    BookingId = booking.BookingId,
                    UserId = booking.UserId,
                    EventId = booking.EventId,
                    EventDate = booking.EventDate,
                    SeatNumber = seat.SeatNumber,
                    section = seat.section,
                    status = seat.status
                };
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/seats/booking/delete/{id}")]
        public HttpResponseMessage DeletePost(int id)
        {
            var res = BookingService.DeletePost(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        [HttpGet]
        [Route("api/seats/booking/create")]

        public HttpResponseMessage CreatePost(Booking booking)
        {
            var data = BookingService.CreatePost(booking);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = data });
        }


        [HttpPut]
        [Route("api/seats/update/booking/{id}")]
        public HttpResponseMessage UpdatePost(Booking obj)
        {
            var res = BookingService.UpdatePost(obj);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = res });
        }
    }

       
 }
