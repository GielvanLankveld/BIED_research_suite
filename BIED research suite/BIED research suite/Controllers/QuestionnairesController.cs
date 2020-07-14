﻿using BIED_research_suite.Data;
using BIED_research_suite.Models.Database_entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Controllers
{
    [Authorize(Roles = "Onderzoeker")]
    public class QuestionnairesController : Controller
    {
        private readonly QuestionnairesContext _context;

        public QuestionnairesController(QuestionnairesContext context)
        {
            _context = context;
        }

        // GET: Questionnaires
        public async Task<IActionResult> Index()
        {
            return View(await _context.Questionnaires.ToListAsync());
        }

        // GET: Questionnaires/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Eager loading van de gerelateerde secties en items
            var questionnaire = await _context.Questionnaires
                    .Include(s => s.QuestionnaireSections)
                        .ThenInclude(i => i.QuestionnaireItems)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(q => q.QuestionnaireID == id);

            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(questionnaire);
        }

        // GET: Questionnaires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Questionnaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionnaireID,Title,IntroText")] Questionnaire questionnaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionnaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionnaire);
        }

        // GET: Questionnaires/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionnaire = await _context.Questionnaires
                    .Include(s => s.QuestionnaireSections)
                        .ThenInclude(i => i.QuestionnaireItems)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(q => q.QuestionnaireID == id);

            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(questionnaire);
        }

        // POST: Questionnaires/Edit/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Questionnaire updatedQuestionnaire)
        {
            if (updatedQuestionnaire == null)
            {
                return NotFound();
            }

            if (_context == null)
            {
                var questionnaire = await _context.Questionnaires
                    .Include(s => s.QuestionnaireSections)
                        .ThenInclude(i => i.QuestionnaireItems)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(q => q.QuestionnaireID == updatedQuestionnaire.QuestionnaireID);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updatedQuestionnaire);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }

            return View();
        }

        // GET: Questionnaires/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionnaire = await _context.Questionnaires
                .FirstOrDefaultAsync(m => m.QuestionnaireID == id);
            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(questionnaire);
        }

        // POST: Questionnaires/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionnaire = await _context.Questionnaires.FindAsync(id);
            _context.Questionnaires.Remove(questionnaire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionnaireExists(int id)
        {
            return _context.Questionnaires.Any(e => e.QuestionnaireID == id);
        }
    }
}
