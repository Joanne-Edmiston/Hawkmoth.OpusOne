using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Hawkmoth.OpusOne.Data.Phone
{
    public class SongRecord : Record
    {
        [Indexed]
        public string Name { get; set; }

        public string FileLocation { get; set; }

        public int TrackNumber { get; set; }

    }
}
