using LiteDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace Trinca.Churras.WebApp.Dados.LiteDB
{
    public class LiteDbContext : ILiteDbContext
    {
        public LiteDatabase Database { get; }

        public LiteDbContext(IConfiguration configuration)
        {
            string connectionString;
            try
            {
                connectionString = configuration.GetSection("LiteDbOptions").GetChildren().FirstOrDefault()?.Value;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("No connection string (LiteDbOptions) defined in appsettings.json");
            }

            Database = new LiteDatabase(connectionString);
        }
    }
}