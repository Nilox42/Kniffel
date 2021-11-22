using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kniffel
{
    public enum würfe
    {
        einer = 1,
        zweier = 2,
        dreier = 3,
        vierer = 4,
        fuenfer = 5,
        sechser = 6,
        dreierpasch = 7,
        viererpasch = 8,
        fullhouse = 9,
        kleiestrasse = 10,
        grossestrase = 11,
        kniffel = 12
    }

    public class Spieler
    {
        public int ID { get; private set; }

        public List<List<int>> letzewuerfe = new List<List<int>>();

        

    }
}