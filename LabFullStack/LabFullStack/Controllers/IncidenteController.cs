using AppTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTask.Controllers;

public class IncidenteController : Controller
{
    private readonly DbTasksContext _context;

    public IncidenteController(DbTasksContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Incidentes.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var incidente = await _context.Incidentes.FirstOrDefaultAsync(m => m.Codigo == id);
        if (incidente == null) return NotFound();
        return View(incidente);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Codigo,DescricaoProblema,DataIncidente,Solucao,Resolvido")] Incidente incidente)
    {
        if (ModelState.IsValid)
        {
            _context.Add(incidente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(incidente);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var incidente = await _context.Incidentes.FindAsync(id);
        if (incidente == null) return NotFound();
        return View(incidente);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Codigo,DescricaoProblema,DataIncidente,Solucao,Resolvido")] Incidente incidente)
    {
        if (id != incidente.Codigo) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(incidente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Incidentes.Any(e => e.Codigo == incidente.Codigo)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(incidente);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var incidente = await _context.Incidentes.FirstOrDefaultAsync(m => m.Codigo == id);
        if (incidente == null) return NotFound();
        return View(incidente);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var incidente = await _context.Incidentes.FindAsync(id);
        if (incidente != null) _context.Incidentes.Remove(incidente);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
