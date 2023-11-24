using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    public class Mesa
    {
        [Key]
        public int Id { get; set; }
        public int Acentos { get; set; }
        public string? Status { get; set; }

        public Mesa() { }
        public Mesa(int id, int acentos)
        {
            Id = id;
            Acentos = acentos;
            Status = "livre";
        }
    }
}