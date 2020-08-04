using BIED_research_suite.Data;
using BIED_research_suite.Models.Database_entities;
using BIED_research_suite.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Controllers
{
    [Authorize(Roles = "Onderzoeker")]
    public class ResearchesController : Controller
    {
        private readonly ResearchesContext _researchesContext;
        private readonly ApplicationDbContext _usersContext;
        private readonly DatasetsContext _datasetsContext;
        private readonly QuestionnairesContext _questionnairesContext;

        public ResearchesController(ResearchesContext researchesContext,
            ApplicationDbContext usersContext,
            DatasetsContext datasetsContext,
            QuestionnairesContext questionnairesContext)
        {
            _researchesContext = researchesContext;
            _usersContext = usersContext;
            _datasetsContext = datasetsContext;
            _questionnairesContext = questionnairesContext;
        }

        // GET: Researches
        public async Task<IActionResult> Index()
        {
            return View(await _researchesContext.Researches.ToListAsync());
        }

        // GET: Researches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _researchesContext.Researches
                .FirstOrDefaultAsync(m => m.ResearchID == id);
            if (research == null)
            {
                return NotFound();
            }

            return View(research);
        }

        // GET: Researches/Create
        public IActionResult Create()
        {
            /*var alleOnderzoekers = _usersContext.Users
                .Include(u => u.IdentityUserRoles)
                .ToListAsync();*/

            var researchViewModel = new ResearchCreationViewModel
            {
                newResearch = new Research(),
                //researchers = 
            };


            return View(researchViewModel);
        }

        // POST: Researches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResearchCreationViewModel researchViewModel)
        {
            if (ModelState.IsValid)
            {
                _researchesContext.Add(researchViewModel.newResearch);
                await _researchesContext.SaveChangesAsync();

                //Gaat nu mis vanwege missende ID
                return RedirectToAction(nameof(Edit));
            }
            return View();
        }

        // GET: Researches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _researchesContext.Researches.FindAsync(id);
            if (research == null)
            {
                return NotFound();
            }
            return View(research);
        }

        // POST: Researches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResearchID,Title,StartingDateTime,EndingDateTime")] Research research)
        {
            if (id != research.ResearchID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _researchesContext.Update(research);
                    await _researchesContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResearchExists(research.ResearchID))
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
            return View(research);
        }

        // GET: Researches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _researchesContext.Researches
                .FirstOrDefaultAsync(m => m.ResearchID == id);
            if (research == null)
            {
                return NotFound();
            }

            return View(research);
        }

        // POST: Researches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var research = await _researchesContext.Researches.FindAsync(id);
            _researchesContext.Researches.Remove(research);
            await _researchesContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResearchExists(int id)
        {
            return _researchesContext.Researches.Any(e => e.ResearchID == id);
        }
    }
}
