using System.ComponentModel;

namespace MechanicClient.Models
{
    public class JobEditModeGui : INotifyPropertyChanged
    {
        public bool EditModeAvailable { get; set; }
        public bool EditModeEnabled { get; set; }
        public string EditButtonForeground { get; set; }
        private int statusSelected;
        public int StatusSelected
        {
            get { return statusSelected; }
            set
            {
                statusSelected = value;
                StatusPropertyHasChanged();
            }
        }

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
            this.StatusSelected = 0;

            if (editModeEnabled)
            {
                this.EditButtonForeground = "#BBBBBB";
            }
            else
            {
                this.EditButtonForeground = "#FFFFFF";
            }

            PropertyHasChanged();
            StatusPropertyHasChanged();
        }

        public void PropertyHasChanged()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("EditModeAvailable"));
            PropertyChanged(this, new PropertyChangedEventArgs("EditModeEnabled"));
            PropertyChanged(this, new PropertyChangedEventArgs("EditButtonForeground"));
        }

        public void StatusPropertyHasChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StatusSelected"));
        }
    }
}
