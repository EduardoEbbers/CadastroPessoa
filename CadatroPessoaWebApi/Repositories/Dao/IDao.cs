using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Repositories.Dao
{
    public interface IDao<T> where T : class
    {
        T Insert(T t);
        IList<T> GetAll();
        T GetById(Expression<Func<T, bool>> predicate);
        T Update(T t);
        void Delete(Func<T, bool> predicate);
    }
}
