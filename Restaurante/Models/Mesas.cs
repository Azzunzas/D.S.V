namespace Restaurante.Models
{
    public class Mesas
    {
        public int Id { get; set; }
        public int Acentos { get; set; }
        public string? Status { get; set; }

        public Mesas() { }
        public Mesas(int id, int acentos)
        {
            Id = id;
            Acentos = acentos;
            Status = "livre";
        }
    }

}
