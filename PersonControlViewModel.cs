using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lab3
{
    internal class PersonControlViewModel : INotifyPropertyChanged
    {
        private Person _person;

        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _dateOfBirth = DateTime.Today;

        private Visibility _loaderVisibility = Visibility.Hidden;
        private Visibility _buttonVisibility = Visibility.Visible;

        private RelayCommand<object> _submitCommand;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility ButtonVisibility
        {
            get { return _buttonVisibility; }
            set
            {
                _buttonVisibility = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _submitCommand ?? (_submitCommand = new RelayCommand<object>(
                    SubmitImplementation, o => CanExecuteCommand()));
            }
        }


        private async void SubmitImplementation(object obj)
        {
            ButtonVisibility = Visibility.Hidden;
            LoaderVisibility = Visibility.Visible;

            await Task.Run(() => Thread.Sleep(200));

            ButtonVisibility = Visibility.Visible;
            LoaderVisibility = Visibility.Hidden;
            try
            {
                _person = new Person(_firstName, _lastName, _email, _dateOfBirth);

                if (_person.IsBirthday)
                    MessageBox.Show("Happy birthday!");


                MessageBox.Show("Your name: " + _person.FirstName + " " + _person.LastName + "\n" +
                                "Your e-mail: " + _person.Email + "\n" +
                                _person.DateOfBirth.Day + "." + _person.DateOfBirth.Month + "." + _person.DateOfBirth.Year + "\n" +
                                "Adult: " + _person.IsAdult + "\n" +
                                "Western: " + _person.Western + "\n" +
                                "Chinese: " + _person.Chinese + "\n" +
                                "Birthday: " + _person.IsBirthday, "Person");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_firstName) && !string.IsNullOrWhiteSpace(_lastName) && !string.IsNullOrWhiteSpace(_email);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
