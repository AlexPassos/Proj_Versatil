using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versatil.Domain.Entities
{
    [Table("funcionarios")]
    public class Funcionarios : Entity
    {
        [Key]
        public int? id { get; set; }

        public DateTime? data {get; set;}
         public bool situacao{get; set;}

        public string nome { get; set; }

        public string cargo {get; set;}

        public DateTime? nascimento {get; set;}

        public string rg {get; set;}

        public string cpf {get; set;}

        public string carteira {get; set;}

        public string pis {get; set;}

        public string titulo {get; set;}

        public string habilitacao {get; set;}

        public string reservista {get; set;}

        public string filiacao{get; set;}

        public DateTime? admissao {get; set;}

        public DateTime? demissao {get; set;}

        public Decimal? salario {get; set;}

        public string endereco {get; set;}

        public string numero {get; set;}

        public string complemento {get; set;}

        public string bairro {get; set;}

        public int? cidadeID {get; set;}

        public int ufID {get; set;}

        public string cep {get; set;}

        public string telefone {get; set;}

        public string celular {get; set;}

        public string email {get; set;}

        public string obs {get;set;}

        public int empresaID { get; set; }

        public string nivel{get; set;}

        public string login{get; set;}

        public string senha{get; set;}
         public bool acesso {get; set;}
        
        public virtual Cidades Cidade {get; set;}
        public virtual Uf Uf {get; set;}
        public virtual Empresas Empresa {get; set;}
    }
}