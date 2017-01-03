using Hawmoth.OpusOne.Core;
using Hawmoth.OpusOne.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Async;

namespace Hawkmoth.OpusOne.Data.Phone.Repositories
{
    public class AlbumRepository : Repository<Album, AlbumRecord>, IAlbumRepository
    {
        public AlbumRepository(SQLiteAsyncConnection dbConnection) : base(dbConnection)
        {
        }

        
        protected override Album Translate(AlbumRecord record)
        {
            return record.Translate();
        }

        protected override AlbumRecord Translate(Album model)
        {
            return model.Translate();
        }
    }
}
