using System;
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
        public Bibliothek()
        {
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
            // todo: Gedichte aus dem Generator in die ES importieren
        }

        private async Task LoescheAlleGedichteAsync()
        {
            // todo: Alle Gedichte oder den Index löschen
        }

        private async Task ListeAlleDatenSortiertAufAsync()
        {
            // todo: Alle Gedichte sortiert ausgeben
        }

        private async Task SucheNachTextAsync()
        {
            Console.Write("Suche nach: > ");
            var suchtext = Console.ReadLine();

            // todo: Gedichte ausgeben, die den Suchtext im Content enthalten

            Console.WriteLine($"Gedichte mit dem Suchtext {suchtext}");
        }
    }
}
