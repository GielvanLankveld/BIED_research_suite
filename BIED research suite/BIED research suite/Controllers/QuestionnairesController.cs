using BIED_research_suite.Data;
using BIED_research_suite.Models.Database_entities;
using BIED_research_suite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BIED_research_suite.Controllers
{
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
        public async Task<IActionResult> Create([Bind("ID,Title,IntroText")] Questionnaire questionnaire)
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

            var questionnaire = await _context.Questionnaires.FindAsync(id);
            if (questionnaire == null)
            {
                return NotFound();
            }
            return View(questionnaire);
        }

        // POST: Questionnaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,IntroText")] Questionnaire questionnaire)
        {
            if (id != questionnaire.QuestionnaireID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionnaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionnaireExists(questionnaire.QuestionnaireID))
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
            return View(questionnaire);
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
