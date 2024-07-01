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
    public class TicketController : ApiController
    {
        [HttpGet]
        [Route("api/tickets")]
        public HttpResponseMessage Tickets()
        {
            try
            {
                var data = TicketService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/tickets/{id}")]
        public HttpResponseMessage Tickets(int id)
        {
            try
            {

                var data = TicketService.Get(id);
                if (data != null)
                {

                    int bookingID = data.BookingId;

                    int Ticket_price = data.TicketPrice;

                    var booking = BookingService.Get(bookingID);
                    
                    int userID = booking.UserId;
                    int eventID = booking.EventId;
                    int seatID = booking.SeatId;

                    var counting = BookingService.UserCount(userID);
                    var TotalAmount = Ticket_price* counting;
                    var user = UserService.Get(userID);
                    var events = EventService.Get(eventID);
                    var seat = SeatService.Get(seatID);
                    var response = new
                    {
                        TicketID = data.TicketId,
                        UserName = user.Uname,
                        EventName = events.EventName,
                        EventDate = events.DateTime,
                        seatNumber = seat.SeatNumber,
                        section = seat.section,
                        TicketPrice = data.TicketPrice,
                        NumberOfTickets = counting,
                        TotalPayment = TotalAmount

                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError,"This id does not contain");



            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/tickets/delete/{id}")]
        public HttpResponseMessage DeletePost(int id)
        {
            var res = TicketService.DeletePost(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        [HttpGet]
        [Route("api/tickets/create")]

        public HttpResponseMessage CreatePost(Ticket ticket)
        {
            var data = TicketService.CreatePost(ticket);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = data });
        }


        [HttpPut]
        [Route("api/tickets/update/{id}")]
        public HttpResponseMessage UpdatePost(Ticket obj)
        {
            /*var res = PostService.Get(obj.Id);*/
            var res = TicketService.UpdatePost(obj);
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = res });
        }
    }
}
