using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trinca.Churras.WebApp.Models
{
    public class ChurrasAgendaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorSugerido1 { get; set; }
        public decimal? ValorSugerido2 { get; set; }
        public decimal TotalArrecadado { get; set; }
        public IList<ParticipanteChurrasDto> ParticipantesChurras { get; set; }
    }
}