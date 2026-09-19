using AppTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTask.Controllers;

public class CentralDeCustoController : Controller
{
    private readonly DbTasksContext _context;

    public CentralDeCustoController(DbTasksContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.CentralDeCustos.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var central = await _context.CentralDeCustos.FirstOrDefaultAsync(m => m.Codigo == id);
        if (central == null) return NotFound();
        return View(central);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Codigo,NomeCentral,ValorMetaAnual")] CentralDeCusto central)
    {
        if (ModelState.IsValid)
        {
            _context.Add(central);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(central);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var central = await _context.CentralDeCustos.FindAsync(id);
        if (central == null) return NotFound();
        return View(central);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Codigo,NomeCentral,ValorMetaAnual")] CentralDeCusto central)
    {
        if (id != central.Codigo) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(central);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CentralDeCustos.Any(e => e.Codigo == central.Codigo)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(central);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var central = await _context.CentralDeCustos.FirstOrDefaultAsync(m => m.Codigo == id);
        if (central == null) return NotFound();
        return View(central);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var central = await _context.CentralDeCustos.FindAsync(id);
        if (central != null) _context.CentralDeCustos.Remove(central);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
