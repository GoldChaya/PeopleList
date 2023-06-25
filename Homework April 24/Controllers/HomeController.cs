
using Homework_April_24.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework_April_24.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=PeopleCars;Integrated Security=true;";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetPeople()
        {
            var repo = new PeopleRepo(_connectionString);
            List<Person>people= repo.GetAll();
            return Json(people);
        }
        [HttpPost]
        public void AddPerson(Person p)
        {
            var repo = new PeopleRepo(_connectionString);
            repo.Add(p);
        }
        [HttpPost]
        public void Delete(int id)
        {
            var repo = new PeopleRepo(_connectionString);
            repo.Delete(id);
        }

        public IActionResult GetById(int id)
        {
            var repo = new PeopleRepo(_connectionString);
            return Json(repo.GetById(id));
        }

        [HttpPost]
        public void Update(Person person)
        {
            var repo = new PeopleRepo(_connectionString);
            repo.Update(person);
        }
    }
}