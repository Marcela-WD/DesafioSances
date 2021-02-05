using System.Linq;
using System.Threading.Tasks;
using Desafio.Data.Interfaces;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Data.Services
{
    public class RepositorioItem : IRepositorioItem
    {
        private readonly Contexto _contexto;
        
        public RepositorioItem(Contexto contexto)
        {
            this._contexto = contexto;
        }
        public async Task<Item[]> ObterTodos()
        {
            IQueryable<Item> consulta = _contexto.Item;
            consulta = consulta.AsNoTracking().OrderBy(i => i.Id);
            return await consulta.ToArrayAsync();
        }
        public async Task<Item> ObterPeloId(int itemId)
        {
            IQueryable<Item> consulta = _contexto.Item;
            consulta = consulta.AsNoTracking()
                               .OrderBy(i => i.Codigo)
                               .Where(i => i.Id == itemId);
            return await consulta.FirstOrDefaultAsync();
        }
    }
}