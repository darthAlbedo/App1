using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App1.Models;
using App1.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace App1.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        [Route("[action]")]
        public IActionResult Index()
        {
            return View("IndexWithForm"); //jeśli view ma inną nazwę niż akcja to wpisujemy
        }

        [HttpPost]
        [Route("")]
        [Route("[action]")]
        public IActionResult Index(Contact contact)
        {
            if(ModelState.IsValid) //Czy spałnione wymagania narzucone klasie modelu atrybutami?
            {
                Customer customer = new Customer()
                {
                    Id = 2,
                    CustomerName = "C.C."
                };
                HomeIndexViewModel vm = new HomeIndexViewModel()
                {
                    Contact = contact,
                    Customer = customer
                };
                return View(vm);
            }
            else
            {
                return View("IndexWithForm");
            }
        }
    }
}

/*
 Wersja 1:
 HomeController
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App1.Models;
using App1.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace App1.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        [Route("")]
        [Route("[action]/{id?}")]
        //[HttpGet] - filtrowanie action verb, jeśli jest nadany taki atrybut to uruchomi tą akcję tylko
        //jeśli przeglądarka w Request wysłała pasujący Http Action Verb
        //Pozwala to upewnić się że odpowiadamy właścią akcją na właściwy Request
        //Defaultowo przechodzi Reqest z każdym action verb
        public IActionResult Index(int id)//nazwa parametru musi być zgodna z nazwą w url
        {//z testów wynika, że jeśli wprowadzimy coś innego niż int to nic się złego nie stanie a id = 0
            Contact contact = new Contact()
            {
                Id = id,
                FirstName = "Karen",
                LastName = "Araragi"
            };
            Customer customer = new Customer()
            {
                Id = 2,
                CustomerName = "C.C."
            };
            HomeIndexViewModel vm = new HomeIndexViewModel()
            {
                Contact = contact,
                Customer = customer
            };
            return View(vm); //ma wiele przeciążeń np. przyjmuje object, View ustawia kodowanie na html
            //return Content("Shinobu") ustawia kodowanie na tekst 
        }

        [HttpPost] //przeciążenie metody Index - musi wymagać action verb HttpPost jeśli przyjmuje obiekt, na tej podstawie wiadomo którą akcję odpalić
        [Route("[action]")]
        public IActionResult Index(Contact contact)
        {
            Customer customer = new Customer()
            {
                Id = 2,
                CustomerName = "C.C."
            };
            HomeIndexViewModel vm = new HomeIndexViewModel()
            {
                Contact = contact,
                Customer = customer
            };
            return View(vm);
        }

        [Route("Download")]
        public IActionResult DownloadData()
        {
            return NotFound();
            //return File("DownloadData/testData.txt", "text/plain", "Data.txt"); //(virtualPath, typ danych, sugerowana nazwa pliku)
            //return PhysicalFile("C:\\Users\\Mat\\Desktop\\C#\\ASP_NET\\App\\src\\App1\\wwwroot\\DownloadData\\testData.txt", "text/plain"); //(Path, typ danych) nie wysyła nic do pobierania tylko wyświetla plik w wyszukiwarce np. tekst
        }

        [Route("LR")]
        public IActionResult LRedirect(string redirectUrl)
        {
            return LocalRedirect(redirectUrl);
        }   //jak wpisywać adres: (...)/Home/LR?redirectUrl=/Home/Index

        [Route("GR")]
        public IActionResult GRedirect(string redirectUrl)
        {
            return Redirect(redirectUrl);
        }   //jak wpisywać adres: (...)/Home/LR? redirectUrl = http://google.com

        [Route("RA")]
        public IActionResult ARedirect()
        {
            return RedirectToAction("Index","Home");
        }   //nic nie treba wpisywać
    }
}

     */

/*
  Wersja 2:
  HomeController
  IndexWithForm
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App1.Models;
using App1.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace App1.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("[action]")]
        public IActionResult IndexWithForm()
        {
            return View();
        }

        [Route("[action]")] //action verb w web form = get, przy model binding = post
        public IActionResult Index([FromQuery] Contact contact) //atrybut stanowi dodatkowe zabezpieczenie, jeśli zmienilibyśmy action verb w web form na post i odpalimy z tym to i tak nie przejdzie
        {
            Customer customer = new Customer()
            {
                Id = 2,
                CustomerName = "C.C."
            };
            HomeIndexViewModel vm = new HomeIndexViewModel()
            {
                Contact = contact,
                Customer = customer
            };
            return View(vm);
        }
    }
}

    */

