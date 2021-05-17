using MechanicClient.Models;
using MechanicClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MechanicClient.Commands
{
    public class SortItemsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private AvailableJobsViewModel availableJobsViewModel;

        public SortItemsCommand(AvailableJobsViewModel availableJobsViewModel)
        {
            this.availableJobsViewModel = availableJobsViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Date")
            {
                availableJobsViewModel.ToggleOrderByDate();

                availableJobsViewModel.UpdateViewCommand.Execute("AvailableJobs");
            }
        }
    }
}
