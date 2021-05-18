using RecruiterClient.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecruiterClient.ViewModels
{
    public class JobViewModel : ViewModelBase
    {
        private MainViewModel mainViewModel;
        private RecordedJobsViewModel recordedJobsViewModel;

        public JobViewModel(MainViewModel mainViewModel, RecordedJobsViewModel recordedJobsViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.recordedJobsViewModel = recordedJobsViewModel;
            UpdateViewCommand = new UpdateViewCommand(mainViewModel);
        }

        public ICommand UpdateViewCommand { get; set; }
    }
}
