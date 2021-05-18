using MechanicClient.ViewModels;
using System;
using System.Windows.Input;

namespace MechanicClient.Commands
{
    class EditJobCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private JobViewModel jobViewModel;

        public EditJobCommand(JobViewModel jobViewModel)
        {
            this.jobViewModel = jobViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Edit")
            {
                jobViewModel.ToggleJobEditModeGui();

            }
            else if (parameter.ToString() == "DiscardChanges")
            {
                if (jobViewModel.IsJobChanged())
                {
                    if (jobViewModel.DisplayConfirmActionMessageBox("Are you sure, you want to discard all your change(s)?", "Discard Change(s)"))
                    {
                        jobViewModel.ToggleJobEditModeGui();
                        jobViewModel.ResetStatusSelected();
                    }
                }
                else
                {
                    jobViewModel.ToggleJobEditModeGui();
                    jobViewModel.ResetStatusSelected();
                }

            }
            else if (parameter.ToString() == "Cancel")
            {
                if (jobViewModel.IsJobChanged())
                {
                    if (jobViewModel.DisplayConfirmActionMessageBox("Are you sure, you want to discard all your change(s)?", "Discard Change(s)"))
                    {
                        jobViewModel.UpdateViewCommand.Execute("AvailableJobs");
                    }
                }
                else
                {
                    jobViewModel.UpdateViewCommand.Execute("AvailableJobs");
                }
            }
            else if (parameter.ToString() == "SaveChanges")
            {
                jobViewModel.ToggleJobEditModeGui();
                jobViewModel.SaveStatusSelected();
            }
        }
    }
}
