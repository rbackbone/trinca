using LiteDB;
using System.Collections.Generic;

namespace Trinca.Churras.WebApp.Models
{
    public class ParticipanteChurrasDto
    {
        public int Id { get; set; }
        public int ParticipanteId { get; set; }
        public string Nome { get; set; }
        public decimal ValorContribuicao { get; set; }
    }

}