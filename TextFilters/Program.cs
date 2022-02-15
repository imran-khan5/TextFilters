using System;
using System.IO;
using System.Text;
using TextFilters.ChainOfResponsibility.Handlers;

namespace TextFilters
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize chain of responsibility handlers
            CharacterFilter charFilter = new CharacterFilter();
            TextLengthFilter lengthFilter = new TextLengthFilter();
            VowelInMiddleFilter vowelFilter = new VowelInMiddleFilter();

            // set the chain of handlers
            charFilter.SetNextHandler(lengthFilter);
            lengthFilter.SetNextHandler(vowelFilter);

            // Read the text file in the string
            string text = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "sample.txt"));

            // split string in to arrays
            var words = text.Split(" ");
            var filteredOutText = new StringBuilder();
            var resultText = new StringBuilder();

            foreach (var str in words)
            {
                var result = charFilter.Handle(str);
                if (result)
                {
                    filteredOutText.Append($"{str} ");
                }
                else
                {
                    resultText.Append($"{str} ");
                }
            }

            Console.WriteLine($"Result Text OUTPUT: \n{ resultText.ToString().Trim() }\n");
            Console.WriteLine($"Filter Out Text OUTPUT: \n{ filteredOutText.ToString().Trim() }");

            Console.ReadLine();
        }
    }
}
