using CadatroPessoaWebApi.Exceptions;
using CadatroPessoaWebApi.Models;
using CadatroPessoaWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Services
{
    public class PessoaService : IService<Pessoa>
    {
        private IRepository<Pessoa> _pessoaRepository;

        public PessoaService(IRepository<Pessoa> pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Pessoa> Create(Pessoa pessoa)
        {
            Pessoa _pes;
            try
            {
                _pes = _pessoaRepository.Insert(pessoa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _pes;
        }

        public async Task<IList<Pessoa>> GetAll()
        {
            IList<Pessoa> _pes;
            try
            {
                _pes = _pessoaRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _pes;
        }

        public async Task<Pessoa> GetById(int id)
        {
            Pessoa _pes;
            try
            {
                _pes = _pessoaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.NotFound);
            }
            return _pes;
        }

        public async Task<Pessoa> Update(Pessoa pessoa)
        {
            Pessoa _pes;
            try
            {
                _pes = _pessoaRepository.Update(pessoa);

            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.NotFound);
            }
            return _pes;
        }

        public void Delete(int id)
        {
            try
            {
                _pessoaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.NotFound);
            }
        }
    }
}
