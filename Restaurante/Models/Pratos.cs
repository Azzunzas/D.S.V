using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    public class Prato
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public float Preco { get; set; }

        public Prato(int id, string? nome, float preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
        public Prato() { }
    }
}