using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaratkezelo
{
    class NegativKesesException : Exception
    {
        public NegativKesesException(string Jaratszam)
            : base("Negatív késést nem lehet megadni: " + Jaratszam)
        {

        }

    }
}
