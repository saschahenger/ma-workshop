using System;

namespace AzureWorkshop.ElasticDemo
{
    public class Dichter
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Geburtsort { get; set; }
        public DateTimeOffset Geburtstag { get; set; }
        public string Todesort { get; set; }
        public DateTimeOffset Todestag { get; set; }
    }
}