using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests
{
    [TestClass]
    public class APIClientFixture
    {
        [TestMethod]
        public void CheckMissingTokenAssignment()
        {
            NikePlusAPI.APIClient apiClient = new NikePlusAPI.APIClient();

            Assert.IsTrue(!apiClient.Client.DefaultRequestHeaders.Contains("access_token"),"Token should not be existing");
            Assert.IsTrue(string.IsNullOrEmpty(apiClient.Token), "Token should not be existing");

            apiClient.Token = "";
            Assert.IsTrue(!apiClient.Client.DefaultRequestHeaders.Contains("access_token"), "Token should not be existing");
            Assert.IsTrue(string.IsNullOrEmpty(apiClient.Token), "Token should not be existing");
        }

        [TestMethod]
        public void CheckTokenAssignment()
        {
            string randomToken = Guid.NewGuid().ToString();

            NikePlusAPI.APIClient apiClient = new NikePlusAPI.APIClient(randomToken);

            Assert.IsTrue(apiClient.Client.DefaultRequestHeaders.GetValues("access_token").FirstOrDefault() == randomToken, "Token value is wrong.");
            Assert.IsTrue(apiClient.Token == randomToken, "Token value is wrong.");

            randomToken = Guid.NewGuid().ToString();

            apiClient.Token = randomToken;
            Assert.IsTrue(apiClient.Client.DefaultRequestHeaders.GetValues("access_token").FirstOrDefault() == randomToken, "Token value is wrong.");
            Assert.IsTrue(apiClient.Token == randomToken, "Token value is wrong.");
        }

    }
}
