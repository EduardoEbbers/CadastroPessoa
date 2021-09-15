using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Controllers
{
    public interface IController<T> where T : class
    {
        Task<ActionResult<T>> Post(T t);
        Task<ActionResult<IList<T>>> GetAll();
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult<T>> Update(T t);
        ActionResult Delete(int id);
    }
}
