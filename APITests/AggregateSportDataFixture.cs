using Microsoft.VisualStudio.TestTools.UnitTesting;
using NikePlusAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests
{
    [TestClass]
    public class AggregateSportDataFixture
    {
        [TestMethod]
        public void SportDataReceived()
        {
            AggregateSportData sportData = new AggregateSportData();
            sportData.Token = Config.SampleToken;

            AggregateSportData.APIEntities.RootObject result = sportData.GetSportData().Result;

            Assert.IsTrue(result.experienceTypes.Count > 0, "No Experience Received");
            Assert.IsTrue(!string.IsNullOrEmpty(result.experienceTypes.FirstOrDefault()), "No Experience Received");
        }

        [TestMethod]
        public void SportDataTokenFailure()
        {
            AggregateSportData sportData = new AggregateSportData();
            sportData.Token = "";

            AggregateSportData.APIEntities.RootObject result = sportData.GetSportData().Result;

            Assert.IsTrue(result.error == "invalid_token", "Token invalidation failed.");
        }
    }
}
