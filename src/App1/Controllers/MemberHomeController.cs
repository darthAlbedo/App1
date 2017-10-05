using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace App1.Controllers
{
    [Route("[controller]")] //dodawane przy podejściu Rout Attribute;
                            //brak atrybutów przy jednej akcji -> uruchomi tą akcje po wpisaniu /Members, w innym przypadku 404, chyba że określona defaultowa
    public class MemberHomeController : Controller
    {
        // GET: /<controller>/
        [Route("")] //defaultowa akcja
        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

