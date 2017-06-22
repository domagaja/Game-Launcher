using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;

namespace Game_Launcher_Bibliothek1
{
    public class ParameterDesSpiels
    {
      
       public string TitelDesSpiels { get; set; }
       public string InstallationsDatum { get; set; }
       public string ZuletztGespielt { get; set; }
       public string InstallationsPfad { get; set; }
       public string Kategorie { get; set; }
       public string Publisher { get; set; }
       public int UskEinstufung { get; set; }
    }
    public class SpieleMethoden
    {
        public bool ListeSollLeerSein = false;
        public List<ParameterDesSpiels> ParameterDesSpielsListe = new List<ParameterDesSpiels>();

        public void SpielHinzufügen(string Titel, string Install_Datum, string Zuletzt_Gespielt, string Install_Pfad, string kategorie, string publisher, int Usk_Einstufung)
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

        public void SpielSpeichern(List<ParameterDesSpiels> list)
        {
            if (list.Any() == false && ListeSollLeerSein == false)
            {
                throw new ArgumentNullException("bruh, die Liste ist leer. Speichern nicht möglich :(");
            }
            ListeSollLeerSein = false;
            XmlDocument doc = new XmlDocument();
            XmlNode myRoot;
            doc.AppendChild(myRoot = doc.CreateElement("Spiele"));
            for (int i = 0; i < list.Count; i++)
            {
                myRoot.AppendChild(doc.CreateElement(list[i].TitelDesSpiels.Replace(" ", "_")));
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("Titel")).InnerText = list[i].TitelDesSpiels;
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("Installations_Datum")).InnerText = list[i].InstallationsDatum;
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("ZuletztGespielt")).InnerText = list[i].ZuletztGespielt;
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("InstallationsPfad")).InnerText = list[i].InstallationsPfad;
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("Kategorie")).InnerText = list[i].Kategorie;
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("Publisher")).InnerText = list[i].Publisher;
                myRoot.SelectSingleNode(list[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("UskEinstufung")).InnerText = list[i].UskEinstufung.ToString();
            }
            doc.Save(@"..\..\SpieleListe.xml");
            
        }

        public void SpielStarten(string Titel)
        {
            var SpielZuÖffnen = ParameterDesSpielsListe.SingleOrDefault(r => r.TitelDesSpiels == Titel);
            if(!File.Exists(SpielZuÖffnen.InstallationsPfad))
            {
                throw new FileNotFoundException("Bruh, dieses Spiel existiert an diesem Ort nicht");
            }
            if(SpielZuÖffnen.InstallationsPfad.Length == 0)
            {

            }
            Process.Start(SpielZuÖffnen.InstallationsPfad);
        }

        public void SpielLöschen(string Titel)
        {
            if(!ParameterDesSpielsListe.Any())
            {
                throw new ArgumentException("Es gibt nichts zum löschen, da die liste leer ist");
            }
            var ItemZuLöschen = ParameterDesSpielsListe.SingleOrDefault(r => r.TitelDesSpiels == Titel);
            ParameterDesSpielsListe.Remove(ItemZuLöschen);
            ListeSollLeerSein = true;
        }

        public void SpielLaden(List<ParameterDesSpiels> list)
        {
            if (!list.Any() && ListeSollLeerSein == false)
            {
                throw new ArgumentNullException("Die Liste die du laden willst existiert nicht, bruh");     
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"..\..\SpieleListe.xml");
                XmlElement root = doc.DocumentElement;
                foreach (XmlNode daten in root.ChildNodes)
                {
                    list.Add(new ParameterDesSpiels()
                    {
                        TitelDesSpiels = daten.Attributes["Titel"].InnerText.Replace("_", " "),
                        InstallationsDatum = daten.Attributes["Installations_Datum"].InnerText.Replace("_", " "),
                        ZuletztGespielt = daten.Attributes["ZuletztGespielt"].InnerText.Replace(" ", "_"),
                        InstallationsPfad = daten.Attributes["InstallationsPfad"].InnerText.Replace(" ", "_"),
                        Kategorie = daten.Attributes["Kategorie"].InnerText.Replace(" ", "_"),
                        Publisher = daten.Attributes["Publisher"].InnerText.Replace(" ", "_"),
                        UskEinstufung = Convert.ToInt32(daten.Attributes["UskEinstufung"].InnerText.Replace(" ", "_"))
                    });
                }
            }
        }
    }
}