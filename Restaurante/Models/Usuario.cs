namespace Restaurante.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? DtNascismento {  get; set; }
        public string? Email {  get; set; }
        public int Login {  get; set; }
        public string? Password {  get; set; }
        
        public Usuario(int id,string nome,string data_nascimento,string email,int login,string password ) 
        {
            Id = id;
            Nome = nome;
            DtNascismento = data_nascimento;
            Email = email;
            Login = login;
            Password = password;
        }
        public Usuario() { }
    }
}