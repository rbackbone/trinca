﻿using System.Collections.Generic;
using Trinca.Churras.WebApp.Models;

namespace Trinca.Churras.WebApp.Services
{
    public interface IChurrasService
    {

        IEnumerable<ChurrasAgenda> ListarAgendaChurras(); // TODO: filtros
        IEnumerable<ParticipanteChurrasDto> ListarParticipantes(int id); // TODO: filtros
        IEnumerable<Participante> ListarPovoDeFora(int id); // TODO: filtros
        ChurrasAgenda ConsultarChurras(int id);
        void CadastrarChurras(ChurrasAgenda churras);
        void AlterarChurras(ChurrasAgenda churras);
        void ExcluirChurras(int id);
        void IncluirParticipante(ParticipanteChurras participante);
        void ExcluirParticipante(int id);
        ParticipanteChurrasDto ConsultarParticipante(ParticipanteChurras participante);
    }
}
