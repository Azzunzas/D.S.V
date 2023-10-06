namespace Restaurante.Models
{
    public class Veiculos
    {
        public int Id { get; set; }
        public string? Placa { get; set; }
        public string? Descricao {  get; set; }//modelo
        public Veiculos(int id,string placa, string descricao) //construtor por parametros de inicializacao 
        {
            Id = id;
            Placa = placa;
            Descricao = descricao;
        }
        public Veiculos() { } //construtor padrao (vazio)
    }
}