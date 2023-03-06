using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Xml;
using System;

string paramPath = "..\\..\\..\\Parameters.json";
string filePath;

class Program
{
    public static void Main(string[] Args)
    {
        Console.WriteLine("Arguments :");
        
        foreach(string arg in Args)
        {
            Console.WriteLine("- " + arg);
        }

        if (!File.Exists(paramPath))
        {
            File.WriteAllText(paramPath, "{\r\n  \"Cle\": \"\"\r\n}");
        }
        string cle = File.ReadAllText(paramPath);
        parametres parametres = JsonConvert.DeserializeObject<parametres>(cle);//new parametres("");//

        bool cleCorrecte = false;
        while (!cleCorrecte)
        {
            Console.WriteLine("Clé actuelle : " + parametres.Cle + "test1212");
            Console.WriteLine("Souhaitez-vous :\n1. Garder la clé actuelle\n2. Modifier la clé");
            string rep = Console.ReadLine();
            Console.Clear();
            if (rep != null && rep == "1")
            {
                Console.WriteLine("Vérification de la clé...");
                cleCorrecte = parametres.CleIs64Bits(parametres, paramPath);
            }
            else if (rep != null && rep == "2")
            {
                Console.WriteLine("Modification de la clé...");
                parametres.Cle = "";
                cleCorrecte = parametres.CleIs64Bits(parametres, paramPath);
            }
            else
            {
                Console.WriteLine("Veuillez taper '1' ou '2'.");
            }
        }

        Console.WriteLine("Veuillez saisir le fichier à crypter/décrypter :");
        filePath = Console.ReadLine();
        string fichier = File.ReadAllText(filePath);


        string txt_chiffre = EncryptOrDecrypt(fichier, parametres.Cle);
        File.WriteAllText(filePath, txt_chiffre);
        Console.WriteLine("Fichier crypté ! Souhaitez-vous l'ouvrir ?\n1. Oui\n2. Non");
        string reponse = Console.ReadLine();
        if (reponse != null && reponse == "1")
        {
            Console.Write("Ouverture du fichier");
            for (int i = 0; i < 2; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Process process = new Process();
            process.StartInfo.FileName = "notepad.exe";
            process.StartInfo.Arguments = filePath;
            process.Start();
            Console.Clear();
            //File.Open(filePath, FileMode.Open);
        }
        else if (reponse != null && reponse == "2")
        {
            Console.WriteLine("Fichier non ouvert.");
            Console.Clear();
        }
        else
        {
            Console.WriteLine("erreur");
            Console.Clear();
        }

        string EncryptOrDecrypt(string text, string key)
        {
            var result = new StringBuilder();

            for (int c = 0; c < text.Length; c++)
            {
                // prend le prochain caractère du string
                char character = text[c];


                // traduit en code ASCII
                int charCode = (int)character;

                // détermine le caractère de la clé à prendre selon le caractère du texte
                int keyPosition = c % key.Length;

                // prend le caractère à la position déterminée précédemment
                char keyChar = key[keyPosition];

                // traduit en code ASCII
                int keyCode = (int)keyChar;

                // utilisation de XOR sur les deux caractères
                int combinedCode = charCode ^ keyCode;

                // traduit en caractère
                char combinedChar = (char)combinedCode;

                // ajout du caractère dans le résultat
                result.Append(combinedChar);


            }

            return result.ToString();
        }
    }
}






public class parametres
{
    public string Cle { get; set; }

    public parametres(string cle = null)
    {
        this.Cle = cle;
    }

    public bool CleIs64Bits(parametres parametres, string path)
    {
            if (parametres.Cle == null || Cle.Length < 8)
            {
                Console.WriteLine("Veuillez entrer une clé de 8 caractères minimum");
                parametres.Cle = Console.ReadLine();
                var StringToJson = JsonConvert.SerializeObject(parametres, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, StringToJson);
                Console.Clear();
                return false;
            }

            else if (parametres.Cle.Length >= 8)
            {
                Console.WriteLine("Clé correcte !\n\n");
                return true;
            }

            else
            {
                Console.WriteLine("Erreur");
                parametres.Cle = Console.ReadLine();
                var StringToJson = JsonConvert.SerializeObject(parametres, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, StringToJson);
                return false;
            }
    }

}
    
