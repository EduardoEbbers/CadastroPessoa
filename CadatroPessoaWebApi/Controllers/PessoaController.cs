using CadatroPessoaWebApi.Exceptions;
using CadatroPessoaWebApi.Models;
using CadatroPessoaWebApi.Repositories.Dto;
using CadatroPessoaWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi.Controllers
{
    [Route("api/pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase, IController<Pessoa, PessoaDto>
    {
        private readonly IService<Pessoa> _pessoaService;

        public PessoaController(IService<Pessoa> pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // POST: api/pessoa
        [HttpPost]
        public async Task<ActionResult<Pessoa>> Post(PessoaDto pessoa)
        {
            Pessoa _pes;
            try
            {
                //PessoaValidacao.ValidarPessoa([pessoa, pessoa.Cpf]);
                if (pessoa.Nome == null || pessoa.Cpf == null || pessoa.IdEndereco == 0)
                {
                    throw new HttpException("Nome, CPF e Id Endereço são Obrigatórios!", HttpStatusCode.BadRequest);
                }
                if(pessoa.IdEndereco < 0)
                {
                    throw new HttpException("Id Endereço Incorreto!", HttpStatusCode.BadRequest);
                }

                _pes = await _pessoaService.Create(pessoa.ParseToObject());
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return CreatedAtAction(nameof(GetById), new { id = _pes.IdPessoa }, _pes);
        }

        // GET: api/pessoa
        [HttpGet]
        public async Task<ActionResult<IList<Pessoa>>> GetAll()
        {
            IList<Pessoa> _pes;
            try
            {
                _pes = await _pessoaService.GetAll();
            } 
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return Ok(_pes);
        }

        // GET: api/pessoa/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetById(int id)
        {
            Pessoa _pes;
            try
            {
                if (id <= 0)
                {
                    throw new HttpException("Id Pessoa Incorreto!", HttpStatusCode.BadRequest);
                }
                _pes = await _pessoaService.GetById(id);
            } 
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return Ok(_pes);
        }

        // PUT: api/pessoa
        [HttpPut]
        public async Task<ActionResult<Pessoa>> Update(PessoaDto pessoa)
        {
            Pessoa _pes;
            try
            {
                if (pessoa.IdPessoa == 0 || pessoa.Nome == null || pessoa.Cpf == null || pessoa.IdEndereco == 0)
                {
                    throw new HttpException("Id Pessoa, Nome, CPF e Id Endereço são Obrigatórios!", HttpStatusCode.BadRequest);
                }
                if (pessoa.IdPessoa < 0)
                {
                    throw new HttpException("Id Pessoa Incorreto!", HttpStatusCode.BadRequest);
                }
                if (pessoa.IdEndereco < 0)
                {
                    throw new HttpException("Id Endereço Incorreto!", HttpStatusCode.BadRequest);
                }
                _pes = await _pessoaService.Update(pessoa.ParseToObject());
            } 
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return Ok(_pes);
        }

        // DELETE: api/pessoa/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new HttpException("Id Pessoa Incorreto!", HttpStatusCode.BadRequest);
                }
                _pessoaService.Delete(id);
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return NoContent();
        }
    }
}
