using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Context;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
    public class ProdutoController : Controller
{
        private readonly EcommerceContext _logger;

        public ProdutoController(EcommerceContext logger)
        {
            _logger = logger;
        }
    
        [HttpPost("CadastrarProduto")]
        public IActionResult CadastrarProduto(String Nome)
        {
            Produto produto = new Produto(Nome);

            _logger.Produtos.Add(produto);
            _logger.SaveChanges();
            return Ok(produto);
        }

        [HttpGet("BuscarProduto{Id}")]
        public IActionResult BuscarProduto(int Id){
            var produto = _logger.Produtos.Find(Id);
            if (produto == null){
                return NotFound("Produto não Encontrado");
            }
            return Ok(produto);
        }

        [HttpGet("ListarTodosOsProdutos")]
        public IActionResult ListarTodosOsProdutos(){
            return Ok(_logger.Produtos.ToList());
        }

        [HttpPut("AtualizarProduto")]
        public IActionResult Produto(int Id, string Nome){
            var produto = _logger.Produtos.Find(Id);
            if (produto == null){
                return NotFound("Produto não Encontrado");
            }
            produto.Nome = Nome;
            _logger.Produtos.Update(produto);
            _logger.SaveChanges();
            return Ok(produto);
        }

        [HttpDelete("ExcluirProduto{Id}")]
        public IActionResult ExcluirProduto(int Id){
            var produto = _logger.Produtos.Find(Id);
            if (produto == null){
                return NotFound("Produto não Encontrado");
            }

            _logger.Produtos.Remove(produto);
            _logger.SaveChanges();
            return NoContent();
        }
    }
}