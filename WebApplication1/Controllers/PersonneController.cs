using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        private readonly PersonneDbContext _context;

        public PersonneController(PersonneDbContext context) => _context = context;



        [HttpPost]
        public IActionResult CreatePersonne([FromBody] Personne personne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            int age = CalculateAge(personne.Date_naissance);

            if (age >= 150)
            {
                return BadRequest("L'âge de la personne ne peut pas dépasser 150 ans.");
            }

            _context.Personnes.Add(personne);
            _context.SaveChanges();

            return Ok("Personne enregistrée avec succès !");
        }


        [HttpGet]
        public IActionResult GetPersonnes()
        {
            var personnes = _context.Personnes.ToList();

            // Calculer l'âge actuel pour chaque personne et trier par ordre alphabétique
            var personnesAvecAge = personnes.Select(p => new
            {
                Id = p.Id,
                Nom = p.Nom,
                Prenom = p.Prenom,
                Date_naissance = p.Date_naissance,
                Age = CalculateAge(p.Date_naissance)
            }).OrderBy(p => p.Nom).ThenBy(p => p.Prenom).ToList();

            return Ok(personnesAvecAge);
        }

        private int CalculateAge(DateTime date_naissance)
        {
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - date_naissance.Year;

            if (currentDate < date_naissance.AddYears(age))
            {
                age--;
            }

            return age;
        }

    }
}
