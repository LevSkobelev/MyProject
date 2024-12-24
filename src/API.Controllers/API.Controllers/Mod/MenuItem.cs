using System;
using System.Collections.Generic;

namespace API.Controllers.Mod
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
