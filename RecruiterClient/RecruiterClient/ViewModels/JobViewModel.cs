using RecruiterClient.Commands;
using RecruiterClient.DataProviders;
using RecruiterClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RecruiterClient.ViewModels
{
    public class JobViewModel : ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand EditJobCommand { get; set; }
        private MainViewModel mainViewModel;
        private RegisteredJobsViewModel registeredJobsViewModel;
        public JobEditModeGui JobEditModeGui { get; }
        public Job Job { get; set; }
        public bool EditModeEnabled { get; set; }
        public int StatusSelected { get; set; }

        public JobViewModel(MainViewModel mainViewModel, RegisteredJobsViewModel registeredJobsViewModel)
        {
            this.UpdateViewCommand = new UpdateViewCommand(mainViewModel, registeredJobsViewModel);
            this.EditJobCommand = new EditJobCommand(mainViewModel, registeredJobsViewModel, this);
            this.mainViewModel = mainViewModel;
            this.registeredJobsViewModel = registeredJobsViewModel;
            this.Job = registeredJobsViewModel.GetSelectedJob();
            this.EditModeEnabled = false;
            this.JobEditModeGui = new JobEditModeGui();
            SetStatusSelected();
        }
        public JobViewModel(MainViewModel mainViewModel, RegisteredJobsViewModel registeredJobsViewModel, bool EditModeEnabled)
        {
            this.UpdateViewCommand = new UpdateViewCommand(mainViewModel, registeredJobsViewModel);
            this.EditJobCommand = new EditJobCommand(mainViewModel, registeredJobsViewModel, this);
            this.mainViewModel = mainViewModel;
            this.registeredJobsViewModel = registeredJobsViewModel;
            this.Job = registeredJobsViewModel.GetSelectedJob();
            this.EditModeEnabled = EditModeEnabled;
            this.JobEditModeGui = new JobEditModeGui(EditModeEnabled);
            SetStatusSelected();
        }
        public void SetStatusSelected()
        {
            if (Job.Status == "Registered")
            {
                StatusSelected = 0;
            }
            else if (Job.Status == "Under Repair")
            {
                StatusSelected = 1;
            }
            else if (Job.Status == "Repaired")
            {
                StatusSelected = 2;
            }
        }

        public void ToggleJobEditModeGui()
        {
            if (EditModeEnabled)
            {
                EditModeEnabled = false;
            }
            else
            {
                EditModeEnabled = true;
            }

            JobEditModeGui.UpdateJobEditModeGui(EditModeEnabled);
        }

        public bool DisplayConfirmActionMessageBox(string question, string caption)
        {
            DialogResult dialogResult = MessageBox.Show(question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dialogResult == DialogResult.Yes;
        }

        public bool IsJobChanged()
        {
            if (Job.ClientName != registeredJobsViewModel.GetSelectedJob().ClientName)
            {
                return true;
            }
            else if (Job.CarModel != registeredJobsViewModel.GetSelectedJob().CarModel)
            {
                return true;
            }
            else if (Job.LicensePlate != registeredJobsViewModel.GetSelectedJob().LicensePlate)
            {
                return true;
            }
            else if (Job.Description != registeredJobsViewModel.GetSelectedJob().Description)
            {
                return true;
            }

            return false;
        }

        public void ResetJob()
        {
            this.Job = registeredJobsViewModel.GetSelectedJob();
        }

        public void SaveJob()
        {
            if (ValidateClientName(Job.ClientName) && ValidateLicensePlate(Job.LicensePlate))
            {
                try
                {
                    JobDataProvider.UpdateJob(Job.Id, Job);
                }
                catch (Exception e)
                {
                    DisplayErrorMessageBox("Database unreachable!", "ERROR");
                }
                UpdateViewCommand.Execute(mainViewModel);
            }
            if (!ValidateClientName(Job.ClientName))
            {
                DisplayErrorMessageBox("Invalid client name!", "ERROR");
            }
            if (!ValidateLicensePlate(Job.LicensePlate))
            {
                DisplayErrorMessageBox("Invalid license plate!", "ERROR");
            }
        }

        public bool ValidateClientName(string name)
        {
            if(Regex.Match(name, @"^\w{3,10} \w{3,10} \w{0,10}$", RegexOptions.IgnoreCase).Success)
            {
                return true;
            }
            return false;
        }
        public bool ValidateLicensePlate(string licensePlate)
        {
            if (Regex.Match(licensePlate, @"^\w{3}\d{3}$", RegexOptions.IgnoreCase).Success)
            {
                return true;
            }
            else if (Regex.Match(licensePlate, @"^\w{3}-\d{3}$", RegexOptions.IgnoreCase).Success)
            {
                return true;
            }
            return false;
        }

        public void DisplayErrorMessageBox(string problem, string caption)
        {
            DialogResult dialogResult = MessageBox.Show(problem, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }


    }
}
