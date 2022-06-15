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

        private static string ConnectionString => "DefaultEndpointsProtocol=https;AccountName=052022jobmanager;AccountKey=lRAoAesneyu2nrer0QCBC+GnOUhAtxYTqMj+tClvHRYmZIDTzTgSxqIEoFL3TjzS7wctPdLMM0oO+AStTGnmWA==;EndpointSuffix=core.windows.net";

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

        public async Task AddJob(Job job)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteJob(Job job)
        {
            throw new NotImplementedException();
        }

        public async Task<Job> GetJob(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateJob(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
