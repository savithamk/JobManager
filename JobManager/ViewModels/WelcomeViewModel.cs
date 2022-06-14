using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobManager.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace JobManager.ViewModels
{
    public class WelcomeViewModel : JobManagerBase
    {
        public WelcomeViewModel()
        {
            Title = "Welcome";
        }
    }
}
