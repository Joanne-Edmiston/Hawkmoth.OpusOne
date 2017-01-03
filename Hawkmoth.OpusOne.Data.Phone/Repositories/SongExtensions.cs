using Hawmoth.OpusOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkmoth.OpusOne.Data.Phone.Repositories
{
    public static class SongExtensions
    {
        public static SongRecord Translate(this Song model)
        {
            return new SongRecord
            {
                Id = model.Id,
                FileLocation = model.FileLocation,
                Name = model.Name,
                TrackNumber = model.TrackNumber,
            };
            
        }

        public static Song Translate(this SongRecord record)
        {
            return new Song
            {
                Id = record.Id,
                FileLocation = record.FileLocation,
                Name = record.Name,
                TrackNumber = record.TrackNumber,
            };

        }

    }
}
