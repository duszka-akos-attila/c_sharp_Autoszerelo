using RecruiterClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecruiterClient.Commands
{
    class EditJobCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private JobViewModel jobViewModel;
        private MainViewModel mainViewModel;
        private RegisteredJobsViewModel registeredJobsViewModel;
        private ICommand UpdateViewCommand;

        public EditJobCommand(MainViewModel mainViewModel, RegisteredJobsViewModel registeredJobsViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.registeredJobsViewModel = registeredJobsViewModel;
            this.UpdateViewCommand = new UpdateViewCommand(mainViewModel, registeredJobsViewModel);
        }
        public EditJobCommand(MainViewModel mainViewModel, RegisteredJobsViewModel registeredJobsViewModel, JobViewModel jobViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.registeredJobsViewModel = registeredJobsViewModel;
            this.jobViewModel = jobViewModel;
            this.UpdateViewCommand = new UpdateViewCommand(mainViewModel, registeredJobsViewModel, jobViewModel);
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Edit")
            {
                if (jobViewModel != null)
                {
                    jobViewModel.ToggleJobEditModeGui();
                }
                else
                {
                    jobViewModel = new JobViewModel(mainViewModel, registeredJobsViewModel,true);
                    UpdateViewCommand.Execute("Job");
                }

            }
            else if (parameter.ToString() == "DiscardChanges")
            {
                if (jobViewModel.IsJobChanged())
                {
                    if (jobViewModel.DisplayConfirmActionMessageBox("Are you sure, you want to discard all your change(s)?", "Discard Change(s)"))
                    {
                        jobViewModel.ToggleJobEditModeGui();
                        jobViewModel.ResetJob();
                    }
                }
                else
                {
                    jobViewModel.ToggleJobEditModeGui();
                    jobViewModel.ResetJob();
                }

            }
            else if (parameter.ToString() == "Cancel")
            {
                if (jobViewModel.IsJobChanged())
                {
                    if (jobViewModel.DisplayConfirmActionMessageBox("Are you sure, you want to discard all your change(s)?", "Discard Change(s)"))
                    {
                        jobViewModel.UpdateViewCommand.Execute("RegisteredJobs");
                    }
                }
                else
                {
                    jobViewModel.UpdateViewCommand.Execute("RegisteredJobs");
                }
            }
            else if (parameter.ToString() == "SaveChanges")
            {
                jobViewModel.ToggleJobEditModeGui();
                jobViewModel.SaveJob();
            }
        }
    }
}
