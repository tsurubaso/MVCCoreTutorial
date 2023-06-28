using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVCCoreTutorial.Models.Domain;

namespace MVCCoreTutorial.Controllers
{
    public class PersonController1 : Controller
    {
        private readonly DatabaseContext _ctx;
        public PersonController1(DatabaseContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()

        {
            ViewBag.greetings = "hello";
            ViewData["greetings2"] = "hello2";
            TempData["greetings3"] = "hello3";
            return View();
        }

        public IActionResult AddPerson()

        {

            return View();

        }
        [HttpPost]
        public IActionResult AddPerson(Person person)

        {

            if (!ModelState.IsValid)
            {
                return View();
                Console.WriteLine("problem");

            }
            try
            {
                _ctx.Persons.Add(person); //ici j'ajoute: .Persons.
                _ctx.SaveChanges();

                TempData["msg"] = "Added succesffully";
                return RedirectToAction("AddPerson");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not Add";
                return View();
            }


        }




        public IActionResult DisplayPersons()
        {
            var persons = _ctx.Persons.ToList();

            return View(persons);
        }
        [HttpGet]
        public IActionResult EditPerson(int id)
        {
            var person = _ctx.Persons.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            try
            {
                _ctx.Persons.Update(person);
                _ctx.SaveChanges();
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not update";
                return View(person);
            }
        }




        public IActionResult DeletePerson(int id)
        {
            try
            {
                var person = _ctx.Persons.Find(id);
                if (person != null)
                {
                    _ctx.Persons.Remove(person);
                    _ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("DisplayPersons");
        }
    }
}
