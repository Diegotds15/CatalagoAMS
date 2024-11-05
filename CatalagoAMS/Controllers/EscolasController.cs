using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalagoAMS.Controllers
{
    public class EscolasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EscolasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var escolas = _context.Escolas.Include(e => e.Municipio).ToList();
            return View(escolas);
        }

        public IActionResult Create()
        {
            ViewBag.Municipios = new SelectList(_context.Municipios, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Endereco,Telefone,Email,MunicipioId")] Escola escola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Municipios = new SelectList(_context.Municipios, "Id", "Nome", escola.MunicipioId);
            return View(escola);
        }
    }

}
