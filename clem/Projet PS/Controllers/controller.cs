using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Projet_PS
{
    internal class controller
    {
        static view view = new view();
        static model model = new model();


        static void Main()
        {

            bool error = false;
            string res = null;
            bool runApp = true;

            while (runApp)
            {
                if (error == false) { view.displayMenu(model.actualLang); }
                else { view.displayMenu(model.actualLang, res); error = false; }


                res = Console.ReadLine();
                switch (res)
                {
                    case "1":
                        createJob();
                        break;

                    case "2":
                        execute();
                        break;

                    case "3":
                        executeAll();
                        break;

                    case "4":
                        langage();
                        break;

                    case "5":
                        runApp = false;
                        break;

                    default:
                        error = true;
                        break;
                }
            }
        }

        static void createJob()
        {


            int slot = 0;

            bool incorrect = true;
            while (incorrect)
            {

                view.displayListJobs(model.actualLang, model.jobs);


                string res = Console.ReadLine();
                switch (res)
                {
                    case "1":
                        slot = 1;
                        incorrect = false;
                        break;

                    case "2":
                        slot = 2;
                        incorrect = false;
                        break;

                    case "3":
                        slot = 3;
                        incorrect = false;
                        break;

                    case "4":
                        slot = 4;
                        incorrect = false;
                        break;

                    case "5":
                        slot = 5;
                        incorrect = false;
                        break;

                    default:
                        break;
                }
            }


            Console.Clear();
            Console.WriteLine(" Job name :");
            Console.Write(" >> ");
            model.jobs[slot - 1].name = Console.ReadLine();


            incorrect = true;
            while (incorrect)
            {
                Console.Clear();
                Console.WriteLine(" Source path :");
                Console.Write(" >> ");

                string path = Console.ReadLine();
                if (System.IO.Directory.Exists(path))
                {
                    model.jobs[slot - 1].pathSource = path;
                    incorrect = false;
                }
            }

            incorrect = true;
            while (incorrect)
            {
                Console.Clear();

                Console.WriteLine(" Target path :");
                Console.Write(" >> ");

                string path = Console.ReadLine();
                if (System.IO.Directory.Exists(path) && !path.Equals(model.jobs[slot - 1].pathSource))
                {
                    model.jobs[slot - 1].pathTarget = path;
                    incorrect = false;
                }
            }

            incorrect = true;
            while (incorrect)
            {
                Console.Clear();
                Console.WriteLine(" Job type :\n\n 1. Full\n 2. Differential\n");
                Console.Write(" >> ");

                string path = Console.ReadLine();

                switch (path)
                {
                    case "1":
                        model.jobs[slot - 1].type = "full";
                        incorrect = false;
                        break;

                    case "2":
                        model.jobs[slot - 1].type = "differential";
                        incorrect = false;
                        break;

                    default:
                        break;
                }
            }
            model.jobs[slot - 1].active = true;

            model.LogLine(model.jobs[slot - 1].name, model.jobs[slot - 1].pathSource, model.jobs[slot - 1].pathTarget, "0", "0");
            Console.WriteLine();

        }
        static void execute()
        {
            int slot = 0;
            bool incorrect = true;
            while (incorrect)
            {
                view.displayListJobs(model.actualLang, model.jobs);

                string res = Console.ReadLine();

                switch (res)
                {
                    case "1":
                        slot = 1;
                        incorrect = false;
                        break;

                    case "2":
                        slot = 2;
                        incorrect = false;
                        break;

                    case "3":
                        slot = 3;
                        incorrect = false;
                        break;

                    case "4":
                        slot = 4;
                        incorrect = false;
                        break;

                    case "5":
                        slot = 5;
                        incorrect = false;
                        break;

                    default:
                        break;
                }

            }

            if (model.jobs[slot - 1].active)
            {
                if (model.jobs[slot - 1].type == "full")
                {
                    executeFull(slot);
                }
                else
                {
                    executeDiff(slot);
                }
            }

        }
        static void executeAll()
        {
            Console.WriteLine("executeAll\n");
        }

        static void langage()
        {
            view.displayLangChange(model.actualLang);

            string res = Console.ReadLine();
            switch (res)
            {
                case "1":
                    model.actualLang = "en";
                    view.paramSaved(model.actualLang);
                    break;

                case "2":
                    model.actualLang = "fr";
                    view.paramSaved(model.actualLang);
                    break;

                default:
                    view.readError(model.actualLang, res);
                    break;
            }

        }
        static void executeFull(int slot)

        {
            try
            {
                string sourceDir = model.jobs[slot - 1].pathSource;
                string targetDir = model.jobs[slot - 1].pathTarget;

                string[] files = Directory.GetFiles(sourceDir);
                string[] oldFiles = Directory.GetFiles(targetDir);

                foreach (string f in oldFiles)
                {
                    File.Delete(f);
                }

                foreach (string f in files)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();

                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);

                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine(targetDir, fName), true);

                    stopWatch.Stop();
                    // Get the elapsed time as a TimeSpan value.
                    TimeSpan ts = stopWatch.Elapsed;

                    FileInfo info = new FileInfo(Path.Combine(sourceDir, fName));
                    model.LogLine(model.jobs[slot - 1].name, Path.Combine(sourceDir, fName), Path.Combine(targetDir, fName), info.Length.ToString(), stopWatch.Elapsed.TotalSeconds.ToString());
                    
                }
            }
            catch { }
        }
        static void executeDiff(int slot)
        {

        }
    }
}