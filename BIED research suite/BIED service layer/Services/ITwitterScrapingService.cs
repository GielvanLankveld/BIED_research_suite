using System;

namespace BIED_service_layer
{
    public interface ITwitterScrapingService
    {
        void SetScrapingProject(string onderzoekId, string phaseId);
        void AddTwitterUserToScrapingProject(string onderzoekId, string phaseId, string twitterHandle);
        string GetScrapeResults(string onderzoekId, string phaseId);
    }
}
