using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebPrueba.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) 
            : base(options)
        {}

        public DbSet<Person> Persons { get; set; }

    }

    public class Person
    {
        
        public int PersonId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Ingrese un correo valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Direccion { get; set; }
    }
}