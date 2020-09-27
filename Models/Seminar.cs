using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_SignToSeminar_WebApplication.Models
{
    public class Seminar
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Speaker { get; set; }
        public DateTime SeminarDateTime { get; set; }
        public int Seats { get; set; } = 30;
        public string Description { get; set; }

       // public byte[] Picture { get; set; }
       public ICollection<Booking> Bookings { get; set; }

    }
}
