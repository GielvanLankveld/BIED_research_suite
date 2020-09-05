using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BIED_research_suite.Data;
using BIED_research_suite.Models.Database_entities;
using BIED_research_suite.Models;

namespace BIED_research_suite.Controllers
{
    public class DeelnemersController : Controller
    {
        private readonly ResearchesContext _researchesContext;
        private readonly QuestionnairesContext _questionnairesContext;
        private readonly DatasetsContext _datasetsContext;

        public DeelnemersController(ResearchesContext researchesContext, QuestionnairesContext questionnairesContext, DatasetsContext datasetsContext)
        {
            _researchesContext = researchesContext;
            _questionnairesContext = questionnairesContext;
            _datasetsContext = datasetsContext;

            //If no datasets were found, seed one
            if (_datasetsContext.Datasets.Any() == false)
            {
                Dataset dummyDataset = new Dataset
                {
                    //QuestionnaireID = _questionnairesContext.Questionnaires

                };

                _datasetsContext.Add(dummyDataset);
            }
        }

        // GET: Deelnemers
        public async Task<IActionResult> Index()
        {
            return View(await _questionnairesContext.Questionnaires.ToListAsync());
        }

        // GET: Deelnemers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataset = await _datasetsContext.Datasets
                .FirstOrDefaultAsync(m => m.DatasetID == id);
            if (dataset == null)
            {
                return NotFound();
            }

            return View(dataset);
        }

        // GET: Deelnemers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deelnemers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatasetID,QuestionnaireID,ParticipantID,SubmissionDate")] Dataset dataset)
        {
            if (ModelState.IsValid)
            {
                _datasetsContext.Add(dataset);
                await _datasetsContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataset);
        }

        // GET: Deelnemers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionnaire = await _questionnairesContext.Questionnaires
                    .Include(s => s.QuestionnaireSections)
                        .ThenInclude(i => i.QuestionnaireItems)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(q => q.QuestionnaireID == id);
            var dataset = await _datasetsContext.Datasets.FindAsync(id);

            if ((questionnaire == null))
            {
                return NotFound();
            }

            if (dataset == null)
            {
                //New dataset
                dataset = new Dataset();
                dataset.ParticipantID = User.Identity.Name;
            }

            var responseViewModel = new ResponseViewModel();
            responseViewModel.questionnaire = questionnaire;
            responseViewModel.dataset = dataset;

            return View(responseViewModel);
        }

        // POST: Deelnemers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ResponseViewModel response)
        {
            if (id != response.dataset.DatasetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _datasetsContext.Update(response.dataset);
                    await _datasetsContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatasetExists(response.dataset.DatasetID))
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
            return View(response.dataset);
        }

        // GET: Deelnemers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataset = await _datasetsContext.Datasets
                .FirstOrDefaultAsync(m => m.DatasetID == id);
            if (dataset == null)
            {
                return NotFound();
            }

            return View(dataset);
        }

        // POST: Deelnemers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataset = await _datasetsContext.Datasets.FindAsync(id);
            _datasetsContext.Datasets.Remove(dataset);
            await _datasetsContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatasetExists(int id)
        {
            return _datasetsContext.Datasets.Any(e => e.DatasetID == id);
        }
    }
}
