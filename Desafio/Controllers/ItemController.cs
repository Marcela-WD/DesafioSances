using System;
using System.Threading.Tasks;
using Desafio.Data.Interfaces;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        private readonly IRepositorioItem _repositorioItem;
        public ItemController(IRepositorio repositorio, IRepositorioItem repositorioItem)
        {
            this._repositorio = repositorio;
            this._repositorioItem = repositorioItem;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var itens = await _repositorioItem.ObterTodos();
                return Ok(itens);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao consultar item {ex.Message}");
            }
        }
        [HttpGet("id={itemid}")]
        public async Task<IActionResult> Get(int itemId)
        {
            try
            {
                var item = await _repositorioItem.ObterPeloId(itemId);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao consultar item pelo ID {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Item item)
        {
            try
            {
                _repositorio.Adicionar(item);
                if (await _repositorio.EfetuouAlteracoesAssincronas())
                {
                    return Ok (item);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao salvar {ex.Message}");
            }
            return BadRequest();
        }
        [HttpPut("id={itemId}")]
        public async Task<IActionResult> Put(int itemId, Item item)
        {
            try
            {
                var itemCadastrado = await _repositorioItem.ObterPeloId(itemId);
                if (itemCadastrado == null)
                {
                    return NotFound();
                }
                _repositorio.Atualizar(item);
                if (await _repositorio.EfetuouAlteracoesAssincronas())
                {
                    return Ok(item);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao tentar atualizar {ex.Message}");
            }
            return BadRequest();
        }
        [HttpDelete("id={itemId}")]
        public async Task<IActionResult> Delete(int itemId)
        {
            try
            {
                var itemCadastrado = await _repositorioItem.ObterPeloId(itemId);
                if (itemCadastrado == null)
                {
                    return NotFound();
                }
                _repositorio.Excluir(itemCadastrado);
                if (await _repositorio.EfetuouAlteracoesAssincronas())
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