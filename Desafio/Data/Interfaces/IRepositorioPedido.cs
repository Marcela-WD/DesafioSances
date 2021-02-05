using System.Threading.Tasks;
using Desafio.Models;

namespace Desafio.Data.Interfaces
{
    public interface IRepositorioPedido
    {
        Task<Pedido[]> ObterTodos();
        Task<Pedido> ObterPeloId(int pedidoId);
    }
}