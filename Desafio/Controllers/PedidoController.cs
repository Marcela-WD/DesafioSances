using System;
using System.Threading.Tasks;
using Desafio.Data.Interfaces;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        private readonly IRepositorioPedido _repositorioPedido;

        public PedidoController(IRepositorio repositorio, IRepositorioPedido repositorioPedido)
        {
            this._repositorio = repositorio;
            this._repositorioPedido = repositorioPedido;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pedidos = await _repositorioPedido.ObterTodos();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao consultar o Pedido {ex.Message}");
            }
        }
        [HttpGet("id={pedidoId}")]
        public async Task<IActionResult> Get(int pedidoId)
        {
            try
            {
                var pedido = await _repositorioPedido.ObterPeloId(pedidoId);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao consultar pelo ID {ex.Message}");                
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Pedido pedido)
        {
            try
            {
                _repositorio.Adicionar(pedido);
                if (await _repositorio.EfetuouAlteracoesAssincronas())
                {
                    return Ok(pedido);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao salvar o pedido {ex.Message}");                
            }
            return BadRequest();
        }
        [HttpPut("id={pedidoId}")]
        public async Task<IActionResult> Put(int pedidoId, Pedido pedido)
        {
            try
            {
                var pedidoCadastrado = await _repositorioPedido.ObterPeloId(pedidoId);
                if (pedidoCadastrado == null)
                {
                    return NotFound();
                }
                _repositorio.Atualizar(pedido);
                if (await _repositorio.EfetuouAlteracoesAssincronas())
                {
                    return Ok(pedido);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar pedido {ex.Message}");                
            }
            return BadRequest();
        }
        [HttpDelete("id={pedidoId}")]
        public async Task<IActionResult> Delete(int pedidoId)
        {
            try
            {
                var pedidoCadastrado = await _repositorioPedido.ObterPeloId(pedidoId);
                if(pedidoCadastrado == null)
                {
                    return NotFound();
                }
                _repositorio.Excluir(pedidoCadastrado);
                if(await _repositorio.EfetuouAlteracoesAssincronas())
                {
                    return Ok( new {message = "Removido!"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao excluir {ex.Message}");                
            }
            return BadRequest();
        }
    }
}