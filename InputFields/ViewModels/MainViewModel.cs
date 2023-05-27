using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
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
        //Смена значений по нажатию на кнопку с картинкой
        private void TogglePasswordVisibility()
        {
            //Смена вилимости пароля
            IsPasswordHidden = !IsPasswordHidden;
            //Смена картинки
            TogglePasswordButtonImage = IsPasswordHidden ? "hide_eye.png" : "open_eye.png";
        }
    }
}
