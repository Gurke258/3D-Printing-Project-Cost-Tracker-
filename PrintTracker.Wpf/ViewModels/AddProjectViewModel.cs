using PrintTracker.Common;
using PrintTracker.Core;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PrintTracker.Wpf.ViewModels
{
    public class AddProjectViewModel : ViewModelBase
    {
        private PrintProject _newProject;
        public ICommand SaveCommand { get; }
        public PrintProject NewProject
        {
            get => _newProject;
            set => SetProperty(ref _newProject, value);
        }

        public AddProjectViewModel()
        {
            NewProject = new PrintProject { };
            SaveCommand = new RelayCommand(SaveProject);
        }

        private void SaveProject(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(NewProject.Name))
            {
                MessageBox.Show("Bitte geben Sie einen Projektnamen ein.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var window = parameter as Window;
            window.DialogResult = true;
        }

    }
}
