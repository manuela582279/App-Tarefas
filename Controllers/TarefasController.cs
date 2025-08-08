using Microsoft.AspNetCore.Mvc;

namespace App_Tarefas.Controllers
{
    public class TarefasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
