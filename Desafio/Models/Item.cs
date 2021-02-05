using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(10)")]
        [Required]
        public string Codigo { get; set; }
        [Required]
        public double Quantidade { get; set; }
        [Required]
        public double ValorUnitario { get; set; }
        public double Desconto { get; set; }
        [Required]
        public double ValorTotal { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set; } 
        public Item(int id, string codigo, double quantidade, double valorUnitario, double desconto, double valorTotal)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Quantidade = quantidade;
            this.ValorUnitario = valorUnitario;
            this.Desconto = desconto;
            this.ValorTotal = valorTotal;
        }
    }
}