using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicClient.Models
{
    public class JobEditModeGui : INotifyPropertyChanged
    {
        public bool EditModeAvailable { get; set; }
        public bool EditModeEnabled { get; set; }
        public string EditButtonForeground { get; set; }

        public JobEditModeGui()
        {
            this.EditModeAvailable = true;
            this.EditModeEnabled = false;
            this.EditButtonForeground = "#FFFFFF";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateJobEditModeGui(bool editModeEnabled)
        {
            this.EditModeAvailable = !editModeEnabled;
            this.EditModeEnabled = editModeEnabled;

            if(editModeEnabled)
            {
                this.EditButtonForeground = "#BBBBBB";
            }
            else
            {
                this.EditButtonForeground = "#FFFFFF";
            }

            PropertyHasChanged();
        }

        public void PropertyHasChanged()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("EditModeAvailable"));
            PropertyChanged(this, new PropertyChangedEventArgs("EditModeEnabled"));
            PropertyChanged(this, new PropertyChangedEventArgs("EditButtonForeground"));
        }
    }
}
