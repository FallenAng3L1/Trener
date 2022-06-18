using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Trener.DBContexts;

namespace Trener.Models
{
    public class TrainingList
    {
        public TrainingList()
        {

        }

        public static async Task deleteList()
        {
            //UWAGA! USUWANIE!:         
            using var db = new SessionDBContext();
            var allRec = db.dbSessions;
            db.dbSessions.RemoveRange(allRec);
            await db.SaveChangesAsync(); 
        }
        public async Task AddSession(Session session)
        {
            //_sessions.Add();
            using var db = new SessionDBContext();
            db.Add(toDatabase(session));
            await db.SaveChangesAsync();

            //var sesja = db.DBSessions.OrderBy(b => b.ID).First();
            //MessageBox.Show($"DataReader :{sesja.Time} , {sesja.HeartRate} , {sesja.Name} , {sesja.Age} , {sesja.Weight} , {sesja.Gender}.", "test", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private SessionTable toDatabase(Session session)
        {
            return new SessionTable()
            {
                Name = session.Name,
                Weight = session.Weight,
                Age = session.Age,
                Gender = session.Gender,
                HeartRate = session.HeartRate,
                Time = session.Time,
            };
        }

        public static async Task<IEnumerable<Session>> GetSessions()
        {
            using var db = new SessionDBContext();

            IEnumerable<SessionTable> sesja = await db.dbSessions.ToListAsync();
            return sesja.Select(s => new Session(s.Time, s.HeartRate, s.Name, s.Age, s.Weight, s.Gender, s.ID));
        }
    }
}
