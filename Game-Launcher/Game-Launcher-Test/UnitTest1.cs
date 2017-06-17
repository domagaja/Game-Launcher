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
        public void No_Game_Added_Throws_ArgumentNullException_TestMethod()
        {
            var spielhinzufügen = new SpieleMethoden();
            spielhinzufügen.SpielHinzufügen("GTA 5","17.06.2017","18.06.2017","Hier","MOBA","PhilippGames",1);
            Assert.AreEqual(spiel, "GTA 5", "17.06.2017", "18.06.2017", "Hier", "MOBA", "PhilippGames", 1);
        }
    }
}
