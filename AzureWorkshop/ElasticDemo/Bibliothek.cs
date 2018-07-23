using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace AzureWorkshop.ElasticDemo
{
    // NuGet: NEST

    class Bibliothek
    {
        public Bibliothek()
        {

        }

        public async Task StartAsync()
        {
            var dichter = DocumentGenerator.GetDichters();
            var gedichte = DocumentGenerator.GetGedichts();
                   
            var client = new ElasticClient();

            var searchFluid =
                client.Search<Person>(search => search.Index("people").Type("person").Query(q => q.MatchAll()));
            var docs = searchFluid.Documents;

            var person = new Person { FirstName = "Jens", LastName = "Beneke" };
            var result = await client.IndexAsync(person, i => i.Index("people"));
            //var response = result.Result;

            //var result = client.Index(person, i => i.Index("person"));

        }

    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
