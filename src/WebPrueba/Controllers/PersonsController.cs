using Microsoft.AspNetCore.Mvc;
using WebPrueba.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            return View(_contexto.Persons.ToList());
        }

        public IActionResult Delete(int id)
        {
            var person = _contexto.Persons.ToList(); 
            _contexto.Remove(person.Select(x=>x.PersonId == id));
            _contexto.SaveChanges();
            return Json(new {Status = "OK"});
            
        }

        public IActionResult Error()
        {
            return View();
        }
         
        public IActionResult Create()
        {
            return View();            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _contexto.Persons.Add(person);
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }
    }
}