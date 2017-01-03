using Hawmoth.OpusOne.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawkmoth.OpusOne.Data.Phone.Repositories
{
    public static class AlbumExtensions
    {
        public static AlbumRecord Translate(this Album model)
        {
            return new AlbumRecord
            {
                Id = model.Id,
                AlbumArtist = model.AlbumArtist,
                Artist = model.Artist,
                Name = model.Name,
                Songs = model.Songs.Select(s => s.Translate()).ToList()
            };
        }

        public static Album Translate(this AlbumRecord record)
        {
            return new Album
            {
                Id = record.Id,
                AlbumArtist = record.AlbumArtist,
                Artist = record.Artist,
                Name = record.Name,
                Songs = record.Songs.Select(s => s.Translate()).ToList()
            };
        }
    }
}
