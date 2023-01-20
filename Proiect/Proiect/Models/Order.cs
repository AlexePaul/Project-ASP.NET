﻿using Proiect.Models.Base;

namespace Proiect.Models
{
    public class Order : BaseModel
    {
        public string Adress { get; set; } = string.Empty;

        public User User { get; set; }

        public Delivery delivery { get; set; }

        public List<OrderContains> foods { get; set; }
    }
}
