using System;
using System.IO;
using SkyScraper;
using SkyScraper.Observers.ConsoleWriter;
using SkyScraper.Observers.ImageScraper;

namespace SkyScrape
{
    class Program
    {
        static void Main(string[] args)
        {
            //take a URI and an output file to handoff to SkyScraper

            var httpClient = new HttpClient { UserAgentName = "RecruiterScan" };
            var MyScraper = new Scraper (httpClient, new ScrapedUrisDictionary());
            //var io = new ImageScraperObserver(httpClient, new FileWriter(new DirectoryInfo(args[1])));
            MyScraper.Subscribe(new ConsoleWriterObserver() );
            MyScraper.MaxDepth = 8;
            MyScraper.TimeOut = TimeSpan.FromMinutes(5);
            //MyScraper.IgnoreLinks = new System.Text.RegularExpressions.Regex("spam");
            //MyScraper.IncludeLinks = new System.Text.RegularExpressions.Regex("stuff");
            //MyScraper.ObserverLinkFilter = new System.Text.RegularExpressions.Regex("things");
            MyScraper.DisableRobotsProtocol = true; 
            MyScraper.Scrape(new Uri(args[0])).Wait();
        }
    }
}
