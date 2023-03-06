using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace Projet_PS
{
    internal class view
    {
        static langs result;
        internal view()
        {
            StreamReader r = new StreamReader("..\\..\\..\\translate.json");
            string json = r.ReadToEnd();
            result = JsonSerializer.Deserialize<langs>(json);
        }


        internal void displayMenu(string actualLang)
        {
            Console.Clear();
            Console.WriteLine(result.langage[actualLang].menu);
            Console.Write(" >> ");
        }
        internal void displayMenu(string actualLang, string error)
        {
            Console.Clear();
            Console.WriteLine(result.langage[actualLang].menu);
            Console.WriteLine("'" + error + "' " + result.langage[actualLang].readError);
            Console.Write(" >> ");
        }
        internal void displayLangChange(string actualLang)
        {
            Console.Clear();
            Console.WriteLine(result.langage[actualLang].langChange);
            Console.Write(" >> ");
        }
        internal void paramSaved(string actualLang)
        {
            Console.Clear();
            Console.WriteLine(result.langage[actualLang].savedParam);
        }
        internal void readError(string actualLang, string command)
        {
            Console.Clear();
            Console.WriteLine("'" + command + "' " + result.langage[actualLang].readError);
        }

        internal void displayListJobs(string actualLang, job[] jobs)
        {
            Console.Clear();
            Console.WriteLine("  Which slot do you want to use ?\n\n");


            for (int i = 0; i < 5; i++)
            {
                if (jobs[i].active != false)
                {
                    Console.WriteLine(" slot " + (i + 1) + " : " + jobs[i].name);
                }
                else
                {
                    Console.WriteLine(" slot " + (i + 1) + " : *Empty*");
                }
            }
            Console.WriteLine();
            Console.Write(" >> ");


        }
    }



    internal class langs
    {
        public Dictionary<string, sentences> langage { get; set; }
    }
    internal class sentences
    {
        public string test { get; set; }
        public string menu { get; set; }
        public string langChange { get; set; }
        public string savedParam { get; set; }
        public string readError { get; set; }
    }
}