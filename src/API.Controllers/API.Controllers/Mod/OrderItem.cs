using System;
using System.Collections.Generic;

namespace API.Controllers.Mod
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int? ReservationId { get; set; }
        public int? MenuItemId { get; set; }
        public int Quantity { get; set; }

        public virtual MenuItem? MenuItem { get; set; }
        public virtual Reservation? Reservation { get; set; }
    }
}
