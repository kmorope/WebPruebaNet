using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
    }
}