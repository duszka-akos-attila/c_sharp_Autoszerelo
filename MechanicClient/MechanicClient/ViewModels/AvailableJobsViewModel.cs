using MechanicClient.Commands;
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
using System.Windows.Input;

namespace MechanicClient.ViewModels
{
    public class AvailableJobsViewModel : ViewModelBase
    {
        public ICommand UpdateJobStatusCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand SortItemsCommand { get; set; }
        public int JobSelected { get; set; }
        public ObservableCollection<Job> Jobs { get; set; }
        public string OrderByDateIcon { get; set; }
        public Job GetSelectedJob()
        {
            if (JobSelected > -1)
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
            Jobs = new ObservableCollection<Job>();
            Jobs.Add(new Job(0, "Barbara", "Tesla", "L-00537", DateTime.Now, "Registered", "Battery died aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
            Jobs.Add(new Job(0, "Alice", "Tesla", "L-00537", DateTime.Now.AddDays(1), "Registered", "Battery died "));
            Jobs.Add(new Job(0, "Clementine", "Tesla", "L-00537", DateTime.Now.AddDays(2), "Registered", "Battery died "));
            Jobs.Add(new Job(0, "Dorothy", "Tesla", "L-00537", DateTime.Now.AddDays(3), "Registered", "Battery died "));
            this.UpdateJobStatusCommand = new UpdateJobStatusCommand(this);
            this.UpdateViewCommand = new UpdateViewCommand(mainViewModel, this);
            this.SortItemsCommand = new SortItemsCommand(this);
            this.OrderByDateIcon = "▼";
            SortItemsCommand.Execute("Date");
        }

        public void SetSelectedJobStatus(string Status)
        {
            if (JobSelected > -1)
            {
                Jobs[JobSelected].Status = Status;
                Jobs[JobSelected].PropertyHasChanged();
            }
        }

        public void ToggleOrderByDate()
        {
            if (OrderByDateIcon == "▼")
            {
                Jobs = new ObservableCollection<Job>(Jobs.OrderByDescending(Job => Job.RegistrationDate));
                OrderByDateIcon = "▲";
                Job dummyJob = new Job();
                Jobs.Add(dummyJob);
                Jobs.CollectionChanged += Jobs_CollectionChanged;
                Jobs.Remove(dummyJob);
                Jobs.CollectionChanged += Jobs_CollectionChanged;
            }
            else if (OrderByDateIcon == "▲")
            {
                Jobs = new ObservableCollection<Job>(Jobs.OrderBy(Job => Job.RegistrationDate));
                OrderByDateIcon = "▼";
                Job dummyJob = new Job();
                Jobs.Add(dummyJob);
                Jobs.CollectionChanged += Jobs_CollectionChanged;
                Jobs.Remove(dummyJob);
                Jobs.CollectionChanged += Jobs_CollectionChanged;
            }
        }

        private void Jobs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            
        }
    }
}
