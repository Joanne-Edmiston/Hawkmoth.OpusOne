using Hawmoth.OpusOne.Core.Repositories;
using System;
using System.Collections.Generic;
using Hawmoth.OpusOne.Core;
using SQLite;
using Hawkmoth.OpusOne.Data.Phone.Repositories;
using SQLite.Net.Async;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;

namespace Hawkmoth.OpusOne.Data.Phone
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private readonly SQLiteAsyncConnection dbConn;

        public UnitOfWork(string dbPath)
        {
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: true)));
            dbConn = new SQLiteAsyncConnection(connectionFactory);
        }


        public IRepository<TModel> GetRepository<TModel>() where TModel : Model
        {

            var repositoryKey = typeof(TModel);
            if (!repositories.ContainsKey(repositoryKey))
            {
                if (typeof(TModel) == typeof(Album))
                    repositories.Add(repositoryKey, new AlbumRepository(dbConn));

                else if (typeof(TModel) == typeof(Song))
                    repositories.Add(repositoryKey, new SongRepository(dbConn));

                else
                    throw new InvalidOperationException($"There is no repository defined for {typeof(TModel)}");
            }

            return (IRepository<TModel>)repositories[repositoryKey];



        }


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // close connection?
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

    }
}
