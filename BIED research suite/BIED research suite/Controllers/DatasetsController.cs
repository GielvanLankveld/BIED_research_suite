using BIED_research_suite.Data;
using BIED_service_layer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using BIED_research_suite.Models.Database_entities;

namespace BIED_research_suite.Controllers
{
    public class DatasetsController : Controller
    {
        IConfiguration configuration;
        private readonly DatasetsContext _dsContext;
        private ResearchesContext _rContext;
        private IScrapingService twitterScrapingService;

        public DatasetsController(IConfiguration configuration, DatasetsContext dsContext, ResearchesContext rContext)
        {
            this.configuration = configuration;
            _dsContext = dsContext;
            _rContext = rContext;
            //Dit moet een nette dependency injection worden via een interface met de service url via de appsettings.json ... maar geen tijd.
            twitterScrapingService = new TwitterScrapingService();
            //twitterScrapingService.SetServiceUrl("127.0.0.1:5000"); //Service url moet het ip en poort van de twitter scraper service zijn op het docker network (dus alleen lokale aanroep)
        }

        // GET: Datasets
        public async Task<IActionResult> Index()
        {

            return View(await _dsContext.Datasets.ToListAsync());
        }

        //GET: Datasets/DownloadJSON/1
        public async Task<IActionResult> DownloadJSON(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Haal de hele dataset op voor het project met id 'id'  in JSON format
            List<Dataset> dataset = await _dsContext.Datasets.Where(d => d.ResearchID == id).ToListAsync();

            if (dataset == null)
            {
                return NotFound();
            }

            var research = await _rContext.Researches.Where(r => r.ResearchID == id).FirstOrDefaultAsync();


            //Stream stream = 
            //string mimetype = "application/json";

            //return new FileContentResult(stream, mimetype)
            //{
            //    FileDownloadName = dataset.ResearchID
            //}

            return View();
        }

        //GET: Datasets/DownloadCSV/1
        public async Task<IActionResult> DownloadCSV(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Haal de hele dataset op voor het project met id 'id' in CSV format


            return View();
        }

        // GET: Datasets/Details/5
        public async Task<IActionResult> ProjectListing()
        {
            List<string> projectListing = await twitterScrapingService.GetAllProjects();

            if (projectListing == null)
            {
                return NotFound();
            }

            return View(projectListing);
        }

        // GET: Datasets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datasets = await _dsContext.Datasets
                    .AsNoTracking()
                    .FirstOrDefaultAsync(q => q.DatasetID == id);

            if (datasets == null)
            {
                return NotFound();
            }

            return View(datasets);
        }

        // GET: Datasets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datasets = await _dsContext.Datasets
                .FirstOrDefaultAsync(m => m.DatasetID == id);

            if (datasets == null)
            {
                return NotFound();
            }

            return View(datasets);
        }

        // POST: Datasets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataset = await _dsContext.Datasets.FindAsync(id);
            _dsContext.Datasets.Remove(dataset);
            await _dsContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatasetExists(int id)
        {
            return _dsContext.Datasets.Any(e => e.DatasetID == id);
        }
    }
}
