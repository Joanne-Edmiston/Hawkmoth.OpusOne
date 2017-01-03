using Hawmoth.OpusOne.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hawmoth.OpusOne.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TModel> GetRepository<TModel>() where TModel : Model;


    }
}
