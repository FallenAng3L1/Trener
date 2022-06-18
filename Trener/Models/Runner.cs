using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trener.Models
{
    public class Runner
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }

        public Runner(string name, int age, double weight, string gender)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Gender = gender;
        }

        public void UpdateRunner(Runner runner)
        {
            Name = runner.Name;
            Age = runner.Age;
            Weight = runner.Weight;
            Gender = runner.Gender;
        }
    }
}
