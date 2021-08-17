using System;
using Trinca.Churras.WebApp.Models;

namespace Trinca.Churras.WebApp.Seeding
{
    public class DataRandomGenerator
    {
        Random random;
        Participante[] participantes = new Participante[10]
        {
            new Participante("Alice") ,
            new Participante("Beto"),
            new Participante("Diego B"),
            new Participante("Diego P"),
            new Participante("Fernando"),
            new Participante("Gabriel"),
            new Participante("Leonardo"),
            new Participante("Marcus J"),
            new Participante("Michele"),
            new Participante("Paulo")
        };

        public DataRandomGenerator(Random random)
        {
            this.random = random;
        }

        public Participante QualquerParticipante()
        {
            var indiceAleatorio = random.Next(0,10);
            return participantes[indiceAleatorio];
        }

        private DateTime DataAleatoria()
        {
            int diasAleatorios = random.Next(1,100);
            return DateTime.Now.AddDays(-diasAleatorios);
        }

        public ChurrasAgenda NovoChurras
        {
            get
            {
                var churras = new ChurrasAgenda();

                churras.Data = this.DataAleatoria();
                churras.Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut consequat semper viverra nam libero justo laoreet. Ut placerat orci nulla pellentesque dignissim enim sit amet. Cras semper auctor neque vitae. Eu lobortis elementum nibh tellus molestie nunc non blandit massa. Penatibus et magnis dis parturient montes nascetur ridiculus. Bibendum enim facilisis gravida neque convallis. At risus viverra adipiscing at in tellus integer feugiat scelerisque. Turpis egestas pretium aenean pharetra magna ac. Suspendisse ultrices gravida dictum fusce ut. Mauris vitae ultricies leo integer. Senectus et netus et malesuada fames ac turpis egestas. Libero volutpat sed cras ornare. Tristique senectus et netus et malesuada fames ac.";
                churras.Observacoes = "Observações";
                churras.ValorSugerido1 = 10;
                churras.ValorSugerido2 = 15;

                return churras;
            }
        }

    }
}