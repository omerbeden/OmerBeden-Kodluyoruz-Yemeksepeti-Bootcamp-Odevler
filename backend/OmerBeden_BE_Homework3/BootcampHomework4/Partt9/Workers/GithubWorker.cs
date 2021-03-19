using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Partt9.Workers
{
    public class GithubWorker : BackgroundService
    {
        private IHttpClientFactory _clientFactory;

        public GithubWorker(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

        }


        /*
         * Her 4 saatte bir github daki trendt repoları çekip json şeklinde kaydediyor
         */
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://github.com/trending");
                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(request);


                if (response.IsSuccessStatusCode)
                {
                    using (var htmlContent = response.Content.ReadAsStringAsync())
                    {
                        HtmlDocument htmlDocument = new HtmlDocument();
                        htmlDocument.LoadHtml(htmlContent.Result);
                        var htmlRepos = htmlDocument.DocumentNode.Descendants("h1")
                            .Where(node => node.GetAttributeValue("class", " ").Contains("h3 lh-condensed"))
                            .ToList();

                        
                        List<string> repos = new List<string>();

                        foreach (var htmlRepo in htmlRepos)
                        {
                            string repoNameSalt = htmlRepo.ChildNodes[1].InnerText.Trim();
                            var repoNameSplit = Regex.Replace(repoNameSalt, @"\t|\n|\r", "").Split('/');
                            var repoName = repoNameSplit[0].Trim() + "/" + repoNameSplit[1].Trim();

                            repos.Add(repoName);
                        }

                        var jsonResult = JsonConvert.SerializeObject(repos);
                        using (var writer = new StreamWriter("github_trending.json", false))
                        {
                            writer.WriteLine(jsonResult);
                        }
                    }
                }
                await Task.Delay(TimeSpan.FromHours(4));
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
