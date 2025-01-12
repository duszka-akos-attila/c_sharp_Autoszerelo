﻿using MechanicClient.Commands;
using System.Windows.Input;

namespace MechanicClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
