using System.Runtime.Serialization;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Numero { get; set; }
        public DateTime Data { get; set; }
        [Column(TypeName = "varchar(70)")]
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Situacao { get; set; }
        public Item Itens { get; set; }
        public Pedido(int id, int numero, DateTime data, string descricao, string situacao)
        {
            this.Id = id;
            this.Numero = numero;
            this.Data = data;
            this.Descricao = descricao;
            this.Situacao = situacao;
        }
    }
}