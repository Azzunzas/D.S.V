namespace Restaurante.Models
{
    public class Funcionarios
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Login {  get; set; }
        public string? Password { get; set; }
        public int DataContratacao { get; set; }
        public string? Funcao {  get; set; }

        public Funcionarios(int id, string nome, int login, string password,string funcao) 
        {
            Id = id;
            Nome = nome;
            Login = login;
            Password = password;
            Funcao = funcao;
        }
        public Funcionarios() { }
    }

}
