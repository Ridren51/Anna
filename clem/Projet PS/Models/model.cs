using Newtonsoft.Json;
using Projet_PS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Projet_PS
{
    internal class model
    {
        internal string actualLang { get; set; }

        internal job[] jobs = new job[5];

        internal model()
        {

            actualLang = "en";

            for (int i = 0; i < jobs.Length; i++)
            {
                jobs[i] = new job();
                jobs[i].active = false;
            }
        }

        public static void LogLine(string _name, string _source, string _target, string _size, string _transfertTime)
        {
            var logFormat = "json";
            var creeFileLogXML = 0;

            if (logFormat == "json")
            {
                string path = "..\\..\\..\\log_" + DateTime.Now.ToString("dd-MM-yyyy") + ".json";

                if (!File.Exists(path))
                {
                    File.WriteAllText(path, "[]");
                }

                logs WriteLog = new logs(_name, _source, _target, _size, _transfertTime);

                //read the json file
                //On recupère les données du Json
                string JsonLog = File.ReadAllText(path);

                //JsonToString put into the list 
                //Transforme le Json en string et met les données dans une list
                var LogList = JsonConvert.DeserializeObject<List<logs>>(JsonLog);

                //Add the data to the log list
                //Ajout les données dans la list des logs
                LogList.Add(WriteLog);

                //Convert the LogLine list into a json with indented format
                //Convertit notre liste en un json avec des indentations
                var StringToJson = JsonConvert.SerializeObject(LogList, Newtonsoft.Json.Formatting.Indented);

                //Write the data in the log file
                //Ecrit les données dans le fichier log
                File.WriteAllText(path, StringToJson);

            }
            else if (logFormat == "xml")
            {
                string path = @"..\..\..\log_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xml";

                if (!File.Exists(path))
                {

                    XmlTextWriter xmlDoc = new XmlTextWriter(path, System.Text.Encoding.UTF8);
                    xmlDoc.Formatting = System.Xml.Formatting.Indented;

                    xmlDoc.WriteStartDocument();

                    xmlDoc.WriteStartElement("logs");

                    xmlDoc.WriteEndElement();
                    xmlDoc.Flush();
                    xmlDoc.Close();

                    creeFileLogXML = 1;

                }


                List<logs> data = new List<logs>();

                if (creeFileLogXML != 1)
                {
                    //deserialize file
                    XmlSerializer Dserializer = new XmlSerializer(typeof(List<logs>));
                    StreamReader reader = new StreamReader(path);
                    data = (List<logs>)Dserializer.Deserialize(reader);
                    reader.Close();

                }

                logs WriteLog = new logs(_name, _source, _target, _size, _transfertTime);

                data.Add(WriteLog);

                //create the serialiser to create the xml
                XmlSerializer serialiser = new XmlSerializer(typeof(List<logs>));

                // Create the TextWriter for the serialiser to use
                TextWriter filestream = new StreamWriter(path);

                //write to the file
                serialiser.Serialize(filestream, data);

                // Close the file
                filestream.Close();

            }
        }

        internal struct job
        {
            internal bool active { get; set; }
            internal string name { get; set; }
            internal string pathSource { get; set; }
            internal string pathTarget { get; set; }
            internal string type { get; set; }
        }
    }
}