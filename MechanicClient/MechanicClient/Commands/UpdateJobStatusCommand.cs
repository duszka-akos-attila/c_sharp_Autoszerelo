using MechanicClient.ViewModels;
using System;
using System.Windows.Input;

namespace MechanicClient.Commands
{
    class UpdateJobStatusCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private AvailableJobsViewModel availableJobsViewModel;

        public UpdateJobStatusCommand(AvailableJobsViewModel availableJobsViewModel)
        {
            this.availableJobsViewModel = availableJobsViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            availableJobsViewModel.SetSelectedJobStatus(parameter.ToString());
        }
    }
}
