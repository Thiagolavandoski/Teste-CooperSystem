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
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcasController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [Route("All")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _marcaService.GetAll();
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
                var result = _marcaService.GetByFilter(nome, origem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Insert")]
        [HttpPost]
        public IActionResult Post(Marca marca)
        {
            try
            {
                _marcaService.Insert(marca);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Edit")]
        [HttpPut]
        public IActionResult Edit(Marca marca)
        {
            try
            {
                _marcaService.Edit(marca);
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
                _marcaService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
