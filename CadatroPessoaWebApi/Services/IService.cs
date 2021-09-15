using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Services
{
    public interface IService<T> where T : class
    {
        public Task<T> Create(T t);
        public Task<IList<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> Update(T t);
        public void Delete(int id);
    }
}
