using PrintTracker.Common;
using PrintTracker.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Windows.Input;

namespace PrintTracker.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<PrintProject> PrintProjects { get; } = new();
        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand SaveCommand { get; }
        private readonly IStorageService _storageService;
        private readonly IDialogService _dialogService;



        private PrintProject? _selectedProject;
        public PrintProject? SelectedProject
        {
            get => _selectedProject;
            set => SetProperty(ref _selectedProject, value);
        }

        public MainViewModel(IStorageService storageService, IDialogService dialogService)
        {
            DeleteCommand = new RelayCommand(DeleteProject, CanDeleteProject);
            AddCommand = new RelayCommand(AddProject);
            SaveCommand = new RelayCommand(SaveProjects);
            _storageService = storageService;
            _dialogService = dialogService;
            LoadProjects();
        }

        private bool CanDeleteProject(object? parameter)
        {
            // Löschen nur erlauben, wenn ein Projekt ausgewählt ist
            return SelectedProject != null;
        }

        private void SaveProjects(object? parameter)
        {
            _storageService.SaveData(PrintProjects);
        }

        private void LoadProjects()
        {
            var loadedProjects = _storageService.LoadData<ObservableCollection<PrintProject>>();
            if (loadedProjects != null)
            {
                PrintProjects.Clear();
                foreach (var project in loadedProjects)
                {
                    PrintProjects.Add(project);
                }
            }
            else
            {
                // Wenn keine Daten geladen werden konnten, werden Testdaten geladen
                LoadTestData();
            }
        }

        private void AddProject(object? parameter)
        {

            var newProject = _dialogService.ShowAddProjectDialog();
            if (newProject != null)
            {
                PrintProjects.Add(newProject);
            }

        }

        private void DeleteProject(object? parameter)
        {
            if (SelectedProject != null)
            {
                PrintProjects.Remove(SelectedProject);
                SelectedProject = null;
            }
        }

        private void LoadTestData()
        {
            // Beispielhafte Daten zum Testen
            PrintProjects.Add(new PrintProject
            {
                Name = "Testprojekt 1",
                FilePath = "C:\\Prints\\test1.gcode",
                PrintedAt = DateTime.Now.AddDays(-2),
                LastModifiedAt = DateTime.Now.AddDays(-3),
                PrinterUsed = "Prusa i3 MK3S",
                FilamentUsed = "PLA - Rot",
                PrintDurationHours = TimeSpan.FromHours(5),
                ElectricityPrice = 1.50m,
                FilamentPrice = 11.66m,
                PrintResult = true
            });

            PrintProjects.Add(new PrintProject
            {
                Name = "Testprojekt 2",
                FilePath = "C:\\Prints\\test2.gcode",
                PrintedAt = DateTime.Now.AddDays(-5),
                LastModifiedAt = DateTime.Now.AddDays(-6),
                PrinterUsed = "Ender 3 Pro",
                FilamentUsed = "PETG - Blau",
                PrintDurationHours = TimeSpan.FromHours(3.5),
                ElectricityPrice = 1.00m,
                FilamentPrice = 19.95m,
                PrintResult = false
            });

            PrintProjects.Add(new PrintProject
            {
                Name = "Testprojekt 3",
                FilePath = "C:\\Prints\\test3.gcode",
                PrintedAt = DateTime.Now.AddDays(-7),
                LastModifiedAt = DateTime.Now.AddDays(-2),
                PrinterUsed = "Ender 3 Pro",
                FilamentUsed = "PETG - Blau",
                PrintDurationHours = TimeSpan.FromHours(2),
                ElectricityPrice = 1.00m,
                FilamentPrice = 24.99m,
                PrintResult = true
            });
        }


    }
}