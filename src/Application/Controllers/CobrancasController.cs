using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cobrancas.Application.Models;
using Cobrancas.Domain.Entities;
using Cobrancas.Domain.Interfaces;
using Cobrancas.Service.Validators;
using FluentValidation;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Cobrancas.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobrancasController : ControllerBase
    {
        private readonly IBaseService<Cobranca> _service;

        private readonly ILogger<CobrancasController> _logger;

        public CobrancasController(IBaseService<Cobranca> service, ILogger<CobrancasController> logger)
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet]
        public async Task<IList<Cobranca>> GetFilterAsync([FromQuery] FilterParameters filter)
        {
            filter.CPF = filter.CPF?.Replace("-", "").Replace(".", "");
            return await _service.GetAllAsync(
                f => f.CPF == filter.CPF
                  || f.Valor == filter.valor
                  || f.Vencimento == filter.vencimento);

        }


        [HttpGet("{id:length(24)}", Name = "GetCobranca")]
        public async Task<ActionResult<Cobranca>> GeAsync(string id)
        {
            var cobranca = await _service.GetAsync(id);

            if (cobranca == null)
                return NotFound();

            return cobranca;
        }

        [HttpPost]
        public async Task<ActionResult<Cobranca>> InsertAsync(CreateCobrancaRequest cobrancaRequest)
        {
            try
            {
                var cobrancaOut = await _service.AddAsync<CreateCobrancaRequest, CobrancaResponse, CobrancaValidator>(cobrancaRequest);

                return Created(string.Empty, cobrancaOut);
            }
            catch (ValidationException ex)
            {
                // ALterar para Middleware
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateAsync(string id, CobrancaRequest cobrancaRequest)
        {
            var cobranca = _service.GetAsync(id);

            if (cobranca == null)
                return NotFound();

            await _service.UpdateAsync<CobrancaRequest, CobrancaValidator>(id, cobrancaRequest);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var cobranca = await _service.GetAsync(id);

            if (cobranca == null)
                return NotFound();

            await _service.RemoveAsync(cobranca.Id);

            return NoContent();
        }
    }
}