using Microsoft.AspNetCore.Mvc;
using MVCCoreTutorial.Models.Domain;

namespace MVCCoreTutorial.Controllers
{
    public class PersonController1 : Controller
    {
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
            
            }
            TempData["msg"] = "Added";
            return View();
        }
    }
}
