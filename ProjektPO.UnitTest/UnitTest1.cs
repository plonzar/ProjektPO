using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjektPO.Model;
using System.Data.Entity;
using System.Linq;
using Moq;

namespace ProjektPO.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void GetData()
        {
               
        }
    }
}
