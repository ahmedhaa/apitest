using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Personne
    {
     
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public DateTime Date_naissance { get; set; }
    }
}
