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
            _ctx=ctx;
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
        public IActionResult AddPerson(Person person  ) 
        
        {

            if(!ModelState.IsValid) 
            {
                return View();
                Console.WriteLine("problem");
            
            }
            try
            {
                _ctx.Add(person);
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
            Console.WriteLine(persons);
            return View(persons);
        }
    }
}
