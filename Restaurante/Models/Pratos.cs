namespace Restaurante.Models
{
    public class Pratos
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public float Preco { get; set; }

        public Pratos(int id, string? nome, float preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
        public Pratos() { }
    }
    
}
