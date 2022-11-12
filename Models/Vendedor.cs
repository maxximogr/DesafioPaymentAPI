using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataValidator.Cpf;

namespace PaymentAPI.Models
{
    public class Vendedor
    {
        public Vendedor(){

        }
        public Vendedor(string nome, string cpf, string email, string telefone ){
            ICheckCpf verificadorCpf = new CheckCpf();
            Cpf verificador = verificadorCpf.ExtractAndCheckCpf(cpf);
            
            if (verificador.IsValid == true){
                this.Nome = nome;
                this.Cpf = verificador.Formatted;
                this.Email = email;
                this.Telefone = telefone;
            }
            else if(verificador.IsValid == false)
            {
                throw new ArgumentException("CPF incorreto");
            }
        }


        [Key]
        public int IdVendedor { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
