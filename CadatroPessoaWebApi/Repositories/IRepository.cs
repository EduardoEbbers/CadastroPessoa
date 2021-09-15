using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Insert(T t);
        IList<T> GetAll();
        T GetById(int id);
        T Update(T t);
        void Delete(int id);
    }
}
