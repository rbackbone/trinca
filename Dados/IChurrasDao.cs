using System.Collections.Generic;
using Trinca.Churras.WebApp.Models;

namespace Trinca.Churras.WebApp.Dados
{
    public interface IChurrasDao : IQuery<ChurrasAgenda>
    {
        void Alterar(ChurrasAgenda obj);
        void Excluir(int id);
        void ExcluirParticipante(int id);
        void Incluir(ChurrasAgenda obj);
        void IncluirParticipante(ParticipanteChurras obj);
        IEnumerable<ParticipanteChurrasDto> ListarParticipantes(int id);
        IEnumerable<ParticipanteChurras> ListarPovoDeFora(int id);
    }
}