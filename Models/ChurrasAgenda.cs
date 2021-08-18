using System;
using System.Collections.Generic;
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
        
        [Required(ErrorMessage = "Descrição é obrigatória")] 
        [Display(Name = "Descrição", Prompt = "Digite a Descrição do Churras")]
        public string Descricao { get; set; }

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        [Required(ErrorMessage = "Data é obrigatória")]
        [Display(Name = "Data")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Valor Sugerido 1 é obrigatório")]
        [Display(Name = "Valor Sugerido 1")]
        [DataType(DataType.Currency, ErrorMessage = "Valor Sugerido 1")]
        public decimal ValorSugerido1 { get; set; }

        [Display(Name = "Valor Sugerido 2")]
        [DataType(DataType.Currency, ErrorMessage = "Valor Sugerido 2")]
        public decimal? ValorSugerido2 { get; set; }

        public IList<ParticipanteChurrasDto> ParticipanteChurras { get; set; }

        //public int IdParticipante { get; set; }
        //public Categoria Categoria { get; set; }
        //public SituacaoChurras Situacao { get; set; }
        //public string PosterUrl => $"/images/poster-{Id}.jpg";
    }
}