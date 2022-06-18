using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Trener.Models;

namespace Trener
{
    class SessionTable
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Time { get; set; }
        public int HeartRate { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double BurnedCalories { get; set; }
    }
}
