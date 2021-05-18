using MechanicClient.Commands;
using MechanicClient.DataProviders;
using MechanicClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;

namespace MechanicClient.ViewModels
{
    public class AvailableJobsViewModel : ViewModelBase
    {
        public ICommand UpdateJobStatusCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public int JobSelected { get; set; }
        public ObservableCollection<Job> Jobs { get; set; }
        public Job GetSelectedJob()
        {
            if (Jobs != null && Jobs.Count > 0 && JobSelected > -1)
            {
                return Jobs[JobSelected];
            }
            else
            {
                return null;
            }
        }
        public AvailableJobsViewModel(MainViewModel mainViewModel)
        {
            this.UpdateJobStatusCommand = new UpdateJobStatusCommand(this);
            this.UpdateViewCommand = new UpdateViewCommand(mainViewModel, this);

            try
            {
                Jobs = new ObservableCollection<Job>(JobDataProvider.GetJobs());
                OrderByDate();
            }
            catch (Exception e)
            {
                if( DisplayConfirmActionMessageBox("Connection to the database failed! Do you want to retry?", "ERROR"))
                {
                    UpdateViewCommand.Execute("AvailableJobsNew");
                }
            }

        }

        public void SetSelectedJobStatus(string Status)
        {
            if (Jobs != null && Jobs.Count > 0 && JobSelected > -1)
            {
                Jobs[JobSelected].Status = Status;
                JobDataProvider.UpdateState(Jobs[JobSelected].Id, Status);
                Jobs[JobSelected].PropertyHasChanged();
            }
        }

        public void OrderByDate()
        {
            Jobs = new ObservableCollection<Job>(Jobs.OrderByDescending(Job => Job.RegistrationDate));
        }

        public bool DisplayConfirmActionMessageBox(string question, string caption)
        {
            DialogResult dialogResult = MessageBox.Show(question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dialogResult == DialogResult.Yes;
        }

    }
}
