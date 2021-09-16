using CadatroPessoaWebApi.Models;
using CadatroPessoaWebApi.Repositories.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Repositories
{
    public class EnderecoRepository : IRepository<Endereco>
    {
        private IDao<Endereco> _enderecosDAO;

        public EnderecoRepository(IDao<Endereco> enderecoDAO)
        {
            _enderecosDAO = enderecoDAO;
        }

        public Endereco Insert(Endereco endereco)
        {
            Endereco _end;
            try
            {
                _end = _enderecosDAO.Insert(endereco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _end;
        }

        public IList<Endereco> GetAll()
        {
            IList<Endereco> _end;
            try
            {
                _end = _enderecosDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _end;
        }

        public Endereco GetById(int id)
        {
            Endereco _end;
            try
            {
                _end = _enderecosDAO.GetById(e => e.IdEndereco == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _end;
        }

        public Endereco Update(Endereco endereco)
        {
            Endereco _end;
            try
            {
                _end = _enderecosDAO.GetById(e => e.IdEndereco == endereco.IdEndereco);
                if (_end != null)
                {
                    _end.Logradouro = endereco.Logradouro;
                    _end.Numero = endereco.Numero;
                    _end.Cep = endereco.Cep;
                    _end.Bairro = endereco.Bairro;
                    _end.Cidade = endereco.Cidade;
                    _end.Estado = endereco.Estado;
                    _end = _enderecosDAO.Update(_end);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _end;
        }

        public void Delete(int id)
        {
            Endereco _end;
            try
            {
                _end = _enderecosDAO.GetById(e => e.IdEndereco == id);
                if (_end != null)
                {
                    _enderecosDAO.Delete(e => e.IdEndereco == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
