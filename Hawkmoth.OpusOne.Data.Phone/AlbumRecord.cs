using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using SQLite.Net.Attributes;

namespace Hawkmoth.OpusOne.Data.Phone
{
    public class AlbumRecord : Record
    {
        private DateTime? syncDate;

        [Indexed]
        public string Name { get; set; }

        [Indexed]
        public string Artist { get; set; }

        [Indexed]
        public string AlbumArtist { get; set; }

        public DateTime SyncDate
        {
            get
            {
                if (syncDate == null)
                    syncDate = DateTime.UtcNow;

                return syncDate.Value;
            }
            set
            {
                syncDate = value;
            }

        }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<SongRecord> Songs { get; set; }
    }
}
