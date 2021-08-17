using LiteDB;
using System.Collections.Generic;

namespace Trinca.Churras.WebApp.Models
{
    public class Participante
    {
        private static int id_Counter = 0;
        public Participante(string nome)
        {
            this.Id = System.Threading.Interlocked.Increment(ref id_Counter);
            this.Nome = nome;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        //public IList<Leilao> Leiloes { get; set; }
    }

}