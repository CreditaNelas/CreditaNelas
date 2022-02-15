using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CreditaNelas.Models;

namespace CreditaNelas
{
    public class PostagensController : Controller
    {
        private readonly Context _context;

        public PostagensController(Context context)
        {
            _context = context;
        }

        // GET: Postagens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Postagem.ToListAsync());
        }

        // GET: Postagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagens = await _context.Postagem
                .FirstOrDefaultAsync(m => m.Id_Postagem == id);
            if (postagens == null)
            {
                return NotFound();
            }

            return View(postagens);
        }

        // GET: Postagens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Postagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Postagem,Titulo,UrlImagem,Nome,Descricao,Whatsapp,Id_Usuario")] Postagens postagens)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postagens);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postagens);
        }

        // GET: Postagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagens = await _context.Postagem.FindAsync(id);
            if (postagens == null)
            {
                return NotFound();
            }
            return View(postagens);
        }

        // POST: Postagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Postagem,Titulo,UrlImagem,Nome,Descricao,Whatsapp,Id_Usuario")] Postagens postagens)
        {
            if (id != postagens.Id_Postagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postagens);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostagensExists(postagens.Id_Postagem))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(postagens);
        }

        // GET: Postagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postagens = await _context.Postagem
                .FirstOrDefaultAsync(m => m.Id_Postagem == id);
            if (postagens == null)
            {
                return NotFound();
            }

            return View(postagens);
        }

        // POST: Postagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postagens = await _context.Postagem.FindAsync(id);
            _context.Postagem.Remove(postagens);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostagensExists(int id)
        {
            return _context.Postagem.Any(e => e.Id_Postagem == id);
        }
    }
}
