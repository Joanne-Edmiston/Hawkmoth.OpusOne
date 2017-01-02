using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Hawmoth.OpusOne.Core
{
    public class PlayList
    {
        private List<StorageFile> _songs;

        public string Name { get; set; }
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
