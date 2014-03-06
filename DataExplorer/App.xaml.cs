﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Core.Events;
using DataExplorer.Presentation.Shell.MainWindow;
using Ninject;
using Ninject.Extensions.Conventions;

namespace DataExplorer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private static IKernel _kernel;

        public App()
        {
            InitializeDependencyInjection();

            InitializeBuses();

            InitializeShell();
        }

        private static void InitializeDependencyInjection()
        {
            _kernel = new StandardKernel();
            _kernel.Load("DataExplorer*.dll");
            _kernel.Bind(p => p.FromAssembliesMatching(new []{ "DataExplorer*.dll" })
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(c => c.InSingletonScope()));
        }

        private static void InitializeBuses()
        {
            CommandBus.Kernel = _kernel;
            QueryBus.Kernel = _kernel;
            EventBus.Kernel = _kernel;
            DomainEvents.Kernel = _kernel;
        }
        
        private static void InitializeShell()
        {
            var mainWindow = _kernel.Get<IMainWindow>();
            var mainWindowViewModel = _kernel.Get<MainWindowViewModel>();
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
        }
    }
}
