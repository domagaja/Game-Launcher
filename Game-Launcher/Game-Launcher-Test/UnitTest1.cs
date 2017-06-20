using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            spiel.SpielHinzufügen("GTA 5", "17.06.2017", "18.06.2017", "Hier", "MOBA", "PhilippGames",6);
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
            spiel.SpielHinzufügen("GTA 5", "17.06.2017", "18.06.2017", "Hier", "MOBA", "PhilippGames",6);
            spiel.SpielHinzufügen("GTA 6", "17.06.2017", "18.06.2017", "Hier", "MOBA", "PhilippGames", 6);
            spiel.SpielSpeichern(spiel.ParameterDesSpielsListe);
        }
    }
}
