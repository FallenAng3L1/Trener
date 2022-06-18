using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trener.Models
{
    public class Session
    {
        public Guid ID { get; set; }
        public int Time { get; }
        public int HeartRate { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }

        public Session(int time, int heartRate, string name, int age, double weight, string gender, Guid id/*, string name = "", int age = 20, double weight = 80, string gender = "Mężczyzna"*/)
        {
            Time = time;
            HeartRate = heartRate;
            Name = name;
            Age = age;
            Weight = weight;
            Gender = gender;
            ID = id;
        }

    }
}
