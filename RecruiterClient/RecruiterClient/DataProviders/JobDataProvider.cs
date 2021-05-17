using Newtonsoft.Json;
using RecruiterClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterClient.DataProviders
{
    class JobDataProvider
    {
        private const string _url = "http://localhost:5000/api/job";

        public static IEnumerable<DatabaseJobList> GetJobs()
        {
            using(var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if(response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var jobs = JsonConvert.DeserializeObject<IEnumerable<DatabaseJobList>>(rawData);

                    return jobs;
                }
                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void CreateJob(DatabaseJob job)
        {
            using(var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(job);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdateJob(long id, DatabaseJob job)
        {
            using(var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(job);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync($"{_url}/{id}", content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
