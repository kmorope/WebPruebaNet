using Microsoft.AspNetCore.Mvc;
using WebPrueba.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebPrueba.Controllers
{
    public class PersonsController : Controller
    {
        private PersonContext _contexto;

        public PersonsController(PersonContext context)
        {
            _contexto = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Get()
        { 
            var result = "{\"data\":[";
            foreach (var item in _contexto.Persons.ToList())
            {
                result += "[";
                result += "\"" + item.Nombres + "\",";
                result += "\"" + item.Apellidos + "\",";
                result += "\"" + item.Cedula + "\",";
                result += "\"" + item.Email + "\",";
                result += "\"" + item.PersonId + "\"";
                result += "]";
                if (_contexto.Persons.ToList().IndexOf(item) != _contexto.Persons.ToList().Count - 1)
                {
                    result += ",";
                }
            }
            result += "]}";
            return Content(result);
        }
         
        public IActionResult Delete(int id)
        {
            var person = _contexto.Persons.AsNoTracking().SingleOrDefault(m => m.PersonId == id);
            _contexto.Persons.Remove(person);
            _contexto.SaveChangesAsync();
            return Json(new {Status = "OK"});
            
        }

        public IActionResult Error()
        {
            return View();
        }
         
        [HttpPost]
        public IActionResult CreatePerson()
        {
            return PartialView("Create");            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _contexto.Persons.Add(person);
                _contexto.SaveChanges();
                return Json(new { Status = "OK" });
            }

            return View(person);
        }

        [HttpPost] 
        public IActionResult Edit(int id)
        { 
            var person = _contexto.Persons.AsNoTracking().SingleOrDefault(m => m.PersonId == id); 
            
            return PartialView("Create",person);
        }
        
        public IActionResult Update(Person person) {

            var personToUpdate = _contexto.Persons.AsNoTracking().Single(s => s.PersonId == person.PersonId);
            personToUpdate = person;
            _contexto.Update(personToUpdate);
            _contexto.SaveChanges();

            return Json(new { Status = "OK" });
        }
    }
}