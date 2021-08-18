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
            return _context.GetCollection<ChurrasAgenda>("churrasAgenda")
                .Find(x => x.Id == id).FirstOrDefault();
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
            _context.GetCollection<ChurrasAgenda>("churrasAgenda")
                .Delete(id);
        }

        #endregion

        #region Participantes

        public void IncluirParticipante (ParticipanteChurras obj)
        {
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
                    ParticipanteId = novo.Id, 
                    Nome = novo.Nome, 
                    ValorContribuicao= p.ValorContribuicao 
                });

            });

            return ret;
        }

        public IEnumerable<ParticipanteChurras> ListarPovoDeFora(int id)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
