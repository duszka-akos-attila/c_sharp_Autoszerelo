using RecruiterClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecruiterClient.Commands
{
    public class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainViewModel mainViewModel;

        private RegisteredJobsViewModel registeredJobsViewModel;

        private JobViewModel jobViewModel;

        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
        public UpdateViewCommand(MainViewModel mainViewModel, RegisteredJobsViewModel registeredJobsViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.registeredJobsViewModel = registeredJobsViewModel;
        }

        public UpdateViewCommand(MainViewModel mainViewModel, RegisteredJobsViewModel registeredJobsViewModel, JobViewModel jobViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.registeredJobsViewModel = registeredJobsViewModel;
            this.jobViewModel = jobViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "RegisteredJobs")
            {
                if (registeredJobsViewModel == null)
                {
                    mainViewModel.SelectedViewModel = new RegisteredJobsViewModel(mainViewModel);
                }
                else
                {
                    mainViewModel.SelectedViewModel = registeredJobsViewModel;
                }
            }
            else if (parameter.ToString() == "RegisteredJobsNew")
            {
                mainViewModel.SelectedViewModel = new RegisteredJobsViewModel(mainViewModel);
            }
            else if (parameter.ToString() == "Job")
            {
                if (registeredJobsViewModel.GetSelectedJob() != null && jobViewModel == null)
                {
                    mainViewModel.SelectedViewModel = new JobViewModel(mainViewModel, registeredJobsViewModel);
                }
                else if (registeredJobsViewModel.GetSelectedJob() != null && jobViewModel != null)
                {
                    mainViewModel.SelectedViewModel = jobViewModel;
                }
            }
            else if (parameter.ToString() == "Add")
            {
                mainViewModel.SelectedViewModel = new AddViewModel(mainViewModel);
            }
            else if (parameter.ToString() == "Main")
            {
                mainViewModel.SelectedViewModel = mainViewModel;
            }
        }
    }
}
