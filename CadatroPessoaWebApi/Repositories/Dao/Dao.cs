using CadatroPessoaWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Repositories.Dao
{
    public class Dao<T> : IDao<T> where T : class
    {
        private readonly cadastropessoaContext _contexto;

        public Dao()
        {
            _contexto = new cadastropessoaContext(new DbContextOptions<cadastropessoaContext>());
        }

        public T Insert(T t)
        {
            EntityEntry<T> _t;
            try
            {
                _t = _contexto
                    .Set<T>()
                    .Add(t);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _t.Entity;
        }

        public virtual IList<T> GetAll()
        {
            IList<T> _t;
            try
            {
                _t = _contexto
                    .Set<T>()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _t;
        }

        public virtual T GetById(Expression<Func<T, bool>> predicate)
        {
            T _t;
            try
            {
                _t = _contexto
                    .Set<T>()
                    .SingleOrDefault(predicate);
                if (_t == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(GetType().GenericTypeArguments[0].Name + " Não Encontrado!");
            }
            return _t;
        }

        public virtual T Update(T t)
        {
            EntityEntry<T> _t;
            try
            {
                _t = _contexto.Set<T>().Update(t);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _t.Entity;
        }

        public virtual void Delete(Func<T, bool> predicate)
        {
            try
            {
                _contexto
                .Set<T>()
                .Where(predicate)
                .ToList()
                .ForEach(del => _contexto.Set<T>().Remove(del));
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
