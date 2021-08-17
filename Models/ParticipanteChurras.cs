using LiteDB;
using System.Collections.Generic;

namespace Trinca.Churras.WebApp.Models
{
    public class ParticipanteChurras
    {
        private static int id_Counter = 0;
        public ParticipanteChurras()
        {
            this.Id = System.Threading.Interlocked.Increment(ref id_Counter);
        }
        public int Id { get; set; }
        public int ChurrasId { get; set; }
        public int ParticipanteId { get; set; }
        //public IList<Leilao> Leiloes { get; set; }
    }

}