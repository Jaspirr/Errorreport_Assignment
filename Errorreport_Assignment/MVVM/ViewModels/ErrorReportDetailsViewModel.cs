using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Errorreport_Assignment.MVVM.ViewModels
{
    public class ErrorReportDetailsViewModel : ObservableObject
    {
        private readonly ErrorReport _errorReport;
        private readonly DatabaseService _errorReportService;

        public ErrorReportDetailsViewModel(ErrorReport errorReport, DatabaseService errorReportService)
        {
            _errorReport = errorReport ?? throw new ArgumentNullException(nameof(errorReport));
            _errorReportService = errorReportService ?? throw new ArgumentNullException(nameof(errorReportService));

            // Set initial values
            Id = _errorReport.Id;
            EntryTime = _errorReport.EntryTime;
            FirstName = _errorReport.FirstName;
            LastName = _errorReport.LastName;
            PhoneNumber = _errorReport.PhoneNumber;
            EmailAddress = _errorReport.EmailAddress;
            Description = _errorReport.Description;
            Status = _errorReport.Status;

            // Initialize commands
            UpdateStatusCommand = new RelayCommand(UpdateStatus, CanUpdateStatus);
        }

        #region Properties

        public int Id { get; }
        public DateTime EntryTime { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public string EmailAddress { get; }
        public string Description { get; }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        private string _selectedStatus;
        public string SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                if (_selectedStatus != value)
                {
                    _selectedStatus = value;
                    OnPropertyChanged(nameof(SelectedStatus));
                    UpdateStatusCommand.RaiseCanExecuteChanged();
                }
            }
        }

        #endregion

        #region Commands

        public ICommand UpdateStatusCommand { get; }

        private bool CanUpdateStatus()
        {
            return !string.IsNullOrWhiteSpace(SelectedStatus);
        }

        private void UpdateStatus()
        {
            // Update the status of the error report
            _errorReportService.UpdateStatus(Id, SelectedStatus);

            // Update the Status property to reflect the new status
            Status = SelectedStatus;

            // Reset the selected status
            SelectedStatus = null;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

