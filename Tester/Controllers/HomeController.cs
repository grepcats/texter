using Microsoft.AspNetCore.Mvc;
using Tester.Models;

namespace Tester.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMessages()
        {
            var allMessages = Message.GetMessages();
            return View(allMessages);
        }
    }
}