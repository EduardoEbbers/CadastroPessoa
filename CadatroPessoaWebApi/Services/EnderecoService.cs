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
    public class EnderecoService : IService<Endereco>
    {
        private IRepository<Endereco> _enderecoRepository;

        public EnderecoService(IRepository<Endereco> enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<Endereco> Create(Endereco endereco)
        {
            Endereco _end;
            try
            {
                _end = _enderecoRepository.Insert(endereco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _end;
        }

        public async Task<IList<Endereco>> GetAll()
        {
            IList<Endereco> _end;
            try
            {
                _end = _enderecoRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _end;
        }

        public async Task<Endereco> GetById(int id)
        {
            Endereco _end;
            try
            {
                _end = _enderecoRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.NotFound);
            }
            return _end;
        }

        public async Task<Endereco> Update(Endereco endereco)
        {
            Endereco _end;
            try
            {
                _end = _enderecoRepository.Update(endereco);

            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.NotFound);
            }
            return _end;
        }

        public void Delete(int id)
        {
            try
            {
                _enderecoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.NotFound);
            }
        }
    }
}
