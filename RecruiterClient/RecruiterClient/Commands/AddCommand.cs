using RecruiterClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecruiterClient.Commands
{
    public class AddCommand : ICommand
    {

        private MainViewModel mainViewModel;
        private AddViewModel addViewModel;
        private ICommand UpdateViewCommand;

        public AddCommand(MainViewModel mainViewModel, AddViewModel addViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.addViewModel = addViewModel;
            UpdateViewCommand = new UpdateViewCommand(mainViewModel);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "SaveChanges")
            {
                addViewModel.AddNewJob();
            }
            else if (parameter.ToString() == "DiscardChanges")
            {
                if (addViewModel.IsJobChanged())
                {
                    if (addViewModel.DisplayConfirmActionMessageBox("Are you sure, you want to discard all your change(s)?", "Discard Change(s)"))
                    {
                        addViewModel.UpdateViewCommand.Execute("Add");
                    }
                }
                else
                {
                    addViewModel.UpdateViewCommand.Execute("Add");
                }
            }
            else if (parameter.ToString() == "Cancel")
            {
                if (addViewModel.IsJobChanged())
                {
                    if (addViewModel.DisplayConfirmActionMessageBox("Are you sure, you want to discard all your change(s)?", "Discard Change(s)"))
                    {
                        addViewModel.UpdateViewCommand.Execute("Add");
                    }
                }
                else
                {
                    addViewModel.UpdateViewCommand.Execute("Add");
                }
            }
        }
    }
}
