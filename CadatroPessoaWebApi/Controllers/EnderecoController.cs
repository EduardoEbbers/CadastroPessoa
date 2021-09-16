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
    [Route("api/endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase, IController<Endereco, EnderecoDto>
    {
        private readonly IService<Endereco> _enderecoService;

        public EnderecoController(IService<Endereco> enderecoService)
        {
            _enderecoService = enderecoService;
        }

        // POST: api/endereco
        [HttpPost]
        public async Task<ActionResult<Endereco>> Post(EnderecoDto endereco)
        {
            Endereco _end;
            try
            {
                //EnderecoValidacao.ValidarEndereco([endereco, endereco.Cpf]);

                if (endereco.Logradouro == null ||
                    endereco.Numero == 0 ||
                    endereco.Cep == 0 ||
                    endereco.Bairro == null ||
                    endereco.Cidade == null ||
                    endereco.Estado == null)
                {
                    throw new HttpException("Logradouro, Número, Cep, Bairro, Cidade e Estado são Obrigatórios!", HttpStatusCode.BadRequest);
                }

                _end = await _enderecoService.Create(endereco.ParseToObject());
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return CreatedAtAction(nameof(GetById), new { id = _end.IdEndereco }, _end);
        }

        // GET: api/endereco
        [HttpGet]
        public async Task<ActionResult<IList<Endereco>>> GetAll()
        {
            IList<Endereco> _end;
            try
            {
                _end = await _enderecoService.GetAll();
            }
            // ta faltando ajeitar esta parte
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return Ok(_end);
        }

        // GET: api/endereco/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetById(int id)
        {
            Endereco _end;
            try
            {
                if (id <= 0)
                {
                    throw new HttpException("Id Endereço Incorreto!", HttpStatusCode.BadRequest);
                }
                _end = await _enderecoService.GetById(id);
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return Ok(_end);
        }

        // PUT: api/endereco
        [HttpPut]
        public async Task<ActionResult<Endereco>> Update(EnderecoDto endereco)
        {
            Endereco _end;
            try
            {
                if (endereco.IdEndereco == 0 ||
                    endereco.Logradouro == null ||
                    endereco.Numero == 0 ||
                    endereco.Cep == 0 ||
                    endereco.Bairro == null ||
                    endereco.Cidade == null ||
                    endereco.Estado == null)
                {
                    throw new HttpException("Id Endereço, Logradouro, Número, Cep, Bairro, Cidade e Estado são Obrigatórios!", HttpStatusCode.BadRequest);
                }

                if (endereco.IdEndereco < 0)
                {
                    throw new HttpException("Id Endereço Incorreto!", HttpStatusCode.BadRequest);
                }
                _end = await _enderecoService.Update(endereco.ParseToObject());
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return Ok(_end);
        }

        // DELETE: api/endereco/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new HttpException("Id Endereço Incorreto!", HttpStatusCode.BadRequest);
                }
                _enderecoService.Delete(id);
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return NoContent();
        }
    }
}
