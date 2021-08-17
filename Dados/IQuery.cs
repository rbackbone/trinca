using System.Collections.Generic;

namespace Trinca.Churras.WebApp.Dados
{
    public interface IQuery<T>
    {
        IEnumerable<T> ListarTodos();
        T BuscarPorId(int id);
    }
}
