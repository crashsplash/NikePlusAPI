using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NikePlusAPI
{
    //Documentation: https://developer.nike.com/activities/list_users_activities
    public class ListActivities
    {
        public string Token { get; set; }

        public async Task<APIEntities.RootObject> GetActivityList()
        {
            APIEntities.RootObject rootResult;

            HttpClient aClient = new APIClient(Token).Client;

            var result = await aClient.GetAsync(string.Format(APIUris.ListActivities, Token));
            if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
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
            public class MetricSummary
            {
                //Number of calories burned during the Activity
                public int calories { get; set; }
                //Amount of fuel gained during the Activity
                public int fuel { get; set; }
                //Distance traveled during the Activity
                public double distance { get; set; }
                //Number of steps taken during the Activity
                public int steps { get; set; }
                //The amount of time the Activity lasted in standard ISO8601 format
                public string duration { get; set; }
            }

            public class Datum
            {
                //The sport activity unique identifier
                public string activityId { get; set; }
                //Type of tag
                public string activityType { get; set; }
                //The Activity's start time in UTC, standard ISO8601 format
                public string startTime { get; set; }
                //Timezone the Activity was captured in
                public string activityTimeZone { get; set; }
                //The status of the activity. IE: IN_PROGRESS, COMPLETED
                public string status { get; set; }
                //The status of the activity. IE: IN_PROGRESS, COMPLETED
                public string deviceType { get; set; }
                public MetricSummary metricSummary { get; set; }
                //Extra detail User entered about the Activity
                public List<object> tags { get; set; }
                public List<object> metrics { get; set; }
            }

            public class Paging
            {
                //The URI and query parameters for the next page of results in the list
                public string next { get; set; }
                //The URI and query parameters for the previous page of results in the list
                public string previous { get; set; }
            }

            public class RootObject
            {
                //The list of the User's Activities
                public List<Datum> data { get; set; }
                public Paging paging { get; set; }
                public string error { get; set; }
            }
        }
    }
}
