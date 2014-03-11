using System;
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

            // Create the ViewModel to which 
            // the main window binds.
            string path = "Data/customers.xml";
            var viewModel = new MainWindowViewModel(path);
            CommandViewModel cvModel = new CommandViewModel("CommandName", new RelayCommand(o => {}));
            viewModel.Commands.Add(cvModel);

            // When the ViewModel asks to be closed, 
            // close the window.
            viewModel.RequestClose += delegate
            {
                window.Close();
            };

            // Allow all controls in the window to 
            // bind to the ViewModel by setting the 
            // DataContext, which propagates down 
            // the element tree.
            window.MainWindowGrid.DataContext = viewModel;

            window.Show();
        }
    }
}
