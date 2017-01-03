using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawmoth.OpusOne.Core.Repositories
{
    public interface IRepository<TModel>  where TModel : Model
    {
        Task<TModel> GetAsync(long Id);

        Task InsertAsync(TModel model);

        Task UpdateAsync(TModel model);

        Task DeleteAsync(TModel model);

        Task CreateTableAsync();

    }
}
