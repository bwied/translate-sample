﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpRequestUtility;
// Install Newtonsoft.Json with NuGet
using Newtonsoft.Json;
using TranslationServices;

namespace translate_sample
{
    class Program
    {
        private Dictionary<string, Dictionary<Action, string>> _options;
        private static TranslationServicesFacade _service;

        static void Main(string[] args)
        {
            using (_service = new TranslationServicesFacade())
            {
                var program = new Program();
                var shouldExit = false;
                do
                {
                    try
                    {
                            var optionCounter = 1;

                            Console.Clear();
                            Console.WriteLine($"Process Id: {Process.GetCurrentProcess().Id}");
                            foreach (var option in program.Options)
                            {
                                var options = option.Value.ToArray();
                                Console.WriteLine(option.Key);
                                for (int i = 0; i < options.Length; i++)
                                {
                                    Console.WriteLine($"    {(optionCounter++).ToString().PadLeft(2)} - {options[i].Value}");
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine("     0 - Exit");
                            Console.WriteLine();
                            Console.WriteLine("Enter a value:");
                            var selection = Console.ReadLine() ?? string.Empty;
                            shouldExit = (selection.Equals("0"));

                            if (shouldExit) return;


                            program.Execute(selection);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                } while (!shouldExit);
            }
        }

        private Dictionary<string, Dictionary<Action, string>> Options =>
            _options ?? (_options = new Dictionary<string, Dictionary<Action, string>>()
            {
                {
                    "General", new Dictionary<Action, string>()
                    {
                        {Translate, "Translate"},
                        {TranslateHtml, "Translate HTML"},
                        {Translations, "Get Translations"},
                        {Transliterations, "Get Transliterations"},
                        {TranslationDictionary, "Get TranslationDictionary"},
                        {Languages, "Get Languages"}
                    }
                }
            });

        private void Execute(string selection)
        {
            Options.SelectMany(x => x.Value).ToArray()[int.Parse(selection) - 1].Key.Invoke();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private void Translate()
        {
            // Prompts you for text to translate. If you'd prefer, you can
            // provide a string as textToTranslate.
            Console.WriteLine("Type the phrase you'd like to translate? ");
            string textToTranslate = Console.ReadLine();
            Console.WriteLine("Enter 'from' language (blank for auto-detect):");
            var from = Console.ReadLine();
            Console.WriteLine("Enter the BCP 47 language tag(s):");
            var deserializedOutput = _service.TranslateTextAsync(textToTranslate, Console.ReadLine()?.Split(',', StringSplitOptions.RemoveEmptyEntries), from).Result.Object;

            Console.WriteLine(JsonConvert.SerializeObject(deserializedOutput, Formatting.Indented));
        }

        private void TranslateHtml()
        {
            // Prompts you for text to translate. If you'd prefer, you can
            // provide a string as textToTranslate.
            Console.WriteLine("Type the phrase you'd like to translate? ");
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            string textToTranslate = Console.ReadLine();
            Console.WriteLine("Enter 'from' language (blank for auto-detect):");
            var from = Console.ReadLine();
            Console.WriteLine("Enter the BCP 47 language tag(s):");
            var deserializedOutput = _service.TranslateHtmlAsync(textToTranslate, Console.ReadLine()?.Split(',', StringSplitOptions.RemoveEmptyEntries), from).Result.Object;

            Console.WriteLine(JsonConvert.SerializeObject(deserializedOutput, Formatting.Indented));
        }

        private void Translations()
        {
            var deserializedOutput = _service.GetTranslationsAsync().Result.Object;

            Console.WriteLine(JsonConvert.SerializeObject(deserializedOutput, Formatting.Indented));
        }

        private void Transliterations()
        {
            var deserializedOutput = _service.GetTransliterationsAsync().Result.Object;

            Console.WriteLine(JsonConvert.SerializeObject(deserializedOutput, Formatting.Indented));
        }

        private void TranslationDictionary()
        {
            var deserializedOutput = _service.GetTranslationDictionaryAsync().Result.Object;

            Console.WriteLine(JsonConvert.SerializeObject(deserializedOutput, Formatting.Indented));
        }

        private void Languages()
        {
            var deserializedOutput = _service.GetLanguagesAsync().Result.Object;

            Console.WriteLine("Languages:");
            Console.WriteLine(JsonConvert.SerializeObject(deserializedOutput, Formatting.Indented));
        }
    }
}
