using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Controllers
{
    public interface IController<S, T> where S : class
    {
        Task<ActionResult<S>> Post(T t);  
        Task<ActionResult<IList<S>>> GetAll();
        Task<ActionResult<S>> GetById(int id);
        Task<ActionResult<S>> Update(T t);
        ActionResult Delete(int id);
    }
}
