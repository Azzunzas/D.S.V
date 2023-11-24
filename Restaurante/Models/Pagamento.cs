using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }
        public List<Dinheiro> DinheiroPagamentos { get; set; }
        public List<Cartao> CartaoPagamentos { get; set; }

        public Pagamento(int id)
        {
            Id = id;
            DinheiroPagamentos = new List<Dinheiro>();
            CartaoPagamentos = new List<Cartao>();
        }

        public class Dinheiro
        {

            public string Notas { get; set; }

            public Dinheiro(string notas)
            {
                Notas = notas;
            }
        }

        public class Cartao
        {
            public string NomeDoDono { get; set; }
            public long NumCartao { get; set; }
            public string Bandeira { get; set; }

            public Cartao(string nomeDoDono, long numCartao, string bandeira)
            {
                NomeDoDono = nomeDoDono;
                NumCartao = numCartao;
                Bandeira = bandeira;
            }
        }
    }
}