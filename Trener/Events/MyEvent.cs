using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trener.Models;

namespace Trener.Events
{
    class MyEvent : EventArgs
    {
        public Runner runner { get; set; }
        public Session session { get; set; }
    }
}
