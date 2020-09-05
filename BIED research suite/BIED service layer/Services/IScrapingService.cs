using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BIED_service_layer.Services
{
    public interface IScrapingService
    {
        void SetServiceUrl(string scraperUrl);
        void StartScrapingProject(string onderzoekId, string phaseId, string startDateTime, string endDateTime);
        void DeleteScrapingProject(string onderzoekId);
        void AddParticipantToScrapingProject(string onderzoekId, string phaseId, string handle);
        Task<string> GetScrapeResults(string onderzoekId, string phaseId);
        Task<List<string>> GetAllProjects();
        Task<string> GetDataCollectionStatus();
    }
}
