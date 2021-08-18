using System.Collections.Generic;
using Trinca.Churras.WebApp.Models;

namespace Trinca.Churras.WebApp.Dados
{
    public interface IQuery<T>
    {
        IEnumerable<T> ListarTodos();
        T BuscarPorId(int id);
    }
}
