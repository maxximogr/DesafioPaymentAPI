using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Context;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly EcommerceContext _logger;

        public VendedorController(EcommerceContext logger)
        {
            _logger = logger;
        }

        [HttpPost("CadastrarVendedor")]
        public IActionResult CadastrarVendedor(string Nome, string Cpf, string Email, string Telefone)
        {
            try
            {
                Vendedor vendedorACadastrar = new Vendedor(Nome, Cpf, Email, Telefone);
                _logger.Vendedores.Add(vendedorACadastrar);
                _logger.SaveChanges();
                return Ok(vendedorACadastrar);
            }
            catch (ArgumentException exception)
            { 
                return BadRequest(exception.Message); 
            }

        }

        //Retirar dos Comentário Caso deseja ativar a função de Json
        // [HttpPost("CadastrarVendedorPorJson")]
        // public  IActionResult CadastrarVendedor(Vendedor vendedor){
        //     _logger.Vendedores.Add(vendedor);
        //     _logger.SaveChanges();
        //     return Ok(vendedor);
        // }

        [HttpGet("BuscarPor{Id}")]
        public IActionResult BuscarVendedor(int Id){
            var vendedor = _logger.Vendedores.Find(Id);
            if (vendedor == null){
                return NotFound();
            }

            return Ok(vendedor);
        }

        [HttpGet("ListarVendedores")]
        public IActionResult BuscarTodosVendedores(){
            var vendedores = _logger.Vendedores.ToList();
            return Ok(vendedores);
        }

        [HttpDelete("ExcluirVendedor{Id}")]
        public IActionResult ExlcuirVendedor(int Id){
            var vendedor = _logger.Vendedores.Find(Id);
            if (vendedor == null){
                return NotFound();
            }

            _logger.Vendedores.Remove(vendedor);
            _logger.SaveChanges();
            return NoContent();
        }
    }
}    
