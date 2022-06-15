using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using JobManager.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace JobManager.ViewModels
{
    [QueryProperty(nameof(JobId), nameof(JobId))]
    public class JobDetailViewModel : JobManagerBase
    {
        public AsyncCommand PageAppearingCommand { get;  }

        private int jobId;

        private string name;

        private string description;

        public int JobId
        {
            get => jobId;
            set => SetProperty(ref jobId, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }


        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }


        public JobDetailViewModel()
        {

            PageAppearingCommand = new AsyncCommand(PageAppearing);
        }


        async Task PageAppearing()
        {
           await LoadJob(jobId);
        }


        public async Task LoadJob(int jobId)
        {
            try
            {
                Job job = await JobDataStore.GetJob(jobId);
                JobId = job.Id;
                Name = job.Name;
                Description = job.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        
    }
}
