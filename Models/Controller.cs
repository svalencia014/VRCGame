using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrcGame
{
    public class Controller
    {
        public string Callsign { get; set; }
        public string Frequency { get; set; }
        public string Name { get; set; }

        public Controller(string callsign, string frequency)
        {
            Callsign = callsign;
            Frequency = frequency;
        }
    }
}