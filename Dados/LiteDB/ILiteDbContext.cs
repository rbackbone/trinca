using LiteDB;

namespace Trinca.Churras.WebApp.Dados.LiteDB
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}
