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
    [Route("api/telefoneTipo")]
    [ApiController]
    public class TelefoneTipoController : ControllerBase, IController<TelefoneTipo, TelefoneTipoDto>
    {
        private readonly IService<TelefoneTipo> _telefoneTipoService;

        public TelefoneTipoController(IService<TelefoneTipo> telefoneTipoService)
        {
            _telefoneTipoService = telefoneTipoService;
        }

        // POST: api/telefoneTipo
        [HttpPost]
        public async Task<ActionResult<TelefoneTipo>> Post(TelefoneTipoDto telefoneTipo)
        {
            TelefoneTipo _telTip;
            try
            {
                //TipoTelefoneValidacao.ValidarTipoTelefone([telefoneTipo, telefoneTipo.Cpf]);

                if (telefoneTipo.Tipo == null)
                {
                    throw new HttpException("Tipo de Telefone é Obrigatório!", HttpStatusCode.BadRequest);
                }

                _telTip = await _telefoneTipoService.Create(telefoneTipo.ParseToObject());
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return CreatedAtAction(nameof(GetById), new { id = _telTip.IdTelefoneTipo }, _telTip);
        }

        // GET: api/telefoneTipo
        [HttpGet]
        public async Task<ActionResult<IList<TelefoneTipo>>> GetAll()
        {
            IList<TelefoneTipo> _telTip;
            try
            {
                _telTip = await _telefoneTipoService.GetAll();
            }
            // ta faltando ajeitar esta parte
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return Ok(_telTip);
        }

        // GET: api/telefoneTipo/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TelefoneTipo>> GetById(int id)
        {
            TelefoneTipo _telTip;
            try
            {
                if (id <= 0)
                {
                    throw new HttpException("Id Telefone Tipo Incorreto!", HttpStatusCode.BadRequest);
                }
                _telTip = await _telefoneTipoService.GetById(id);
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return Ok(_telTip);
        }

        // PUT: api/telefoneTipo
        [HttpPut]
        public async Task<ActionResult<TelefoneTipo>> Update(TelefoneTipoDto telefoneTipo)
        {
            TelefoneTipo _telTip;
            try
            {
                if (telefoneTipo.IdTelefoneTipo == 0 
                    || telefoneTipo.Tipo == null)
                {
                    throw new HttpException("Id Telefone Tipo e Tipo é Obrigatório!", HttpStatusCode.BadRequest);
                }

                if (telefoneTipo.IdTelefoneTipo < 0)
                {
                    throw new HttpException("Id Telefone Tipo Incorreto!", HttpStatusCode.BadRequest);
                }
                _telTip = await _telefoneTipoService.Update(telefoneTipo.ParseToObject());
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return Ok(_telTip);
        }

        // DELETE: api/telefoneTipo/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new HttpException("Id Telefone Tipo Incorreto!", HttpStatusCode.BadRequest);
                }
                _telefoneTipoService.Delete(id);
            }
            catch (HttpException e)
            {
                return e.HttpMessageException();
            }
            return NoContent();
        }
    }
}
