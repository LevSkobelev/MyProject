using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private static List<TableReservation> Reservations = new List<TableReservation>();

        public ReservationController(ILogger<ReservationController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetReservations")]
        public IEnumerable<TableReservation> Get()
        {
            return Reservations;
        }

        [HttpPost("book")]
        public IActionResult BookTable([FromBody] TableReservation reservation)
        {
            if (Reservations.Any(r => r.Id == reservation.Id))
            {
                return BadRequest($"Резервирование с ID {reservation.Id} уже существует.");
            }

            var validationResult = ValidateReservation(reservation);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ErrorMessage);
            }

            reservation.Id = Reservations.Count > 0 ? Reservations.Max(r => r.Id) + 1 : 1;
            Reservations.Add(reservation);
            return Ok(reservation);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateReservation(int id, [FromBody] TableReservation updatedReservation)
        {
            var reservation = Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound("Резервирование не найдено.");
            }

            var validationResult = ValidateReservation(updatedReservation);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ErrorMessage);
            }

            reservation.CustomerName = updatedReservation.CustomerName;
            reservation.TableNumber = updatedReservation.TableNumber;
            reservation.ReservationTime = updatedReservation.ReservationTime;

            return Ok(reservation);
        }

        [HttpDelete("cancel/{id}")]
        public IActionResult CancelReservation(int id)
        {
            var reservation = Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound("Резервирование не найдено.");
            }

            Reservations.Remove(reservation);
            return Ok($"Резервирование с ID {id} отменено.");
        }

        private (bool IsValid, string ErrorMessage) ValidateReservation(TableReservation reservation)
        {
            if (string.IsNullOrWhiteSpace(reservation.CustomerName))
            {
                return (false, "Имя клиента не должно быть пустым.");
            }

            if (reservation.TableNumber <= 0)
            {
                return (false, "Номер стола должен быть больше 0.");
            }

            if (reservation.ReservationTime <= DateTime.Now)
            {
                return (false, "Время резервирования должно быть в будущем.");
            }

            return (true, string.Empty);
        }
    }

    public class TableReservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int TableNumber { get; set; }
        public DateTime ReservationTime { get; set; }
    }
}
