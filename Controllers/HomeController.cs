using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_SignToSeminar_WebApplication.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome To The Sign To Seminar API!";
        }
    }
}
