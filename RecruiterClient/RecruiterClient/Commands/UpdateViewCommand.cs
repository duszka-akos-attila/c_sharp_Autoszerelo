using RecruiterClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecruiterClient.Commands
{
    public class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainViewModel mainViewModel;

        private RecordedJobsViewModel recordedJobsViewModel;

        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
        public UpdateViewCommand(MainViewModel mainViewModel, RecordedJobsViewModel recordedJobsViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.recordedJobsViewModel = recordedJobsViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "RecordedJobs")
            {
                if (recordedJobsViewModel == null)
                {
                    mainViewModel.SelectedViewModel = new RecordedJobsViewModel(mainViewModel);
                }
                else
                {
                    mainViewModel.SelectedViewModel = recordedJobsViewModel;
                }
            }
            else if (parameter.ToString() == "RecordedJobsNew")
            {
                mainViewModel.SelectedViewModel = new RecordedJobsViewModel(mainViewModel);
            }
            else if (parameter.ToString() == "Job")
            {
                if (/*recordedJobsViewModel.GetSelectedJob() != null*/ true)
                {
                    mainViewModel.SelectedViewModel = new JobViewModel(mainViewModel, recordedJobsViewModel);
                }
            }
        }
    }
}
