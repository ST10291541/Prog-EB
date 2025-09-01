using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQueue
{
    public class Patient
    {
        public string Name { get; set; }
        public int Severity { get; set; }  // Higher = more severe

        public Patient(string name, int severity)
        {
            Name = name;
            Severity = severity;
        }

        public override string ToString()
        {
            return $"{Name} (Severity: {Severity})";
        }
    }
}
