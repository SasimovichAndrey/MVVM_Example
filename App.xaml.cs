﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using MVVM_Example.ViewModel;
using MVVM_Example.Command;

namespace MVVM_Example
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MVVM_Example.View.MainWindow window = new MVVM_Example.View.MainWindow();

            var viewModel = new MainWindowViewModel();

            viewModel.RequestClose += delegate
            {
                window.Close();
            };

            window.MainWindowGrid.DataContext = viewModel;

            window.Show();
        }
    }
}
