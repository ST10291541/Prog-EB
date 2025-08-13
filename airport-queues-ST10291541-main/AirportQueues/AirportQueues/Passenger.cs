using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportQueues
{
    public class Passenger
    {
        public string Name { get; set; }
        public string ClassType { get; set; }
        public int CheckInTime { get; set; } // minutes per passenger

        public Passenger(string name, string classType, int checkInTime)
        {
            Name = name;
            ClassType = classType;
            CheckInTime = checkInTime;
        }
    }
}
