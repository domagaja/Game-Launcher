using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;


namespace Game_Launcher_Test
{
    internal class ParameterDesSpiels
    {
      
       public string TitelDesSpiels { get; set; }
       public string InstallationsDatum { get; set; }
       public string ZuletztGespielt { get; set; }
       public string InstallationsPfad { get; set; }
       public string Kategorie { get; set; }
       public string Publisher { get; set; }
       public int UskEinstufung { get; set; }
    }
    internal class SpieleMethoden
    {
         public List<ParameterDesSpiels> ParameterDesSpielsListe = new List<ParameterDesSpiels>();

        internal void SpielHinzufügen(string Titel, string Install_Datum, string Zuletzt_Gespielt, string Install_Pfad, string kategorie, string publisher, int Usk_Einstufung)
        {
            if (Titel == null || Install_Datum == null || Zuletzt_Gespielt == null || Install_Pfad == null || kategorie == null|| publisher == null || Usk_Einstufung != 0  && Usk_Einstufung != 6 && Usk_Einstufung != 12 && Usk_Einstufung != 16 && Usk_Einstufung != 18)
            {
                throw new ArgumentNullException("Bruh, es gibt nichts zum Hinzufügen.");
            }
            if (!File.Exists(Install_Pfad))
            {
                throw new FileNotFoundException("Bruh, im Installations Pfad gibt es Kein Spiel");
            }
            ParameterDesSpielsListe.Add(new ParameterDesSpiels()
            {
                TitelDesSpiels = Titel,
                InstallationsDatum = Install_Datum,
                ZuletztGespielt = Zuletzt_Gespielt,
                InstallationsPfad = Install_Pfad,
                Kategorie = kategorie,
                Publisher = publisher,
                UskEinstufung = Usk_Einstufung
            }); 

        }

        internal void SpielSpeichern(List<ParameterDesSpiels> list)
        {
            if (list.Any() == false)
            {
                throw new ArgumentNullException("bruh, die Liste ist leer. Speichern nicht möglich :(");
            }

            XmlDocument doc = new XmlDocument();
            XmlNode myRoot;
            doc.AppendChild(myRoot = doc.CreateElement("Spiele"));
            for (int i = 0; i < list.Count; i++)
            {
                myRoot.AppendChild(doc.CreateElement(list[i].TitelDesSpiels.Replace(" ", "_")));
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("Installations_Datum")).InnerText = list[i].InstallationsDatum;
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("ZuletztGespielt")).InnerText = list[i].ZuletztGespielt;
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("InstallationsPfad")).InnerText = list[i].InstallationsPfad;
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("Kategorie")).InnerText = list[i].Kategorie;
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("Publisher")).InnerText = list[i].Publisher;
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("UskEinstufung")).InnerText = list[i].UskEinstufung.ToString();
            }
            doc.Save(@"..\..\SpieleListe.xml");
            //https://jmcblog.de/2012/06/01/xml-datei-auslesen/
        }

        internal void SpielLaden(List<ParameterDesSpiels> list)
        {
            if (list.Any() == true)
            {
                throw new NotImplementedException();     
            }
           
        }
    }
}