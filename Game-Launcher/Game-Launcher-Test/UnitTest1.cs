using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace Game_Launcher_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Game_Added_Parameter_is_Null_Throws_ArgumentNullException_TestMethod()
        {
            var spiel = new SpieleMethoden();
            spiel.SpielHinzufügen("GTA 5","17.06.2017","18.06.2017","Hier",null,"PhilippGames",5);
        }
        [TestMethod]
        public void Ist_Die_Liste_befüllt_worden_Testmethod()
        {

            var spiel = new SpieleMethoden();
            spiel.SpielHinzufügen("GTA 5", "17.06.2017", "18.06.2017", @"C:\League of Legends\leagueClient.exe", "MOBA", "PhilippGames", 6);
            Assert.AreEqual("GTA 5", spiel.ParameterDesSpielsListe[0].TitelDesSpiels);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Save_list_is_Null_Throws_ArgumentNullException_Testmethod()
        {
            var spiel = new SpieleMethoden();
            spiel.SpielSpeichern(spiel.ParameterDesSpielsListe);
        }

        [TestMethod]
        public void Die_Liste_mit_XML_Speichern_TestMethod()
        {
            var spiel = new SpieleMethoden();
            spiel.ParameterDesSpielsListe.Add(new ParameterDesSpiels()
            {
                TitelDesSpiels = "League of Legends",
                InstallationsDatum = "17.06.2017",
                ZuletztGespielt = "18.06.2017",
                InstallationsPfad = @"C:\League of Legends\leagueClient.exe",
                Kategorie = "MOBA",
                Publisher = "Riot Games",
                UskEinstufung = 12
            });
            spiel.ParameterDesSpielsListe.Add(new ParameterDesSpiels()
            {
                TitelDesSpiels = "Tibia",
                InstallationsDatum = "14.06.1997",
                ZuletztGespielt = "07.06.2017",
                InstallationsPfad = @"G:\Tibia\Tibia.exe",
                Kategorie = "MMORPG",
                Publisher = "CipSoft",
                UskEinstufung = 12
            });
            spiel.SpielSpeichern(spiel.ParameterDesSpielsListe);
            
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Im_InstallationsPfad_gibt_es_kein_Spiel_throws_FileNotFoundException()
        {
            SpieleMethoden spiel = new SpieleMethoden();
            spiel.SpielHinzufügen("Tibia", "14.06.1995", "07.06.2017", @"kakapipi", "MMORPG", "Cipsoft", 12);

        }

        [TestMethod]
        public void Die_XML_Datei_in_Liste_laden_Testmethod()
        {
            var spiel = new SpieleMethoden();
            // Spiel Hinzufügen
            spiel.ParameterDesSpielsListe.Add(new ParameterDesSpiels()
            {
                TitelDesSpiels = "League of Legends",
                InstallationsDatum = "17.06.2017",
                ZuletztGespielt = "18.06.2017",
                InstallationsPfad = @"C:\League of Legends\leagueClient.exe",
                Kategorie = "MOBA",
                Publisher = "Riot Games",
                UskEinstufung = 12
            });
            // Spielspeichern 
            XmlDocument doc = new XmlDocument();
            XmlNode myRoot;
            doc.AppendChild(myRoot = doc.CreateElement("Spiele"));
            for (int i = 0; i < spiel.ParameterDesSpielsListe.Count; i++)
            {
                myRoot.AppendChild(doc.CreateElement(spiel.ParameterDesSpielsListe[i].TitelDesSpiels.Replace(" ", "_")));
                myRoot.SelectSingleNode(spiel.ParameterDesSpielsListe[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("Titel")).InnerText = spiel.ParameterDesSpielsListe[i].TitelDesSpiels;
                myRoot.SelectSingleNode(spiel.ParameterDesSpielsListe[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("Installations_Datum")).InnerText = spiel.ParameterDesSpielsListe[i].InstallationsDatum;
                myRoot.SelectSingleNode(spiel.ParameterDesSpielsListe[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("ZuletztGespielt")).InnerText = spiel.ParameterDesSpielsListe[i].ZuletztGespielt;
                myRoot.SelectSingleNode(spiel.ParameterDesSpielsListe[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("InstallationsPfad")).InnerText = spiel.ParameterDesSpielsListe[i].InstallationsPfad;
                myRoot.SelectSingleNode(spiel.ParameterDesSpielsListe[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("Kategorie")).InnerText = spiel.ParameterDesSpielsListe[i].Kategorie;
                myRoot.SelectSingleNode(spiel.ParameterDesSpielsListe[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("Publisher")).InnerText = spiel.ParameterDesSpielsListe[i].Publisher;
                myRoot.SelectSingleNode(spiel.ParameterDesSpielsListe[i].TitelDesSpiels.Replace(" ", "_")).Attributes.Append(doc.CreateAttribute("UskEinstufung")).InnerText = spiel.ParameterDesSpielsListe[i].UskEinstufung.ToString();
            }
            doc.Save(@"..\..\SpieleListe.xml");
            spiel.ParameterDesSpielsListe.Clear();
            spiel.SpielLaden(@"..\..\SpieleListe.xml",spiel.ParameterDesSpielsListe);
            Assert.AreEqual("League of Legends",spiel.ParameterDesSpielsListe[0].TitelDesSpiels);
        }
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Liste_Zum_Laden_Nicht_Gefunden_Throws_FileNotFoundException()
        {
            var spiel = new SpieleMethoden();
            spiel.SpielLaden(@"..\..\SpieladeListe.xml", spiel.ParameterDesSpielsListe);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Element_aus_der_Liste_Löschen_throws_ArgumentException()
        {
            var spiel = new SpieleMethoden();
            spiel.SpielLöschen("Tibia");
        }
        [TestMethod]
        public void Element_Löschen_TestMethod()
        {
            var spiel = new SpieleMethoden();
            spiel.SpielHinzufügen("Tibia", "14.06.1995", "07.06.2017", @"C:\League of Legends\leagueClient.exe", "MMORPG", "Cipsoft", 12);
            spiel.SpielLöschen("Tibia");
            //   spiel.SpielSpeichern(spiel.ParameterDesSpielsListe);
            Assert.AreEqual(0, spiel.ParameterDesSpielsListe.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Spiel_Aus_einem_Nicht_existierenden_Pfad_Starten_throws_FileNotFoundException()
        {
            var spiel = new SpieleMethoden();
            spiel.SpielHinzufügen("Tibia", "14.06.1995", "07.06.2017", @"hansus", "MMORPG", "Cipsoft", 12);
            spiel.SpielStarten("Tibia");
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Spiel_besitzt_kein_Pfad_Throws_NullReferenceException()
        {
            var spiel = new SpieleMethoden();
            spiel.SpielStarten("Akte_X");
        }
        [TestMethod]
        public void Spiel_Starten_TestMethod()
        {
            var spiel = new SpieleMethoden();
            spiel.SpielHinzufügen("Tibia", "14.06.1995", "07.06.2017", @"C:\League of Legends\leagueClient.exe", "MMORPG", "Cipsoft", 12);
            spiel.SpielStarten("Tibia");
            Process currentProcess = Process.GetCurrentProcess();
            Assert.AreEqual("League of Legends (32 Bit)", currentProcess.StartInfo.FileName = "League of Legends (32 Bit)");
        }
    }
}
