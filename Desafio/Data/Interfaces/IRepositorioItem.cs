using System.Threading.Tasks;
using Desafio.Models;

namespace Desafio.Data.Interfaces
{
    public interface IRepositorioItem
    {
        Task<Item[]> ObterTodos();
        Task<Item> ObterPeloId(int itemId); 
        
    }
}