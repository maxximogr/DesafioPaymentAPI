using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models
{
    public class Produto
    {
        public Produto(string Nome)
        {
            this.Nome = Nome;
        }
        
        [Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
    }
}