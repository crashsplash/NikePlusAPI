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
    public class ListActivitiesFixture
    {
        [TestMethod]
        public void SportDataReceived()
        {
            ListActivities activitiesData = new ListActivities();
            activitiesData.Token = Config.SampleToken;

            ListActivities.APIEntities.RootObject result = activitiesData.GetActivityList().Result;

            Assert.IsTrue(result.data.Count > 0, "No Data Received");
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
