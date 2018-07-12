using AzureWorkshop.BlobDemo.DropBox;
using System;

namespace AzureWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var dropBox = new DropBox(account: "henger", folder: @"d:\ma-workshop\dropbox\");
            dropBox.Start();
        }
    }
}
