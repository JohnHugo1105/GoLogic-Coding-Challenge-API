using GoLogic.BookingPlatform.Application.BookingTransaction.Commands.Booking;
using GoLogic.BookingPlatform.Application.BookingTransaction.Queries.GetRoomById;
using GoLogic.BookingPlatform.Application.BookingTransaction.Queries.GetRoomsList;
using GoLogic.BookingPlatform.Domain.Constants;
using GoLogic.BookingPlatform.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GoLogic.BookingPlatform.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/booking")]
    [ApiController]
    public class BookingController : BaseApiController
    {
        private readonly ILogger<BookingController> _logger;

        public BookingController(ILogger<BookingController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the list of rooms
        /// </summary>
        /// <returns> a list of room with images and details</returns>
        /// <remarks>
        /// Sample request
        /// GET /api/booking/rooms
        /// </remarks>
        [HttpGet("rooms")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> GetRooms()
        {
            try
            {
                return Ok(await Mediator.Send(new GetRoomsQuery()));
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerGeneralException, ex));
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Gets a room by id
        /// </summary>
        /// <param name="roomId">the room identifier</param>
        /// <returns>a single room with it details</returns>
        /// <remarks>
        /// Sample request
        /// GET /api/booking/room/1
        /// </remarks>
        [HttpGet("room/{roomId}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> GetRoomsById(int roomId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetRoomByIdQuery { RoomdId = roomId }));
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerGeneralException, ex));
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Books the room selected if available
        /// </summary>
        /// <param name="booking">request payload</param>
        /// <remarks>
        /// Sample request
        /// POST /api/book
        /// request payload in body
        /// </remarks>
        [HttpPost("book")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> PostBookRoom([FromBody] BookRoomCommand booking)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await Mediator.Send(booking);

                return NoContent();
            }
            catch (BookingValidationException ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerGeneralException, ex));
                return StatusCode(400, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format(ExceptionMsgs.LoggerGeneralException, ex));
                return StatusCode(500, ex);
            }
        }
    }
}
