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
    public class TelefoneService : IService<Telefone>
    {
        private IRepository<Telefone> _telefoneRepository;

        public TelefoneService(IRepository<Telefone> telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        public async Task<Telefone> Create(Telefone telefone)
        {
            Telefone _tel;
            try
            {
                _tel = _telefoneRepository.Insert(telefone);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _tel;
        }

        public async Task<IList<Telefone>> GetAll()
        {
            IList<Telefone> _tel;
            try
            {
                _tel = _telefoneRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _tel;
        }

        public async Task<Telefone> GetById(int id)
        {
            Telefone _tel;
            try
            {
                _tel = _telefoneRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.NotFound);
            }
            return _tel;
        }

        public async Task<Telefone> Update(Telefone telefone)
        {
            Telefone _tel;
            try
            {
                _tel = _telefoneRepository.Update(telefone);

            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.NotFound);
            }
            return _tel;
        }

        public void Delete(int id)
        {
            try
            {
                _telefoneRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.NotFound);
            }
        }
    }
}
