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
        
        // GET: api/churras
        [HttpGet]
        public IEnumerable<ChurrasAgenda> Get()
        {
            var agendas = _service.ListarAgendaChurras();
            return agendas;
        }

        // GET api/churras/5
        [HttpGet("{id}")]
        public ChurrasAgendaDto Get(int id)
        {
            var agenda = _service.ConsultarChurras(id);
            return agenda;
        }

        // POST api/churras
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

        // PUT api/churras/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChurrasAgenda obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_service.ConsultarChurras(id) == null) return NotFound("** Churras não encontrado :(  **");

            _service.AlterarChurras(obj);
            return Ok(obj);
        }

        // DELETE api/churras/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.ConsultarChurras(id) == null) return NotFound("** Churras não encontrado :(  **");

            _service.ExcluirChurras(id);
            return Ok();
        }

        // GET api/churras/5/listarPartricipantes
        [HttpGet, Route("{id}/listarParticipantes")]
        public IEnumerable<ParticipanteChurrasDto> ListarParticipantes(int id)
        {
            var part = _service.ListarParticipantes(id);
            return part;
        }

        // GET api/churras/5/listarPovoDeFora
        [HttpGet, Route("{id}/listarPovoDeFora")]
        public IEnumerable<ParticipanteChurrasDto> ListarPovoDeFora(int id)
        {
            var part = _service.ListarPovoDeFora(id);
            return part;
        }

        // POST api/incluirParticipante
        [HttpPost, Route("incluirParticipante")]
        public IActionResult Post([FromBody] ParticipanteChurras obj)
        {
            if (!_service.UsuarioExiste(obj.ParticipanteId)) return Ok("** Usuário não encontrado :( **");
            if (_service.ConsultarChurras(obj.ChurrasId) == null) return NotFound("** Churras não encontrado :(  **");
            if (_service.ConsultarParticipante(obj) != null) return Ok("** Participante já está no Churras **");

            _service.IncluirParticipante(obj);
            return Ok(obj);
        }

        // DELETE api/excluirParticipante
        [HttpDelete, Route("excluirParticipante")]
        public IActionResult ExcluirParticipante(ParticipanteChurras obj)
        {
            if (_service.ConsultarChurras(obj.ChurrasId) == null) return NotFound("** Churras não encontrado :(  **");

            var consulta = _service.ConsultarParticipante(obj);
            if ( consulta == null) return NotFound("** Participante não encontrado :( **");

            _service.ExcluirParticipante(consulta.Id);
            return Ok();
        }

    }
}
