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
        XmlDocument doc = new XmlDocument();
        public bool ErstesLaden =true;
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

        public void SpielStarten(string installpfad)
        {
        //    var SpielZuÖffnen = ParameterDesSpielsListe.SingleOrDefault(r => r.TitelDesSpiels == Titel);
            if(!File.Exists(installpfad))
            {
                throw new FileNotFoundException("Bruh, dieses Spiel existiert an diesem Ort nicht");
            }
            Process.Start(installpfad);
        }

        public void SpielLöschen(int index)
        {
            if (index > ParameterDesSpielsListe.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
            ParameterDesSpielsListe.RemoveAt(index);
             ListeSollLeerSein = true;
        }

        public void SpielLaden(List<ParameterDesSpiels> list)
        {     
            XmlDocument doc = new XmlDocument();
            if(!File.Exists(@"..\..\SpieleListe.xml"))
            {
                throw new FileNotFoundException("bruh, die Liste ist leer");
            }
                try
                {
                    if(ErstesLaden == true)
                    {
                    try
                    {
                        doc.Load(@"..\..\SpieleListe.xml");
                        ErstesLaden = false;
                        
                    }
                    catch
                    {
                        ErstesLaden = false;
                        return;
                    }
                        
                    }
                    if(ListeSollLeerSein==true)
                    {
                        doc.Load(@"..\..\SpieleListe.xml");
                    }
               doc.Load(@"..\..\SpieleListe.xml");
            }
                catch
                {
                    throw new XmlException();
                }
            XmlElement root =  doc.DocumentElement;
            list = ParameterDesSpielsListe;
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