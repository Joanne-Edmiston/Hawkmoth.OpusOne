using System.Collections.Generic;
using Windows.Storage;

namespace Hawmoth.OpusOne.Core
{
    public class Album : Model
    {
        private List<StorageFile> songFiles;
        private List<Song> songs;

        public string Name { get; set; }
        public string Artist { get; set; }
        public string AlbumArtist { get; set; }

        public List<Song> Songs
        {
            get
            {
                return songs ?? (songs = new List<Song>());
            }
            set
            {
                songs = value;
            }
        }

        public List<StorageFile> SongFiles
        {
            get
            {
                return songFiles ?? (songFiles = new List<StorageFile>());
            }
            set
            {
                songFiles = value;
            }
        }
    }
}
