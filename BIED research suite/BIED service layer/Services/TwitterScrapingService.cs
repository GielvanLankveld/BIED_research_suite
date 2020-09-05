using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;

namespace BIED_service_layer.Services
{
    public class TwitterScrapingService : IScrapingService
    {
        private string scraperUrl = "http://127.0.0.1:5000";

        public void SetServiceUrl(string scraperUrl)
        {
            this.scraperUrl = scraperUrl;
        }

        public async void AddParticipantToScrapingProject(string onderzoekId, string phaseId, string handle)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Requesting adding twitter handle to project on: " + scraperUrl);
                using (var response = await client.GetAsync(scraperUrl + "/addtwitterhandle/" + onderzoekId + "/" + phaseId + "/" + handle + "/"))
                {
                    Console.WriteLine("Result status: " + response.StatusCode.ToString());
                }
            }
        }

        public async void DeleteScrapingProject(string onderzoekId)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Requesting scrape results on: " + scraperUrl);
                using (var response = await client.GetAsync(scraperUrl + "/deleteproject/" + onderzoekId))
                {
                    Console.WriteLine("Result status: " + response.StatusCode.ToString());
                }
            }
        }

        public async Task<List<string>> GetAllProjects()
        {
            var httpClient = new HttpClient();
            try
            {
                using var response = await httpClient.GetAsync(scraperUrl + "/getallprojects/");

                string content = await response.Content.ReadAsStringAsync();

                List<string> projects = JsonSerializer.Deserialize<List<string>>(content);

                return projects;
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException)
            {
                Console.WriteLine("Invalid JSON.");
            }

            return null;

            /*using (var client = new HttpClient())
            {
                List<string> reply;
                Console.WriteLine("Requesting project listing on: " + scraperUrl);
                using (var response = await client.GetAsync(scraperUrl + "/getallprojects/"))
                {
                    Console.WriteLine("Result status: " + response.StatusCode.ToString());
                    reply = response.Content;
                }
                return reply;
            }*/
        }

        //Van deze weet ik even het nut niet meer
        public async Task<string> GetDataCollectionStatus()
        {
            using (var client = new HttpClient())
            {
                string reply;
                Console.WriteLine("Requesting data collection status on: " + scraperUrl);
                using (var response = await client.GetAsync(scraperUrl + "/getdatacollectionstatus/"))
                {
                    Console.WriteLine("Result status: " + response.StatusCode.ToString());
                    reply = response.Content.ToString();
                }
                return reply;
            }
        }

        public async Task<string> GetScrapeResults(string onderzoekId, string phaseId)
        {
            using (var client = new HttpClient())
            {
                string reply;
                Console.WriteLine("Requesting scrape results on: " + scraperUrl);
                using (var response = await client.GetAsync(scraperUrl + "/getresults/" + onderzoekId + "/" + phaseId + "/"))
                {
                    Console.WriteLine("Result status: " + response.StatusCode.ToString());
                    reply = response.Content.ToString();
                }
                return reply;
            }
        }

        public async void StartScrapingProject(string onderzoekId, string phaseId, string startDateTime, string endDateTime)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Starting scraping project on: " + scraperUrl);
                using (var response = await client.GetAsync(scraperUrl + "/startproject/" + onderzoekId + "/" + phaseId + "/" + startDateTime + "/" + endDateTime + "/"))
                {
                    Console.WriteLine("Result status: " + response.StatusCode.ToString());
                }
            }
        }
    }
}
