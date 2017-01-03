using Hawmoth.OpusOne.Core;
using Hawmoth.OpusOne.Core.Repositories;
using SQLite;
using SQLite.Net.Async;

namespace Hawkmoth.OpusOne.Data.Phone.Repositories
{
    public class SongRepository : Repository<Song, SongRecord>, ISongRepository
    {
        public SongRepository(SQLiteAsyncConnection dbConnection) : base(dbConnection)
        {
        }

        protected override SongRecord Translate(Song model)
        {
            return model.Translate();
        }

        protected override Song Translate(SongRecord record)
        {
            return record.Translate();
        }
    }

 
}
