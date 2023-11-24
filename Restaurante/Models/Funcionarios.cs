using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Login {  get; set; }
        public string? Password { get; set; }
        public int DataContratacao { get; set; }
        public string? Funcao {  get; set; }

        public Funcionario(int id, string nome, int login, string password,string funcao) 
        {
            Id = id;
            Nome = nome;
            Login = login;
            Password = password;
            Funcao = funcao;
        }
        public Funcionario() { }
    }
}