using CooperSystem.API.Interfaces.Services;
using CooperSystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CooperSystem.API.Controllers
{
    [ApiController]
    [CultureRoute("api/[controller]")]
    public class CarrosController : ControllerBase
    {
        private readonly ICarroService _carroService;

        public CarrosController(ICarroService carroService)
        {
            _carroService = carroService;
        }
        
        [Route("Inserir")]
        [HttpPost]
        public IActionResult Inserir(Carro carro)
        {
            try
            {
                _carroService.Inserir(carro);
                return Ok(new { Message = "Carro adicionado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Erro ao adicionar o carro.", Details = ex.Message });
            }
        }

        [Route("Atualizar")]
        [HttpPut]
        public IActionResult Atualizar(Carro carro)
        {
            try
            {
                if (carro.Id == 0)
                {
                    return BadRequest(new { Error = "id do carro obrigatório" });
                }
                _carroService.Atualizar(carro);
                return Ok(new { Message = "Carro editado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Erro ao editar o carro.", Details = ex.Message });
            }
        }

        [Route("AlterarStatusCarro")]
        [HttpPut]
        public IActionResult AlterarStatusCarro(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest(new { Error = "id do carro obrigatório" });
                }
                _carroService.AlterarStatusCarro(id);
                return Ok(new { Message = "Status alterado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Erro ao editar o carro.", Details = ex.Message });
            }
        }

        [Route("listarTodosOsCarros")]
        [HttpGet]
        public IActionResult listarTodosOsCarros()
        {
            try
            {
                var result = _carroService.listarTodosOsCarros();
                return Ok(new { Message = "Lista de carros obtida com sucesso!", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Erro ao obter a lista de carros.", Details = ex.Message });
            }
        }

        [Route("ObterPorNomeEOrigem")]
        [HttpGet]
        public IActionResult ObterPorNomeEOrigem(string nome, string origem)
        {
            try
            {
                if (nome == null)
                    return BadRequest(new { Error = "Nome do carro obrigatório" });

                if (origem == null)
                    return BadRequest(new { Error = "Origem do carro obrigatório" });

                var result = _carroService.ObterPorNomeEOrigem(nome, origem);
                return Ok(new { Message = "Carros filtrados com sucesso!", Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Erro ao filtrar os carros.", Details = ex.Message });
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _carroService.Delete(id);
                return Ok(new { Message = "Carro deletado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Erro ao deletar o carro.", Details = ex.Message });
            }
        }
    }
}
