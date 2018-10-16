using DZzzz.Learning.Core.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DZzzz.Learning.Core.Api.Controllers.Api
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        [HttpGet("string")]
        public string GetString() => "This is a string response";// response will be "text/plain" (by default)

        [HttpGet("int")]
        public int GetInt() => 123134; // response will be "application/json" (by default)

        [HttpGet("object")]
        public Reservation GetObject() => new Reservation // response will be "application/json" (by default), but if AddXmlDataContractSerializerFormatters is enabled and Accept contains "xml", will be "application/xml"
        {
            ReservationId = 100,
            ClientName = "Joe",
            Location = "Board Room"
        };

        [HttpGet("jsonobject")]
        [Produces("application/json")]
        public Reservation GetJsonObject() => new Reservation // response will be "application/json" anyway, even if AddXmlDataContractSerializerFormatters is enabled and Accept contains "xml", will be "application/xml"
        {
            ReservationId = 100,
            ClientName = "Joe",
            Location = "Board Room"
        };

        [HttpGet("withformatobject/{format?}")]
        [FormatFilter]
        [Produces("application/json", "application/xml")]
        public Reservation GetWithFormatObject() => new Reservation
        {
            ReservationId = 100,
            ClientName = "Joe",
            Location = "Board Room"
        };

        // Different methods to process different items

        [HttpPost]
        [Consumes("application/json")]
        public Reservation ReceiveJson([FromBody] Reservation reservation) // this method will handle just JSON
        {
            reservation.ClientName = "Json";
            return reservation;
        }
        [HttpPost]
        [Consumes("application/xml")]
        public Reservation ReceiveXml([FromBody] Reservation reservation) // this method will handle just XML
        {
            reservation.ClientName = "Xml";
            return reservation;
        }
    }
}