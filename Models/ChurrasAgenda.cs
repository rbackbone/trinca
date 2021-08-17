using System;
using System.ComponentModel.DataAnnotations;

namespace Trinca.Churras.WebApp.Models
{
    public class ChurrasAgenda
    {
        private static int id_Counter = 0;

        public ChurrasAgenda()
        {
            this.Id = System.Threading.Interlocked.Increment(ref id_Counter);
        }

        public int Id { get; set; }
        
        [Required(ErrorMessage = "Descri��o � obrigat�rio")] 
        [Display(Name = "Descri��o", Prompt = "Digite a Descri��o do Churras")]
        public string Descricao { get; set; }

        [Display(Name = "Observa��es")]
        public string Observacoes { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inv�lida")]
        public DateTime Data { get; set; }

        [Display(Name = "Valor Sugerido 1")]
        [DataType(DataType.Currency, ErrorMessage = "Valor Sugerido 1")]
        public decimal ValorSugerido1 { get; set; }

        [Display(Name = "Valor Sugerido 2")]
        [DataType(DataType.Currency, ErrorMessage = "Valor Sugerido 2")]
        public decimal ValorSugerido2 { get; set; }


        public ParticipanteChurras ParticipanteChurras { get; set; }

        //public int IdParticipante { get; set; }
        //public Categoria Categoria { get; set; }
        //public SituacaoChurras Situacao { get; set; }
        //public string PosterUrl => $"/images/poster-{Id}.jpg";
    }
}