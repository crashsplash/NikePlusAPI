using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NikePlusAPI
{
    //Documentation : https://developer.nike.com/activities/get_aggregate_sport_data
    public class AggregateSportData
    {
        public string Token { get; set; }

        public async Task<APIEntities.RootObject> GetSportData()
        {
            APIEntities.RootObject rootResult;

            HttpClient aClient = new APIClient(Token).Client;

            var result = await aClient.GetAsync(string.Format(APIUris.AggregatedSportData,Token));
            if(result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                rootResult = new APIEntities.RootObject();
                rootResult.error = "invalid_token";
            }
            else
            {
                rootResult = await result.Content.ReadAsAsync<APIEntities.RootObject>();
            }            

            return rootResult;
        }

        public class APIEntities
        {
            public class Record
            {
                //Type of Record ('LIFETIMEFUEL', for example)
                public string recordType { get; set; }
                //Record value as a string
                public string recordValue { get; set; }
            }

            public class Summary
            {
                //FUELBAND, RUNNING
                public string experienceType { get; set; }
                //Summaries of activities for each experienceType
                public List<Record> records { get; set; }
            }

            public class RootObject
            {
                public List<string> experienceTypes { get; set; }
                public List<Summary> summaries { get; set; }
                public string error { get; set; }
            }
        }
    }
}
