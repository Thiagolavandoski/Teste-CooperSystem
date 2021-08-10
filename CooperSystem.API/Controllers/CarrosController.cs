using CooperSystem.API.Interfaces.Services;
using CooperSystem.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly ICarroService _carroService;

        public CarrosController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [Route("All")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _carroService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Filter/{nome}/{origem}")]
        [HttpGet]
        public IActionResult GetByFilter(string nome, string origem)
        {
            try
            {
                var result = _carroService.GetByFilter(nome, origem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Insert")]
        [HttpPost]
        public IActionResult Post(Carro carro)
        {
            try
            {
                _carroService.Insert(carro);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Edit")]
        [HttpPut]
        public IActionResult Edit(Carro carro)
        {
            try
            {
                _carroService.Edit(carro);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _carroService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
