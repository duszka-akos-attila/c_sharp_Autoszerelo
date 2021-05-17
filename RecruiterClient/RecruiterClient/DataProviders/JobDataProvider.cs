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

        public static IEnumerable<Job> GetJobs()
        {
            using(var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if(response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var jobsFromDatabase = JsonConvert.DeserializeObject<IEnumerable<DatabaseJobList>>(rawData);
                    List<Job> jobs = new List<Job>();

                    foreach(DatabaseJobList databaseJob in jobsFromDatabase)
                    {
                        jobs.Add(new Job(databaseJob));
                    }

                    return jobs;
                }
                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void CreateJob(Job job)
        {
            using(var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(new DatabaseJob(job));
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdateJob(long id, Job job)
        {
            using(var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(new DatabaseJob(job));
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
