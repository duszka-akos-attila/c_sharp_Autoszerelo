using MechanicClient.Commands;
using MechanicClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MechanicClient.ViewModels
{
    public class JobViewModel : ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand EditJobCommand { get; set; }
        private MainViewModel mainViewModel;
        private AvailableJobsViewModel availableJobsViewModel;
        public JobEditModeGui JobEditModeGui { get; }
        public Job Job { get; }
        public bool EditModeEnabled { get; set; }
        public int StatusSelected { get; set; }

        public JobViewModel(MainViewModel mainViewModel, AvailableJobsViewModel availableJobsViewModel)
        {
            this.UpdateViewCommand = new UpdateViewCommand(mainViewModel, availableJobsViewModel);
            this.EditJobCommand = new EditJobCommand(this);
            this.mainViewModel = mainViewModel;
            this.availableJobsViewModel = availableJobsViewModel;
            this.Job = availableJobsViewModel.GetSelectedJob();
            SetStatusSelected();
            this.EditModeEnabled = false;
            this.JobEditModeGui = new JobEditModeGui();
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

        public void ResetStatusSelected()
        {
            if (availableJobsViewModel.GetSelectedJob().Status == "Registered")
            {
                StatusSelected = 0;
            }
            else if (availableJobsViewModel.GetSelectedJob().Status == "Under Repair")
            {
                StatusSelected = 1;
            }
            else if (availableJobsViewModel.GetSelectedJob().Status == "Repaired")
            {
                StatusSelected = 2;
            }
        }
        public void SaveStatusSelected()
        {
            if (StatusSelected == 0)
            {
                availableJobsViewModel.SetSelectedJobStatus("Registered");
            }
            else if (StatusSelected == 1)
            {
                availableJobsViewModel.SetSelectedJobStatus("Under Repair");
            }
            else if (StatusSelected == 2)
            {
                availableJobsViewModel.SetSelectedJobStatus("Repaired");
            }
        }
        public bool DisplayConfirmActionMessageBox(string question, string caption)
        {
            DialogResult dialogResult = MessageBox.Show(question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dialogResult == DialogResult.Yes;
        }

        public bool IsJobChanged()
        {
            if (StatusSelected == 0 && availableJobsViewModel.GetSelectedJob().Status == "Registered")
            {
                return false;
            }
            else if (StatusSelected == 1 && availableJobsViewModel.GetSelectedJob().Status == "Under Repair")
            {
                return false;
            }
            else if (StatusSelected == 2 && availableJobsViewModel.GetSelectedJob().Status == "Repaired")
            {
                return false;
            }
            else if(StatusSelected < 0)
            {
                return false;
            }
            return true;
        }
    }
}
