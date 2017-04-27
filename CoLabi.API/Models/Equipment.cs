using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoLabi.API.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsOperational { get; set; }
        public DateTime WorkingFrom { get; set; }
        public DateTime WorkingTo { get; set; }
    }
}