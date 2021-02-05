using System.Linq;
using System.Threading.Tasks;
using Desafio.Data.Interfaces;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Data.Services
{
    public class RepositorioPedido : IRepositorioPedido
    {
        private readonly Contexto _contexto;
        public RepositorioPedido(Contexto contexto)
        {
            this._contexto = contexto;
        }
        public async Task<Pedido[]> ObterTodos()
        {
            IQueryable<Pedido> consulta = _contexto.Pedido;
            consulta = consulta.AsNoTracking().OrderBy(i => i.Numero);
            return await consulta.ToArrayAsync();
        }
        public async Task<Pedido> ObterPeloId(int pedidoId)
        {
            IQueryable<Pedido> consulta = _contexto.Pedido;
            consulta = consulta.AsNoTracking()
                               .OrderBy(i => i.Numero)
                               .Where(i => i.Id == pedidoId);
            return await consulta.FirstOrDefaultAsync();
        }
    }
}