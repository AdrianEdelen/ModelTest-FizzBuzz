using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelTest.Models;

namespace ModelTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult FizzBuzz(FizzBuzzModel model)
        {

            return View(model);
        }
        [HttpPost]
        public IActionResult FizzBuzz(string userInput1, string userInput2)
        {
            var fizzBuzzModel = new FizzBuzzModel();
            fizzBuzzModel.FizzNum = Convert.ToInt32(userInput1);
            fizzBuzzModel.BuzzNum = Convert.ToInt32(userInput2);
            fizzBuzzModel.Output = "";
            for (int i = 1; i <= 100; i++)
            {
                if (i % fizzBuzzModel.FizzNum == 0 && i % fizzBuzzModel.BuzzNum == 0)
                {
                    fizzBuzzModel.Output += "FizzBuzz ";
                }

                else if (i % fizzBuzzModel.FizzNum == 0)
                {
                    fizzBuzzModel.Output += "Fizz ";
                }
                else if (i % fizzBuzzModel.BuzzNum == 0)
                {
                    fizzBuzzModel.Output += "Buzz ";
                }
                else
                {
                    fizzBuzzModel.Output += $" {i} ";
                }
            }
            return RedirectToAction("FizzBuzz", fizzBuzzModel);
        }

        //need to allow this action to accept an incoming model/viewmodel
        public IActionResult Result(FizzBuzzModel model)
        {
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
