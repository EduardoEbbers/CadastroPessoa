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
    [Route("api/telefone")]
    [ApiController]
    public class TelefoneController : ControllerBase, IController<Telefone, TelefoneDto>
    {
        private readonly IService<Telefone> _telefonesService;

        public TelefoneController(IService<Telefone> telefonesService)
        {
            _telefonesService = telefonesService;
        }

        // POST: api/telefone
        [HttpPost]
        public async Task<ActionResult<Telefone>> Post(TelefoneDto telefone)
        {
            Telefone _tel;
            try
            {
                //TelefoneValidacao.ValidarTelefone([telefone, telefone.Cpf]);

                if (telefone.Numero == 0 || 
                    telefone.Ddd == 0 ||
                    telefone.IdTelefone == 0)
                {
                    throw new HttpException("Número, DDD e Id Telefone são Obrigatórios!", HttpStatusCode.BadRequest);
                }
                if (telefone.IdTelefone < 0)
                {
                    throw new HttpException("Id Telefone Incorreto!", HttpStatusCode.BadRequest);
                }
                _tel = await _telefonesService.Create(telefone.ParseToObject());
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return CreatedAtAction(nameof(GetById), new { id = _tel.IdTelefone }, _tel);
        }

        // GET: api/telefone
        [HttpGet]
        public async Task<ActionResult<IList<Telefone>>> GetAll()
        {
            IList<Telefone> _tel;
            try
            {
                _tel = await _telefonesService.GetAll();
            }
            // ta faltando ajeitar esta parte
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return Ok(_tel);
        }

        // GET: api/telefone/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Telefone>> GetById(int id)
        {
            Telefone _tel;
            try
            {
                if (id <= 0)
                {
                    throw new HttpException("Id Telefone Incorreto!", HttpStatusCode.BadRequest);
                }
                _tel = await _telefonesService.GetById(id);
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return Ok(_tel);
        }

        // PUT: api/telefone
        [HttpPut]
        public async Task<ActionResult<Telefone>> Update(TelefoneDto telefone)
        {
            Telefone _tel;
            try
            {
                if (telefone.IdTelefone == 0 || 
                    telefone.Numero == 0 || 
                    telefone.Ddd == 0 ||
                    telefone.IdTelefoneTipo == 0)
                {
                    throw new HttpException("Id Telefone, Número, DDD e Id Telefone Tipo são Obrigatórios!", HttpStatusCode.BadRequest);
                }

                if (telefone.IdTelefone < 0)
                {
                    throw new HttpException("Id Telefone Incorreto!", HttpStatusCode.BadRequest);
                }
                if (telefone.IdTelefoneTipo < 0)
                {
                    throw new HttpException("Id Telefone Tipo Incorreto!", HttpStatusCode.BadRequest);
                }
                _tel = await _telefonesService.Update(telefone.ParseToObject());
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return Ok(_tel);
        }

        // DELETE: api/telefone/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new HttpException("ID Incorreto!", HttpStatusCode.BadRequest);
                }
                _telefonesService.Delete(id);
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return NoContent();
        }
    }
}
