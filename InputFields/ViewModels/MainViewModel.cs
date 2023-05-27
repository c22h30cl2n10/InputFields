using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace InputFields.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _password;
        private bool _isPasswordHidden;
        private string _togglePasswordButtonImage;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public bool IsPasswordHidden
        {
            get { return _isPasswordHidden; }
            set { SetProperty(ref _isPasswordHidden, value); }
        }

        public string TogglePasswordButtonImage
        {
            get { return _togglePasswordButtonImage; }
            set { SetProperty(ref _togglePasswordButtonImage, value); }
        }

        public ICommand TogglePasswordCommand { get; private set; }

        public MainViewModel()
        {
            //Установка пароля в скрытое состояние по умолчанию
            TogglePasswordCommand = new Command(TogglePasswordVisibility);
            IsPasswordHidden = true; 
            TogglePasswordButtonImage = "hide_eye.png";
        }

        private void TogglePasswordVisibility()
        {
            IsPasswordHidden = !IsPasswordHidden;
            TogglePasswordButtonImage = IsPasswordHidden ? "hide_eye.png" : "open_eye.png";
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
