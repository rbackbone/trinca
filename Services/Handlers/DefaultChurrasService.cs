using System;
using System.Collections.Generic;
using System.Linq;
using Trinca.Churras.WebApp.Dados;
using Trinca.Churras.WebApp.Models;
using Trinca.Churras.WebApp.Services;

namespace Trinca.Churras.WebApp.Services.Handlers
{
    public class DefaultChurrasService : IChurrasService
    {
        IChurrasDao _churrasDao;

        public DefaultChurrasService(IChurrasDao churrasDao)
        {
            _churrasDao = churrasDao;
        }

        public IEnumerable<ChurrasAgenda> ListarAgendaChurras()
        {
            return _churrasDao.ListarTodos();
        }

        public IEnumerable<ParticipanteChurrasDto> ListarParticipantes(int idChurras)
        {
            return _churrasDao.ListarParticipantes(idChurras);
        }

        public IEnumerable<ParticipanteChurrasDto> ListarPovoDeFora(int idChurras)
        {
            return _churrasDao.ListarPovoDeFora(idChurras);
        }

        public ChurrasAgendaDto ConsultarChurras(int idChurras)
        {
            return _churrasDao.ConsultaDetalhePorId(idChurras);
        }

        public void CadastrarChurras(ChurrasAgenda churras)
        {
            _churrasDao.Incluir(churras);
        }

        public void AlterarChurras(ChurrasAgenda churras)
        {
            _churrasDao.Alterar(churras);
        }

        public void ExcluirChurras(int id)
        {
            _churrasDao.Excluir(id);
        }

        public void IncluirParticipante(ParticipanteChurras participante)
        {
            _churrasDao.IncluirParticipante(participante);
        }

        public void ExcluirParticipante(int id)
        {
            _churrasDao.ExcluirParticipante(id);
        }

        public ParticipanteChurrasDto ConsultarParticipante(ParticipanteChurras participante)
        {
            var res = _churrasDao.ListarParticipantes(participante.ChurrasId)
                      .Where(x => x.ParticipanteId == participante.ParticipanteId)
                      .FirstOrDefault();
            return res;
        }

        public bool UsuarioExiste(int id)
        {
            return _churrasDao.UsuarioExiste(id);
        }
    }
}
