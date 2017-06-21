using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace Game_Launcher_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }
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
            spiel.SpielHinzufügen("GTA 5", "17.06.2017", "18.06.2017", @"C:\Riot Games\League of Legends\lol.launcher.exe", "MOBA", "PhilippGames", 6);
            Assert.AreEqual("GTA 5", spiel.ParameterDesSpielsListe[0].TitelDesSpiels);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Save_list_is_Null_Throws_ArgumentNullException_Testmethod()
        {
            var spiel = new SpieleMethoden();
            List<ParameterDesSpiels> ParameterDesSpielsListe = new List<ParameterDesSpiels>();
            spiel.SpielSpeichern(ParameterDesSpielsListe);
        }

        [TestMethod]
        public void Die_Liste_mit_XML_Speichern_TestMethod()
        {
            var spiel = new SpieleMethoden();
            spiel.SpielHinzufügen("GTA 5", "17.06.2017", "18.06.2017", @"C:\Riot Games\League of Legends\lol.launcher.exe", "MOBA", "PhilippGames", 6);
            spiel.SpielHinzufügen("Metin 2", "20.06.2017", "21.06.2017", @"C:\Riot Games\League of Legends\lol.launcher.exe", "MMORPG", "Vincesco", 12);
            spiel.SpielHinzufügen("Tibia", "14.06.1995", "07.06.2017", @"C:\Riot Games\League of Legends\lol.launcher.exe", "MMORPG", "Cipsoft", 12);
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
            spiel.SpielLaden(spiel.ParameterDesSpielsListe);
        }
    }
}
