using CadatroPessoaWebApi.Models;
using CadatroPessoaWebApi.Repositories.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Repositories
{
    public class PessoaRepository : IRepository<Pessoa>
    {
        IDao<Pessoa> _pessoaDao;

        public PessoaRepository(IDao<Pessoa> pessoaDao)
        {
            _pessoaDao = pessoaDao;
        }

        public Pessoa Insert(Pessoa pessoa)
        {
            Pessoa _pes;
            try
            {
                _pes = _pessoaDao.Insert(pessoa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _pes;
        }

        public IList<Pessoa> GetAll()
        {
            IList<Pessoa> _pes;
            try
            {
                _pes = _pessoaDao.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _pes;
        }

        public Pessoa GetById(int id)
        {
            Pessoa _pes;
            try
            {
                _pes = _pessoaDao.GetById(p => p.IdPessoa == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _pes;
        }

        public Pessoa Update(Pessoa pessoa)
        {
            Pessoa _pes;
            try
            {
                _pes = _pessoaDao.GetById(p => p.IdPessoa == pessoa.IdPessoa);
                if (_pes != null)
                {
                    _pes.Nome = pessoa.Nome;
                    _pes.Cpf = pessoa.Cpf;
                    _pes = _pessoaDao.Update(_pes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _pes;
        }

        public void Delete(int id)
        {
            Pessoa _pes;
            try
            {
                _pes = _pessoaDao.GetById(p => p.IdPessoa == id);
                if (_pes != null)
                {
                    _pessoaDao.Delete(p => p.IdPessoa == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
