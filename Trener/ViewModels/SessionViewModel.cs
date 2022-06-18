using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trener.Models;

namespace Trener.ViewModels
{
    public class SessionViewModel : ViewModelBase
    {
        private readonly Session _session;

        public string Name => _session.Name;
        public string Gender => _session.Gender;
        public int Time => _session.Time;
        public int HeartRate => _session.HeartRate;
        public int Age => _session.Age;
        public double Weight => _session.Weight;
        public double BurnedCalories => CalculateCalories();

        public Guid ID => _session.ID;

        public double CalculateCalories()
        {
            if(Gender == "Kobieta")
            {
                return Math.Round(((Age * 0.074) - (Weight * 0.05741) + (HeartRate * 0.4472) - 20.4022) * Time / 4.184,2);
            }
            else
            {
                return Math.Round(((Age * 0.2017) - (Weight * 0.09036) + (HeartRate * 0.6309) - 55.0609) * Time / 4.184,2);

            }
        }
        public SessionViewModel(Session session)
        {
            _session = session;
        }
    }
}
