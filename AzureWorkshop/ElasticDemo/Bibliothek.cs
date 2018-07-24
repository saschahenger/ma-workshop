using Nest;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AzureWorkshop.ElasticDemo
{
    /*
     * Note:  Elastic Search muss gestartet und http://localhost:9200/ muss erreichbar sein
     *        Soll Eleastic Search auf einen anderen Rechner oder Port laufen muss ElasticConnectionString verwendet werden
     * NuGet: NEST
     * Links: https://www.elastic.co/guide/en/elasticsearch/reference/current/_modifying_your_data.html
     *        https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/nest-getting-started.html
     */


    class Bibliothek
    {
        private readonly ElasticClient _client;

        public Bibliothek()
        {
            _client = new ElasticClient();
        }

        public async Task StartAsync()
        {
            var keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine();
                PrintOptions();
                Console.Write("> ");
                var key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (key)
                {
                    case '1':
                        await ImportiereAlleGedichteAsync();
                        break;
                    case '2':
                        await LoescheAlleGedichteAsync();
                        break;
                    case '3':
                        await ListeAlleDatenSortiertAufAsync();
                        break;
                    case '4':
                        await SucheNachTextAsync();
                        break;

                    case '0':
                        keepRunning = false;
                        break;
                }
            }
        }

        private void PrintOptions()
        {
            Console.WriteLine("Wähle eine Option:");
            Console.WriteLine("  1: Importiere alle Gedichte");
            Console.WriteLine("  2: Lösche alle Gedichte");
            Console.WriteLine("  3: Sortiere alle Gedichte");
            Console.WriteLine("  4: Suche im Text");
            Console.WriteLine("  0: Ende");
        }

        private async Task ImportiereAlleGedichteAsync()
        {
            foreach (var gedicht in GedichtGenerator.ErzeugeGedichte())
            {
                var response = await _client.IndexAsync(gedicht, i => i.Index("gedicht"));
                if (response.Result == Result.Created)
                    Console.WriteLine($"Gedicht {gedicht.Titel} wurde importiert");
            }
        }

        private async Task LoescheAlleGedichteAsync()
        {
            var response = await _client.DeleteByQueryAsync<Gedicht>(s => s.MatchAll().Index("gedicht"));
            Console.WriteLine($"Es wurden {response.Total} Gedichte gelöscht");
        }

        private async Task ListeAlleDatenSortiertAufAsync()
        {
            var gedichtResonse = await _client.SearchAsync<Gedicht>(s => s.MatchAll()
                .Take(1000)
                .Source(source => source.Includes(i => i.Fields("titel", "autor")))
                .Sort(sort => sort.Ascending("autor.keyword").Ascending("titel.keyword"))
                .Index("gedicht"));

            gedichtResonse.Documents.ToList().ForEach(t => Console.WriteLine($"  {t.Autor}: {t.Titel}"));
        }

        private async Task SucheNachTextAsync()
        {
            Console.Write("Suche nach: > ");
            var suchtext = Console.ReadLine();

            var response = await _client.SearchAsync<Gedicht>(s => 
                s.Query(q =>
                q.SimpleQueryString(sqs => sqs.Query(suchtext)
                    .AnalyzeWildcard()
                    .Fields(f => f.Field("content"))))
                .Index("gedicht")
                .Take(1000));

            Console.WriteLine($"Gedichte mit dem Suchtext {suchtext}");
            response.Documents.ToList().ForEach(t =>
            {
                Console.WriteLine($"{t.Autor}: {t.Titel}");
                Console.WriteLine($"{t.Content}");
                Console.WriteLine();
            });
        }
    }
}
