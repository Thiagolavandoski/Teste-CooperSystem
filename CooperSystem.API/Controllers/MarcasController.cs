using CooperSystem.API.Interfaces.Services;
using CooperSystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CooperSystem.API.Controllers
{   
    [ApiController]
    [CultureRoute("api/[controller]")]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcasController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }
        
        [Route("Inserir")]
        [HttpPost]
        public IActionResult Inserir(Marca marca)
        {
            try
            {
                _marcaService.Inserir(marca);
                return Ok(new { Message = "Marca adicionada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Erro ao adicionar a marca.", Details = ex.Message });
            }
        }

        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar(Marca marca)
        {
            try
            {
                if (marca.Id == 0)
                    return BadRequest(new { Error = "id da marca obrigatório" });

                if (marca.Origem == null)
                    return BadRequest(new { Error = "Origem da marca obrigatório" });

                _marcaService.Atualizar(marca);
                return Ok(new { Message = "Marca editada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Erro ao editar a marca.", Details = ex.Message });
            }
        }

        [Route("listarTodasAsMarcas")]
        [HttpGet]
        public IActionResult listarTodasAsMarcas()
        {
            try
            {
                var result = _marcaService.listarTodasAsMarcas();
                return Ok(new { Message = "Lista de marcas obtida com sucesso!", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Erro ao obter a lista de marcas.", Details = ex.Message });
            }
        }

        [Route("ObterPorNomeEOrigem")]
        [HttpGet]
        public IActionResult ObterPorNomeEOrigem(string nome, string origem)
        {
            try
            {
                if (nome == null)
                    return BadRequest(new { Error = "Nome da marca obrigatório" });

                if (origem == null)
                    return BadRequest(new { Error = "Origem da marca obrigatório" });

                var result = _marcaService.ObterPorNomeEOrigem(nome, origem);
                return Ok(new { Message = "Marcas filtradas com sucesso!", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Erro ao filtrar as marcas.", Details = ex.Message });
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest(new { Error = "id da marca obrigatório" });

                _marcaService.Delete(id);
                return Ok(new { Message = "Marca deletada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Erro ao deletar a marca.", Details = ex.Message });
            }
        }

    }
}
