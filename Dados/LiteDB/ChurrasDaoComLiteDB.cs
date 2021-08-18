using System.Collections.Generic;
using System.Linq;
using LiteDB;
using Trinca.Churras.WebApp.Models;

namespace Trinca.Churras.WebApp.Dados.LiteDB
{
    public class ChurrasDaoComLiteDB : IChurrasDao
    {
        LiteDatabase _context;

        public ChurrasDaoComLiteDB(LiteDbContext context)
        {
            _context = context.Database;
        }

        #region ChurrasAgenda

        public ChurrasAgenda BuscarPorId(int id)
        {

            var res = _context.GetCollection<ChurrasAgenda>("churrasAgenda")
                .Include(l => l.ParticipanteChurras)
                .Find(x => x.Id == id)
                .FirstOrDefault();

            if (res == null) return null;
            
            res.ParticipanteChurras = ListarParticipantes(id).ToList();

            return res;
        }

        public ChurrasAgendaDto ConsultaDetalhePorId(int id)
        {

            var res = _context.GetCollection<ChurrasAgenda>("churrasAgenda")
                .Include(l => l.ParticipanteChurras)
                .Find(x => x.Id == id)
                .FirstOrDefault();

            if (res == null) return null;

            res.ParticipanteChurras = ListarParticipantes(id).ToList();

            // TODO: usar AutoMapper
            ChurrasAgendaDto retorno = new ChurrasAgendaDto
            {
                Data = res.Data,
                Descricao = res.Descricao,
                Id = res.Id,
                Observacoes = res.Observacoes,
                ValorSugerido1 = res.ValorSugerido1,
                ValorSugerido2 = res.ValorSugerido2,
                ParticipantesChurras = res.ParticipanteChurras,
                TotalArrecadado = res.ParticipanteChurras.Sum(x => x.ValorContribuicao)
            };

            return retorno;
        }

        public IEnumerable<ChurrasAgenda> ListarTodos()
        {     
            return _context
            .GetCollection<ChurrasAgenda>("churrasAgenda")
            .Include(l => l.ParticipanteChurras)
            .FindAll();


        }
        public void Incluir(ChurrasAgenda obj)
        {
            // TODO: melhorar auto-incremento

            var id = _context.GetCollection<ChurrasAgenda>("churrasAgenda").Max(x => x.Id) + 1;
            obj.Id = id;

            _context.GetCollection<ChurrasAgenda>("churrasAgenda")
                .Insert(obj);
        }

        public void Alterar(ChurrasAgenda obj)
        {
            _context.GetCollection<ChurrasAgenda>("churrasAgenda")
                .Update(obj);
        }

        public void Excluir(int id)
        {
            _context.GetCollection<ParticipanteChurras>("participanteChurras")
                    .Find(x => x.ChurrasId == id)
                    .ToList()
                    .ForEach(p => {

                        this.ExcluirParticipante(p.Id);
            });

            _context.GetCollection<ChurrasAgenda>("churrasAgenda")
                .Delete(id);
        }

        #endregion

        #region Participantes

        public void IncluirParticipante (ParticipanteChurras obj)
        {
            // TODO: melhorar auto-incremento

            var id = _context.GetCollection<ChurrasAgenda>("participanteChurras").Max(x => x.Id) + 1;
            obj.Id = id;

            _context.GetCollection<ParticipanteChurras>("participanteChurras")
                .Insert(obj);
        }
        public void ExcluirParticipante(int id)
        {
            _context.GetCollection<ParticipanteChurras>("participanteChurras")
                .Delete(id);
        }

        public IEnumerable<ParticipanteChurrasDto> ListarParticipantes(int id)
        {
            var res = _context
            .GetCollection<ParticipanteChurras>("participanteChurras")
            .Find(x => x.ChurrasId == id);

            var part = _context
            .GetCollection<Participante>("participantes");

            List<ParticipanteChurrasDto> ret = new List<ParticipanteChurrasDto>();

            res.ToList().ForEach(p =>
            {

                var novo = part.Find(x => x.Id == p.ParticipanteId)
                               .FirstOrDefault();

                ret.Add(new ParticipanteChurrasDto { 
                    Id = p.Id,
                    ParticipanteId = novo.Id, 
                    Nome = novo.Nome, 
                    ValorContribuicao = p.ValorContribuicao 
                });

            });

            return ret;
        }

        public IEnumerable<ParticipanteChurrasDto> ListarPovoDeFora(int id)
        {
            var part = ListarParticipantes(id).ToList();

            var todos = _context
            .GetCollection<Participante>("participantes")
            .FindAll()
            .Where(x => part.Select(c => c.ParticipanteId).Contains(x.Id) == false)
            .ToList();

            List<ParticipanteChurrasDto> ret = new List<ParticipanteChurrasDto>();

            todos.ForEach(p =>
            {
                ret.Add(new ParticipanteChurrasDto
                {
                    Id = p.Id,
                    Nome = p.Nome
                });

            });

            return ret;
        }

        #endregion

        #region Usuário
        public bool UsuarioExiste(int id)
        {
            var res = _context.GetCollection<Participante>("participantes")
                .Find(x => x.Id == id)
                .FirstOrDefault();

            return res != null;
        }

        #endregion
    }
}
