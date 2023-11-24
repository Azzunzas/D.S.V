using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    public class Retirada
    {
        [Key]
        public int Id { get; set; }
        public string? NomeCliente { get; set; }
        public int NumPedido { get; set; }
        public string? Status { get; set; }
        public Retirada(int id, string nome, int pedido, string status)
        {
            Id = id;
            NomeCliente = nome;
            NumPedido = pedido;
            Status = status;
        }

        public Retirada() { }
    }
}