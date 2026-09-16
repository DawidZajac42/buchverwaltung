using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Buchverwaltung.Data;
using Buchverwaltung.Models;

namespace Buchverwaltung.Controllers;

public class BuecherController : Controller
{
    private readonly AppDbContext _context;

    public BuecherController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string suche)
    {
        var alleBuecher = await _context.Buecher.ToListAsync();

        if (!string.IsNullOrEmpty(suche))
        {
            var gefundeneBuecher = new List<Buch>();
            foreach (var buch in alleBuecher)
            {
                if (buch.Titel.Contains(suche) || buch.Autor.Contains(suche))
                {
                    gefundeneBuecher.Add(buch);
                }
            }
            alleBuecher = gefundeneBuecher;
        }

        ViewData["Suche"] = suche;
        return View(alleBuecher);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buch = await _context.Buecher.FirstOrDefaultAsync(b => b.Id == id);
        if (buch == null)
        {
            return NotFound();
        }

        return View(buch);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Buch buch)
    {
        if (ModelState.IsValid)
        {
            _context.Buecher.Add(buch);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(buch);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buch = await _context.Buecher.FindAsync(id);
        if (buch == null)
        {
            return NotFound();
        }

        return View(buch);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Buch buch)
    {
        if (id != buch.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(buch);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(buch);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buch = await _context.Buecher.FirstOrDefaultAsync(b => b.Id == id);
        if (buch == null)
        {
            return NotFound();
        }

        return View(buch);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var buch = await _context.Buecher.FindAsync(id);
        if (buch != null)
        {
            _context.Buecher.Remove(buch);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}
