using MechanicClient.Commands;
using MechanicClient.DataProviders;
using MechanicClient.Models;
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

        public JobViewModel(MainViewModel mainViewModel, AvailableJobsViewModel availableJobsViewModel)
        {
            this.UpdateViewCommand = new UpdateViewCommand(mainViewModel, availableJobsViewModel);
            this.EditJobCommand = new EditJobCommand(this);
            this.mainViewModel = mainViewModel;
            this.availableJobsViewModel = availableJobsViewModel;
            this.Job = availableJobsViewModel.GetSelectedJob();
            this.EditModeEnabled = false;
            this.JobEditModeGui = new JobEditModeGui();
            SetStatusSelected();
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
                JobEditModeGui.StatusSelected = 0;
            }
            else if (Job.Status == "Under Repair")
            {
                JobEditModeGui.StatusSelected = 1;
            }
            else if (Job.Status == "Repaired")
            {
                JobEditModeGui.StatusSelected = 2;
            }
        }

        public void ResetStatusSelected()
        {
            if (availableJobsViewModel.GetSelectedJob().Status == "Registered")
            {
                JobEditModeGui.StatusSelected = 0;
            }
            else if (availableJobsViewModel.GetSelectedJob().Status == "Under Repair")
            {
                JobEditModeGui.StatusSelected = 1;
            }
            else if (availableJobsViewModel.GetSelectedJob().Status == "Repaired")
            {
                JobEditModeGui.StatusSelected = 2;
            }
        }
        public void SaveStatusSelected()
        {
            if (JobEditModeGui.StatusSelected == 0)
            {
                availableJobsViewModel.SetSelectedJobStatus("Registered");
                JobDataProvider.UpdateState(Job.Id, "Registered");

            }
            else if (JobEditModeGui.StatusSelected == 1)
            {
                availableJobsViewModel.SetSelectedJobStatus("Under Repair");
                JobDataProvider.UpdateState(Job.Id, "Under Repair");

            }
            else if (JobEditModeGui.StatusSelected == 2)
            {
                availableJobsViewModel.SetSelectedJobStatus("Repaired");
                JobDataProvider.UpdateState(Job.Id, "Repaired");

            }
        }
        public bool DisplayConfirmActionMessageBox(string question, string caption)
        {
            DialogResult dialogResult = MessageBox.Show(question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dialogResult == DialogResult.Yes;
        }

        public bool IsJobChanged()
        {
            if (JobEditModeGui.StatusSelected == 0 && availableJobsViewModel.GetSelectedJob().Status == "Registered")
            {
                return false;
            }
            else if (JobEditModeGui.StatusSelected == 1 && availableJobsViewModel.GetSelectedJob().Status == "Under Repair")
            {
                return false;
            }
            else if (JobEditModeGui.StatusSelected == 2 && availableJobsViewModel.GetSelectedJob().Status == "Repaired")
            {
                return false;
            }
            else if (JobEditModeGui.StatusSelected < 0)
            {
                return false;
            }
            return true;
        }
    }
}
