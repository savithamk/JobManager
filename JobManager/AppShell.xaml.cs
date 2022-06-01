using System;
using System.Collections.Generic;
using Xamarin.Forms;
using JobManager.Views;

namespace JobManager
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {

            InitializeComponent();
            Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));

            Routing.RegisterRoute(nameof(JobListPage), typeof(JobListPage));


        }


    }
}
