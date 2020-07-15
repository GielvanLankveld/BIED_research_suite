using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BIED_research_suite.Data;
using BIED_research_suite.Models.Database_entities;

namespace BIED_research_suite.Controllers
{
    public class DatasetsController : Controller
    {
        private readonly ResearchesContext _context;

        public DatasetsController(ResearchesContext context)
        {
            _context = context;
        }

        // GET: Datasets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dataset.ToListAsync());
        }

        // GET: Datasets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataset = await _context.Dataset
                .FirstOrDefaultAsync(m => m.DatasetID == id);
            if (dataset == null)
            {
                return NotFound();
            }

            return View(dataset);
        }

        // GET: Datasets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataset = await _context.Dataset
                .FirstOrDefaultAsync(m => m.DatasetID == id);
            if (dataset == null)
            {
                return NotFound();
            }

            return View(dataset);
        }

        // POST: Datasets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataset = await _context.Dataset.FindAsync(id);
            _context.Dataset.Remove(dataset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatasetExists(int id)
        {
            return _context.Dataset.Any(e => e.DatasetID == id);
        }
    }
}
