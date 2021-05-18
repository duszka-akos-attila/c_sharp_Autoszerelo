using RecruiterClient.Commands;
using RecruiterClient.DataProviders;
using RecruiterClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace RecruiterClient.ViewModels
{
    public class RegisteredJobsViewModel : ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand EditJobCommand { get; set; }
        public MainViewModel MainViewModel { get; set; }
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
        public void SetSelectedJob(Job job)
        {
            Jobs[JobSelected].ClientName = job.ClientName;
            Jobs[JobSelected].CarModel = job.CarModel;
            Jobs[JobSelected].LicensePlate = job.LicensePlate;
            Jobs[JobSelected].Description = job.Description;

        }

        public RegisteredJobsViewModel(MainViewModel mainViewModel)
        {
            this.UpdateViewCommand = new UpdateViewCommand(mainViewModel, this);
            this.MainViewModel = mainViewModel;
            this.EditJobCommand = new EditJobCommand(mainViewModel, this);

            try
            {
                Jobs = new ObservableCollection<Job>(JobDataProvider.GetJobs());
                OrderByDate();
            }
            catch (Exception e)
            {
                if (DisplayConfirmActionMessageBox("Connection to the database failed! Do you want to retry?", "ERROR"))
                {
                    UpdateViewCommand.Execute("AvailableJobsNew");
                }

                Jobs = new ObservableCollection<Job>();
                Jobs.Add(new Job(0, "Jhonzon", "Toyota", "ABC-123", DateTime.Now, "Registered", "Bad"));
                Jobs.Add(new Job(0, "Bobby", "Suzuki", "ABC-321", DateTime.Now, "Registered", "Very Bad"));
                Jobs.Add(new Job(0, "Thompson", "Kia", "BCA-123", DateTime.Now, "Registered", "Engine Faliure"));
                Jobs.Add(new Job(0, "Test", "test", "tes-123", DateTime.Now, "Registered", "Test faliure happend"));
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
