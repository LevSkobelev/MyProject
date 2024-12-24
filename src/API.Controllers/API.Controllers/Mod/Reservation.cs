using System;
using System.Collections.Generic;

namespace API.Controllers.Mod
{
    public partial class Reservation
    {
        public Reservation()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? TableId { get; set; }
        public DateTime ReservationTime { get; set; }
        public string Status { get; set; } = null!;

        public virtual Customer? Customer { get; set; }
        public virtual Table? Table { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
