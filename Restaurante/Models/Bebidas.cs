namespace Restaurante.Models
{
    public class Bebidas
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; } //aucolico nao alcolica, com gas sem gas.
        public float Preco { get; set; }

        public Bebidas(int id, string nome, float preco, string descricao) //construtor de bebidas por parametros
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            
        }
        public Bebidas() { } //construtor padrao de bebidas
    }
}
