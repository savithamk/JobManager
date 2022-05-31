﻿using System;
using JobManager.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobManager
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<JobDataStoreLocalJson>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
