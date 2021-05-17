using MechanicClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MechanicClient.DataProviders
{
    class JobDataProvider
    {
        private const string _url = "http://localhost:5000/api/job";
        public static IEnumerable<Job> GetJobs()
        {
            using(var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var jobsFromServer = JsonConvert.DeserializeObject<IEnumerable<DatabaseJob>>(rawData);

                    var jobs = new List<Job>();
                    foreach(DatabaseJob databaseJob in jobsFromServer)
                    {
                        jobs.Add(new Job(databaseJob));
                    }

                    return jobs;
                    
                }
                throw new InvalidOperationException(response.StatusCode.ToString());

            }
        }

        public static void UpdateState(long id, String state)
        {
            using (var client = new HttpClient())
            {
                var response = client.PutAsync($"{_url}/state/{id}?state={state}", null).Result;

                if(!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
