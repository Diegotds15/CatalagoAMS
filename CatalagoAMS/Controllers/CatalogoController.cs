using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CatalogoController : Controller
{
    private readonly ApplicationDbContext _context;

    public CatalogoController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var municipios = await _context.Municipios
            .Include(m => m.Escolas)
            .OrderBy(m => m.Nome)
            .ToListAsync();

        return View(municipios);
    }

    public async Task<IActionResult> EscolaDetalhes(int id)
    {
        var escola = await _context.Escolas
            .Include(e => e.Municipio)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (escola == null)
            return NotFound();

        return View(escola);
    }
}

