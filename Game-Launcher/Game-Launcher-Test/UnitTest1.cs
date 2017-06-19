using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var spielhinzufügen = new SpieleMethoden();
            spielhinzufügen.SpielHinzufügen("GTA 5","17.06.2017","18.06.2017","Hier",null,"PhilippGames",5);
        }
        [TestMethod]
        public void Ist_Die_Liste_befüllt_worden_Testmethod()
        {
            var spielhinzufügen = new SpieleMethoden();
            ParameterDesSpiels spiel = new ParameterDesSpiels();
            spielhinzufügen.SpielHinzufügen("GTA 5", "17.06.2017", "18.06.2017", "Hier", "MOBA", "PhilippGames", 6);
            Assert.AreEqual("GTA 5", spielhinzufügen.ParameterDesSpielsListe[0].TitelDesSpiels);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Save_list_is_Null_Throws_ArgumentNullException_Testmethod()
        {
            ParameterDesSpiels spiel = new ParameterDesSpiels();
            var spielspeichern = new SpieleMethoden();
            spielspeichern.SpielSpeichern(spielspeichern.ParameterDesSpielsListe);
        }

        [TestMethod]
        public void Die_Liste_mit_XML_Speichern_TestMethod()
        {
            
        }
    }
}
