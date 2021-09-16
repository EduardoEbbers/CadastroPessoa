using CadatroPessoaWebApi.Models;
using CadatroPessoaWebApi.Repositories.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Repositories
{
    public class TelefoneRepository : IRepository<Telefone>
    {
        private IDao<Telefone> _telefonesDAO;

        public TelefoneRepository(IDao<Telefone> telefonesDAO)
        {
            _telefonesDAO = telefonesDAO;
        }

        public Telefone Insert(Telefone telefone)
        {
            Telefone _tel;
            try
            {
                _tel = _telefonesDAO.Insert(telefone);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _tel;
        }

        public IList<Telefone> GetAll()
        {
            IList<Telefone> _tel;
            try
            {
                _tel = _telefonesDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _tel;
        }

        public Telefone GetById(int id)
        {
            Telefone _tel;
            try
            {
                _tel = _telefonesDAO.GetById(t => t.IdTelefone == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _tel;
        }

        public Telefone Update(Telefone telefone)
        {
            Telefone _tel;
            try
            {
                _tel = _telefonesDAO.GetById(t => t.IdTelefone == telefone.IdTelefone);
                if (_tel != null)
                {
                    _tel.Numero = telefone.Numero;
                    _tel.Ddd = telefone.Ddd;
                    //_tel.IdTelefoneTipo = telefone.IdTelefoneTipo ??
                    _tel = _telefonesDAO.Update(_tel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _tel;
        }

        public void Delete(int id)
        {
            Telefone _tel;
            try
            {
                _tel = _telefonesDAO.GetById(t => t.IdTelefone == id);
                if (_tel != null)
                {
                    _telefonesDAO.Delete(t => t.IdTelefone == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
