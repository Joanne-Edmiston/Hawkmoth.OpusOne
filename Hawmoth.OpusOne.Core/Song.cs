using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawmoth.OpusOne.Core
{
    public class Song : Model
    {
        public string Name { get; set; }

        public string FileLocation { get; set; }

        public int TrackNumber { get; set; }

    }
}
