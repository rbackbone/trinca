using LiteDB;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Id do Churras � Obrigat�rio")]
        public int ChurrasId { get; set; }

        [Required(ErrorMessage = "Id do Participante � Obrigat�rio")]
        public int ParticipanteId { get; set; }

        public decimal ValorContribuicao { get; set; }
        //public IList<Leilao> Leiloes { get; set; }
    }

}