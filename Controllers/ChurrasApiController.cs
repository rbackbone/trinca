using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Trinca.Churras.WebApp.Models;
using Trinca.Churras.WebApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trinca.Churras.WebApp.Controllers
{
    [ApiController]
    [Route("/api/churras")]
    public class ChurrasApiController : ControllerBase
    {
        IChurrasService _service;

        public ChurrasApiController(IChurrasService service)
        {
            _service = service;
        }
        
        // GET: api/<ApiController>
        [HttpGet]
        public IEnumerable<ChurrasAgenda> Get()
        {
            var agendas = _service.ListarAgendaChurras();
            return agendas;
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public ChurrasAgenda Get(int id)
        {
            var agenda = _service.ConsultarChurras(id);
            return agenda;
        }

        // POST api/<ApiController>
        [HttpPost]
        public IActionResult Post([FromBody] ChurrasAgenda obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.CadastrarChurras(obj);
            return Ok(obj);
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChurrasAgenda obj)
        {
            if (_service.ConsultarChurras(id) == null) return NotFound();
            
            _service.AlterarChurras(obj);
            return Ok();
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.ConsultarChurras(id) == null) return NotFound();

            _service.ExcluirChurras(id);
            return Ok();
        }

        // GET api/<ApiController>/5
        [HttpGet, Route("{id}/listarParticipantes")]
        public IEnumerable<ParticipanteChurras> ListarParticipantes(int id)
        {
            var leiloes = _service.ListarParticipantes(id);
            return leiloes;
        }

        // POST api/<ApiController>
        [HttpPost, Route("incluirParticipante")]
        public IActionResult Post([FromBody] ParticipanteChurras obj)
        {
            _service.IncluirParticipante(obj);
            return Ok();
        }

        // DELETE api/<ApiController>/5
        [HttpDelete, Route("{id}/excluirParticipante")]
        public IActionResult ExcluirParticipante(ParticipanteChurras obj)
        {
            if (_service.ConsultarParticipante(obj) == null) return NotFound();

            _service.ExcluirParticipante(obj.Id);
            return Ok();
        }

    }
}
