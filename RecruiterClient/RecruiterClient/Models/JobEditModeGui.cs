using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterClient.Models
{
    public class JobEditModeGui : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool EditModeAvailable { get; set; }
        public bool EditModeEnabled { get; set; }
        public string EditButtonForeground { get; set; }
        public JobEditModeGui()
        {
            this.EditModeAvailable = true;
            this.EditModeEnabled = false;
            this.EditButtonForeground = "#FFFFFF";
        }
        public JobEditModeGui(bool EditmodeEnabled)
        {
            this.EditModeAvailable = !EditmodeEnabled;
            this.EditModeEnabled = EditmodeEnabled;
            if (EditmodeEnabled)
            {
                this.EditButtonForeground = "#BBBBBB";
            }
            else
            {
                this.EditButtonForeground = "#FFFFFF";
            }
            PropertyHasChanged();

        }
        public void UpdateJobEditModeGui(bool editModeEnabled)
        {
            this.EditModeAvailable = !editModeEnabled;
            this.EditModeEnabled = editModeEnabled;

            if (editModeEnabled)
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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("EditModeAvailable"));
                PropertyChanged(this, new PropertyChangedEventArgs("EditModeEnabled"));
                PropertyChanged(this, new PropertyChangedEventArgs("EditButtonForeground"));
            }
        }
    }
}
