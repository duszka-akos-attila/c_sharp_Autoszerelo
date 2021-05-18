using MechanicClient.ViewModels;
using System;
using System.Windows.Input;

namespace MechanicClient.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel mainViewModel;

        private AvailableJobsViewModel availableJobsViewModel;

        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public UpdateViewCommand(MainViewModel mainViewModel, AvailableJobsViewModel availableJobsViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.availableJobsViewModel = availableJobsViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "AvailableJobs")
            {
                if (availableJobsViewModel == null)
                {
                    mainViewModel.SelectedViewModel = new AvailableJobsViewModel(mainViewModel);
                }
                else
                {
                    mainViewModel.SelectedViewModel = availableJobsViewModel;
                }
            }
            else if (parameter.ToString() == "AvailableJobsNew")
            {
                mainViewModel.SelectedViewModel = new AvailableJobsViewModel(mainViewModel);
            }
            else if (parameter.ToString() == "Job")
            {
                if (availableJobsViewModel.GetSelectedJob() != null)
                {
                    mainViewModel.SelectedViewModel = new JobViewModel(mainViewModel, availableJobsViewModel);
                }
            }
        }
    }
}
