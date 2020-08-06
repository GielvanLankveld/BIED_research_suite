using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BIED_service_layer.Services
{
    class TwitterScrapingService : ITwitterScrapingService
    {
        private HttpClient Client;
        private string scraperUrl = "http://127.0.0.1";
        public TwitterScrapingService(string scraperUrl)
        {
            this.Client = new HttpClient();
            this.scraperUrl = scraperUrl;
        }

        void ITwitterScrapingService.AddTwitterUserToScrapingProject(string onderzoekId, string phaseId, string twitterHandle)
        {
            throw new NotImplementedException();
        }

        string ITwitterScrapingService.GetScrapeResults(string onderzoekId, string phaseId)
        {   
            Console.WriteLine("Requesting scrape results on: " + scraperUrl);
            var reply = Client.GetAsync(scraperUrl + "/getresults/" + onderzoekId + "/" + phaseId + "/");

            Console.WriteLine("Result status: " + reply.Status.ToString());
            return reply.Result.ToString();
        }

        void ITwitterScrapingService.SetScrapingProject(string onderzoekId, string phaseId)
        {
            throw new NotImplementedException();
        }
    }
}
