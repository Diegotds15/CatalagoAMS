using CatalagoAMS.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalagoAMS.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new DashboardViewModel
            {
                TotalMunicipios = _context.Municipios.Count(),
                TotalEscolas = _context.Escolas.Count(),
                
            };
            return View(viewModel);
        }
    }
}
