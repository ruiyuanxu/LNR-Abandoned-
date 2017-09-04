using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Core;
using System.IO;

namespace UnitTest_LineGlobalandBooks
{
    [TestClass]
    public class GlobalConstantsTest
    {
        [TestMethod]
        public void find_cnfTest()
        {
            
            Assert.AreEqual(@"C:\Users\瑞元\AppData\Roaming", Global.global_appdata());
        }

        [TestMethod]
        public void corecnfTest()
        {
            var fi = Global.global_core_cfg();
            FileStream fs = new FileStream(Global.global_appdata() + @"C:\Users\瑞元\AppData\Roaming\LightNovelReader\core.cnf", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            var str = sr.ReadLine();
            Assert.AreEqual("haha", str);
        }
    }
}
