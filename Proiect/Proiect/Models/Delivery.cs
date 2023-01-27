﻿using Proiect.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect.Models
{
    public class Delivery : BaseModel
    {
        [ForeignKey("Order")]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
