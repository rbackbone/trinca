using System;
using System.Linq;
using LiteDB;
using Trinca.Churras.WebApp.Models;

namespace Trinca.Churras.WebApp.Seeding
{
    public static class DatabaseGenerator
    {
        public static void Seed()
        {
            using (var ctx = new LiteDatabase("Dados/TrincaChurras.db"))
            {
                if (!ctx.CollectionExists("participantes"))
                {
                    var participantes = ctx.GetCollection<Participante>("participantes");
                    var churrasAgenda = ctx.GetCollection<ChurrasAgenda>("churrasAgenda");
                    var participanteChurras = ctx.GetCollection<ParticipanteChurras>("participanteChurras");

                    var generator = new DataRandomGenerator(new Random());

                    for (var i = 1; i <= 15; i++)
                    {
                        var novoChurras = generator.NovoChurras;
                        churrasAgenda.Insert(novoChurras);

                        for (var p = 0; p <= 5; p++)
                        {
                            var part = generator.QualquerParticipante();

                            var resP = participantes.Find(x => x.Nome == part.Nome).FirstOrDefault();
                            if (resP == null)
                            {
                                participantes.Insert(part);
                            }

                            var resPC = participanteChurras
                                       .Find(x => x.ParticipanteId == part.Id && x.ChurrasId == novoChurras.Id)
                                       .FirstOrDefault();

                            if (resPC == null)
                            {
                                participanteChurras.Insert(new ParticipanteChurras { 
                                    ChurrasId = novoChurras.Id, 
                                    ParticipanteId = part.Id 
                                });

                            }

                        }

                    }
                }
            }
        }
    }
}