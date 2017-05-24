using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoLabi.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public DateTime LastOnline { get; set; }
    }
}