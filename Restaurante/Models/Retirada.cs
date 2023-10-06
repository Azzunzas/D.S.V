namespace Restaurante.Models
{
    public class Retirada
    {
        public int Id { get; set; }
        public string? NomeCliente { get; set; }
        public int NumPedido { get; set; }
        public string? Status { get; set; }
        public Retirada(int id, string nome, int pedido, string status)
        {
            Id = Id;
            NomeCliente = nome;
            NumPedido = pedido;
            Status = "Preparando";
        }

        public Retirada() { }
    }
}