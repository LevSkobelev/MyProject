using System;
using System.Collections.Generic;

namespace API.Controllers.Mod
{
    public partial class Table
    {
        public Table()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int Seats { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
