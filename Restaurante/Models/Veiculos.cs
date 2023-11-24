using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        public string? Placa { get; set; }
        public string? Descricao {  get; set; }//modelo
        public Veiculo(int id,string placa, string descricao) //construtor por parametros de inicializacao 
        {
            Id = id;
            Placa = placa;
            Descricao = descricao;
        }
        public Veiculo() { } //construtor padrao (vazio)
    }
}