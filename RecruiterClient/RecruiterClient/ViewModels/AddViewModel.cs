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
    public class AddViewModel : ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public MainViewModel mainViewModel { get; set; }

        public Job Job { get; set; }

        public AddViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.UpdateViewCommand = new UpdateViewCommand(mainViewModel);
            this.AddCommand = new AddCommand(mainViewModel, this);
            Job = new Job(0,"","","",DateTime.Now,"","");
        }

        public void AddNewJob()
        {
            if (ValidateClientName(Job.ClientName) && ValidateLicensePlate(Job.LicensePlate))
            {
                try
                {
                    JobDataProvider.CreateJob(Job);
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
            if (Regex.Match(name, @"^\w{3,10} \w{3,10}$", RegexOptions.IgnoreCase).Success)
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
            else
            {
                return false;
            }
        }

        public void DisplayErrorMessageBox(string problem, string caption)
        {
            DialogResult dialogResult = MessageBox.Show(problem, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        public bool DisplayConfirmActionMessageBox(string question, string caption)
        {
            DialogResult dialogResult = MessageBox.Show(question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dialogResult == DialogResult.Yes;
        }

        public bool IsJobChanged()
        {
            if (Job.ClientName != null)
            {
                return true;
            }
            else if (Job.CarModel != null)
            {
                return true;
            }
            else if (Job.LicensePlate != null)
            {
                return true;
            }
            else if (Job.Description != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
