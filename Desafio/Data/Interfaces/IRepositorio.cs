using System.Threading.Tasks;

namespace Desafio.Data.Interfaces
{
    public interface IRepositorio
    {
        void Adicionar<A> (A entidade) where A : class;
        void Atualizar<A> (A entidade) where A : class;
        void Excluir<A> (A entidade) where A : class;

        Task<bool> EfetuouAlteracoesAssincronas();
    }
}