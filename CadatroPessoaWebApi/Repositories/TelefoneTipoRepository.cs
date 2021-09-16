using CadatroPessoaWebApi.Models;
using CadatroPessoaWebApi.Repositories.Dao;
using CadatroPessoaWebApi.Repositories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Repositories
{
    public class TelefoneTipoRepository : IRepository<TelefoneTipo>
    {
        private IDao<TelefoneTipo> _telefoneTipoDao;

        public TelefoneTipoRepository(IDao<TelefoneTipo> telefoneTipoDao)
        {
            _telefoneTipoDao = telefoneTipoDao;
        }

        public TelefoneTipo Insert(TelefoneTipo telefoneTipo)
        {
            TelefoneTipo _telTip;
            try
            {
                _telTip = _telefoneTipoDao.Insert(telefoneTipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _telTip;
        }

        public IList<TelefoneTipo> GetAll()
        {
            IList<TelefoneTipo> _telTip;
            try
            {
                _telTip = _telefoneTipoDao.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _telTip;
        }

        public TelefoneTipo GetById(int id)
        {
            TelefoneTipo _telTip;
            try
            {
                _telTip = _telefoneTipoDao.GetById(tt => tt.IdTelefoneTipo == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _telTip;
        }

        public TelefoneTipo Update(TelefoneTipo telefoneTipo)
        {
            TelefoneTipo _telTip;
            try
            {
                _telTip = _telefoneTipoDao.GetById(tt => tt.IdTelefoneTipo == telefoneTipo.IdTelefoneTipo);
                if (_telTip != null)
                {
                    _telTip.Tipo = telefoneTipo.Tipo;
                    _telTip = _telefoneTipoDao.Update(_telTip);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _telTip;
        }

        public void Delete(int id)
        {
            TelefoneTipo _telTip;
            try
            {
                _telTip = _telefoneTipoDao.GetById(tt => tt.IdTelefoneTipo == id);
                if (_telTip != null)
                {
                    _telefoneTipoDao.Delete(tt => tt.IdTelefoneTipo == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
