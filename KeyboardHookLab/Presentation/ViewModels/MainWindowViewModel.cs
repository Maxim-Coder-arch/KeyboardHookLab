
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using KeyboardHookLab.Domain.Entities;
using KeyboardHookLab.Presentation.Commands;

namespace KeyboardHookLab.Presentation.ViewModels;

public sealed class MainWindowViewModel : INotifyPropertyChanged
{
    private string _applicationStatus = "Приложение запущено";

    public ObservableCollection<KeyboardEventEntry> KeyboardEvents { get; } = [];

    public ICommand ClearKeyboardEventsCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public string ApplicationStatus
    {
        get => _applicationStatus;

        private set
        {
            if (_applicationStatus == value)
            {
                return;
            }

            _applicationStatus = value;

            OnPropertyChanged();
        }
    }

    public MainWindowViewModel()
    {
        ClearKeyboardEventsCommand = new RelayCommand(
            ClearKeyboardEvents);
    }

    public void RegisterKeyboardEvent(
        string eventType,
        string keyName,
        string source)
    {
        KeyboardEventEntry keyboardEvent = new(
            DateTimeOffset.Now,
            eventType,
            keyName,
            source);

        KeyboardEvents.Add(keyboardEvent);
    }

    public void UpdateApplicationStatus(string status)
    {
        ApplicationStatus = status;
    }

    private void ClearKeyboardEvents()
    {
        KeyboardEvents.Clear();
    }

    private void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}
