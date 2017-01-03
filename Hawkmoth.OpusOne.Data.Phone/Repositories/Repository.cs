using Hawmoth.OpusOne.Core;
using Hawmoth.OpusOne.Core.Repositories;
using SQLite;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hawkmoth.OpusOne.Data.Phone.Repositories
{
    public abstract class Repository<TModel, TRecord> : IRepository<TModel> where TModel : Model where TRecord : Record, new()
    {
        private SQLiteAsyncConnection dbConnection;

        protected abstract TModel Translate(TRecord record);
        protected abstract TRecord Translate(TModel model);


        public Repository(SQLiteAsyncConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public virtual async Task InsertAsync(TModel model)
        {
            await dbConnection.InsertAsync(Translate(model));
        }

        public virtual async Task DeleteAsync(TModel model)
        {
            await dbConnection.DeleteAsync(Translate(model));   
        }

        public async Task<TModel> GetAsync(long Id)
        {
            var record = await dbConnection.FindAsync<TRecord>(Id);

            return Translate(record);
        }

        public Task UpdateAsync(TModel model)
        {
            throw new NotImplementedException();
        }

        public async Task CreateTableAsync()
        {
            await dbConnection.CreateTableAsync<TRecord>();
        }
    }
}
