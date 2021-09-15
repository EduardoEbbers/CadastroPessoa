using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Controllers
{
    public class Controller<T> : IController<T> where T : class
    {
    }
}
