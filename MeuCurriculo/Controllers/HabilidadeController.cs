using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeuCurriculo.Data;
using MeuCurriculo.Models;

namespace MeuCurriculo.Controllers {
    public class HabilidadeController : Controller {
        private readonly MeuCurriculoContext _db;

        public HabilidadeController(MeuCurriculoContext db) {
            _db = db;
        }

        public async Task<IActionResult> Index() {
            return View(await _db.Habilidades.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var habilidade = await _db.Habilidades.FirstOrDefaultAsync(m => m.Id == id);

            if (habilidade == null) {
                return NotFound();
            }

            return View(habilidade);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Id,DataCadastro,IsDeleted")] Habilidade habilidade) {
            if (ModelState.IsValid) {
                _db.Add(habilidade);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(habilidade);
        }

        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var habilidade = await _db.Habilidades.FindAsync(id);
            if (habilidade == null) {
                return NotFound();
            }

            return View(habilidade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descricao,Id,DataCadastro,IsDeleted")] Habilidade habilidade) {
            if (id != habilidade.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _db.Update(habilidade);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!HabilidadeExists(habilidade.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(habilidade);
        }

        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var habilidade = await _db.Habilidades.FirstOrDefaultAsync(m => m.Id == id);
            if (habilidade == null) {
                return NotFound();
            }

            return View(habilidade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var habilidade = await _db.Habilidades.FindAsync(id);
            _db.Habilidades.Remove(habilidade);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool HabilidadeExists(int id) {
            return _db.Habilidades.Any(e => e.Id == id);
        }
    }
}
