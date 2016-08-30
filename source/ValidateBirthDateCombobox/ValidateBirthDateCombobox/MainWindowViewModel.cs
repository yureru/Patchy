using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using ValidateBirthDateCombobox.Properties;
using System.Diagnostics;
using System.Windows.Input;

namespace ValidateBirthDateCombobox
{
    class MainWindowViewModel : ObservableObject, IDataErrorInfo
    {
        #region Fields

        string _selectedDay, _selectedMonth, _selectedYear;

        #endregion // Fields

        public MainWindowViewModel()
        {
            _selectedDay = Resources.BirthDate_Combobox_Day;
            _selectedMonth = Resources.BirthDate_Combobox_Month;
            _selectedYear = Resources.BirthDate_Combobox_Year;

        }

        #region Properties

        public string Day
        {
            get { return _selectedDay; }
            set
            {
                if (_selectedDay == value)
                {
                    return;
                }
                _selectedDay = value;

                OnPropertyChanged("Day");
            }
        }

        public string Month
        {
            get { return _selectedMonth; }
            set
            {
                if (_selectedMonth == value)
                {
                    return;
                }

                _selectedMonth = value;

                OnPropertyChanged("Month");
                OnPropertyChanged("Day"); // Day is updated here to allow validation whenever property Month changes.
            }
        }

        public string Year
        {
            get { return _selectedYear; }
            set
            {
                if (_selectedYear == value)
                {
                    return;
                }

                _selectedYear = value;

                OnPropertyChanged("Year");
                OnPropertyChanged("Day"); // Day is updated here to allow validation whenever property Year changes.
            }
        }

        // Wrapper for the BirthDate class.
        public List<string> Days
        {
            get { return BirthDate.Days; }
        }

        public string[] Months
        {
            get { return BirthDate.Months; }
        }

        public List<string> Years
        {
            get { return BirthDate.Years; }
        }



        #endregion // Properties

        #region Validation

        string IDataErrorInfo.Error
        {
            get { return (this as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return this.GetValidationError(propertyName);
            }
        }

        /// <summary>
        /// Validates a date with the values of Day, Month, and Year from the Comboboxes.
        /// </summary>
        /// <returns>An error message if the date is invalid or missing.</returns>
        string ValidateBirthdate()
        {
            if (this.Day != Resources.BirthDate_Combobox_Day
                && this.Month != Resources.BirthDate_Combobox_Month
                && this.Year != Resources.BirthDate_Combobox_Year)
            {
                try
                {
                    var date = new DateTime(int.Parse(Year), BirthDate.ParseMonth(Month), int.Parse(Day));
                }
                catch (ArgumentOutOfRangeException)
                {
                    return Resources.BirthDate_Error_InvalidBirthDate;
                }

                return null;
            }

            return Resources.BirthDate_Error_MissingBirthDate;
        }

        string GetValidationError(string propertyName)
        {

            string error = null;

            switch (propertyName)
            {
                case "Day":
                    error = ValidateBirthdate();
                    break;
                default:
                    Debug.Fail("Unexpected property being validated: " + propertyName);
                    break;
            }

            CommandManager.InvalidateRequerySuggested();

            return error;
        }

        #endregion // Validation
    }
}
