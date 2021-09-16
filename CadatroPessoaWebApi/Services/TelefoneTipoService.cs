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
    public class TelefoneTipoService : IService<TelefoneTipo>
    {
        private IRepository<TelefoneTipo> _telefoneTipoRepository;

        public TelefoneTipoService(IRepository<TelefoneTipo> telefoneTipoRepository)
        {
            _telefoneTipoRepository = telefoneTipoRepository;
        }

        public async Task<TelefoneTipo> Create(TelefoneTipo telefoneTipo)
        {
            TelefoneTipo _telTip;
            try
            {
                _telTip = _telefoneTipoRepository.Insert(telefoneTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _telTip;
        }

        public async Task<IList<TelefoneTipo>> GetAll()
        {
            IList<TelefoneTipo> _telTip;
            try
            {
                _telTip = _telefoneTipoRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _telTip;
        }

        public async Task<TelefoneTipo> GetById(int id)
        {
            TelefoneTipo _telTip;
            try
            {
                _telTip = _telefoneTipoRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.NotFound);
            }
            return _telTip;
        }

        public async Task<TelefoneTipo> Update(TelefoneTipo telefoneTipo)
        {
            TelefoneTipo _telTip;
            try
            {
                _telTip = _telefoneTipoRepository.Update(telefoneTipo);

            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.NotFound);
            }
            return _telTip;
        }

        public void Delete(int id)
        {
            try
            {
                _telefoneTipoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.NotFound);
            }
        }
    }
}
