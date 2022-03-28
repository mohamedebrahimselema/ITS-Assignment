using System;
using System.Collections.Generic;

#nullable disable

namespace ITS_Assignment.Models
{
    public partial class CustomerDatum
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string ClassName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}
