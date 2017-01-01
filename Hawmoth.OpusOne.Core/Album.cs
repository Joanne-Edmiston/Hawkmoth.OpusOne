using System.Collections.Generic;
using Windows.Storage;

namespace Hawmoth.OpusOne.Core
{
    public class Album
    {
        private List<StorageFile> _songs;

        public string Name { get; set; }
        public string Artist { get; set; }
        public List<StorageFile> Songs
        {
            get
            {
                return _songs ?? (_songs = new List<StorageFile>());
            }
            set
            {
                _songs = value;
            }
        }
    }
}
