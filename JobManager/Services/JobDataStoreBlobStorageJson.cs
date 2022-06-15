using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using JobManager.Models;
using Newtonsoft.Json;

namespace JobManager.Services
{
    class JobDataStoreBlobStorageJson : IJobDataStore<Job>
    {

        private static string ConnectionString => "";

        private static string Container => "data";

        private static string FileName => "Jobs.json";

        private readonly BlobServiceClient serviceClient = new BlobServiceClient(ConnectionString);

        public async Task WriteFile(List<Job> jobs)
        {
            var jsonString = JsonConvert.SerializeObject(jobs);

            var stream = new MemoryStream();

            var writer = new StreamWriter(stream);
            writer.Write(jsonString);

            writer.Flush();

            stream.Position = 0;
            BlobClient blob = serviceClient.GetBlobContainerClient(Container).GetBlobClient(FileName);

            await blob.UploadAsync(stream);

        }

        public async Task<List<Job>> ReadFile()
        {

            BlobClient blob = serviceClient.GetBlobContainerClient(Container).GetBlobClient(FileName);
            if (blob.Exists())
            {
                var stream = new MemoryStream();
                await blob.DownloadToAsync(stream);
                stream.Position = 0;
                var jsonString = new StreamReader(stream).ReadToEnd();

                var jobs = JsonConvert.DeserializeObject<List<Job>>(jsonString);
                return jobs;
            }
            else
            {
                var defaultJobs = GetDefaultJobs();
                await WriteFile(defaultJobs);
                return defaultJobs;
            }
        }

        private List<Job> GetDefaultJobs()
        {

            var jobs = new List<Job>()
            {
                new Job {Id = 1, Name = "Job A Local Json File", Description = "This is job a."},
                new Job {Id = 2, Name = "Job B Local Json File", Description = "This is job b."},
                new Job {Id = 3, Name = "Job C Local Json File", Description = "This is job c."},
                new Job {Id = 4, Name = "Job D Local Json File", Description = "This is job d."}


            };
            return jobs;
        }

        public async Task AddJob(Job job)
        {
            var jobs = await ReadFile();
            jobs.Add(job);
            WriteFile(jobs);
        }

        public async Task DeleteJob(Job job)
        {
            var jobs = await ReadFile();
            var remove = jobs.Find(p => p.Id == job.Id);

            jobs.Remove(remove);
        }

        public async Task<Job> GetJob(int id)
        {
            var jobs = await ReadFile();
            var job = jobs.Find(p => p.Id == id);
            return job;

        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            var jobs = await ReadFile();
            return jobs;
        }

        public async Task UpdateJob(Job job)
        {
            var jobs = await ReadFile();
            jobs[jobs.FindIndex(p => job.Id == job.Id)] = job;
            WriteFile(jobs);
        }
    }
}
