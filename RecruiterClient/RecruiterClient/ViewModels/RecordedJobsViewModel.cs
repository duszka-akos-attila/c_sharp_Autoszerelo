using RecruiterClient.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecruiterClient.ViewModels
{
    public class RecordedJobsViewModel : ViewModelBase
    {
        public ICommand UpdateViewCommand { get; set; }

        public RecordedJobsViewModel(MainViewModel mainViewModel)
        {
            this.UpdateViewCommand = new UpdateViewCommand(mainViewModel);
        }
    }
}
