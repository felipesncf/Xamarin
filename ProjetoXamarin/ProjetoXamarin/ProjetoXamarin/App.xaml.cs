﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjetoXamarin.Services;
using ProjetoXamarin.Views;

namespace ProjetoXamarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

#if DEBUG
            HotReloader.Current.Run(this);
#endif
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
