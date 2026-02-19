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
        public ICommand BrowseFileCommand { get; }

        public List<string> FilamentTypes { get; } = new List<string> { "PLA", "ABS", "PETG", "TPU", "Nylon", "Polycarbonat", "HIPS", "PVA", "ASA", "Wood Filament", "Metal Filament" };

        public List<string> Printers { get; } = new List<string> { "FDM", "SLA", "DLP", "SLS", "PolyJet", "Binder Jetting", "Material Jetting", "Electron Beam Melting (EBM)", "Direct Energy Deposition (DED)" };

        public PrintProject NewProject
        {
            get => _newProject;
            set => SetProperty(ref _newProject, value);
        }

        public AddProjectViewModel()
        {
            NewProject = new PrintProject { };
            SaveCommand = new RelayCommand(SaveProject);
            BrowseFileCommand = new RelayCommand(BrowseFile);
            NewProject.PrintedAt = DateTime.Now;
            NewProject.LastModifiedAt = DateTime.Now;
            
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

        private void BrowseFile(object? parameter)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "G-Code Dateien (*.gcode;*.gc;*.g)|*.gcode;*.gc;*.g|Alle Dateien (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                NewProject.FilePath = openFileDialog.FileName;
            }
        }

        

    }
}
