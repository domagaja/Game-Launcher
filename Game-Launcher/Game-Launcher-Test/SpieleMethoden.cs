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
       public List<ParameterDesSpiels> ParameterDesSpielsListe = new List<ParameterDesSpiels>();
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
        public void XMLDocumentErstellen_Laden()
        {

            XmlDocument doc = new XmlDocument();            //Instanz eines XML Dokuments in den RAM laden
            XmlNode myRoot;                                 //Neue Instanz eines XML Knotens reservieren
            myRoot = doc.CreateElement("HelloXMLWorld");    //XML Element "HelloXMLWorld" in den Reservierten Knoten laden
            doc.AppendChild(myRoot);                        //Knoten direkt an das XML Dokument anheften (Root Element)
            doc.Save(@"helloxmlworld.xml");              //Speichern des im RAM liegenden XML Dokuments
        }
        
        
        public List<ParameterDesSpiels> ParameterDesSpielsListe;
        internal ParameterDesSpiels _spiel;
        public void XmlSpeichern()
        {
            XMLDocumentErstellen_Laden();
        }

        public SpieleMethoden()
        {

        }

        internal void SpielHinzufügen(string Titel, string Install_Datum, string Zuletzt_Gespielt, string Install_Pfad, string kategorie, string publisher, int Usk_Einstufung)
        {
            if (Titel == null || Install_Datum == null || Zuletzt_Gespielt == null || Install_Pfad == null || kategorie == null|| publisher == null || Usk_Einstufung != 0  && Usk_Einstufung != 6 && Usk_Einstufung != 12 && Usk_Einstufung != 16 && Usk_Einstufung != 18)
            {
                throw new ArgumentNullException("Bruh, es gibt nichts zum Hinzufügen.");
            }
            Spiel.ParameterDesSpielsListe.Add(new ParameterDesSpiels()
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
            //  XmlSpeichern();

            XmlDocument doc = new XmlDocument();
            XmlNode myRoot;
            doc.AppendChild(myRoot = doc.CreateElement("Spiele"));
            for (int i = 0; i < list.Count; i++)
            {
                myRoot.AppendChild(doc.CreateElement(list[i].TitelDesSpiels.Replace(" ", "_")));
            }
            // myRoot.AppendChild(doc.CreateElement(list[0].TitelDesSpiels.Replace(" ", "_")));

            //  myRoot.AppendChild(doc.CreateElement("zweitesSpiel"));
            //  myRoot.SelectSingleNode("ErstesSpiel").Attributes.Append(doc.CreateAttribute("Titel")).InnerText = "GTA 5";
            //  myRoot.SelectSingleNode("ErstesSpiel").Attributes.Append(doc.CreateAttribute("Zuletztgespielt")).InnerText = "14.06.2017";
            doc.Save(@"..\..\SpieleListe.xml");
        }
    }
}