using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kniffel
{
    //erleichtert arbeiten mit würfen
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
        kleinestrasse = 10,
        grossestrasse = 11,
        kniffel = 12,

        fehler = 13
    }
}