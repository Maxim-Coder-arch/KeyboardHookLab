
using System.Windows;
using System.Windows.Input;
using KeyboardHookLab.Presentation.ViewModels;

namespace KeyboardHookLab;

public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();

        _viewModel = new MainWindowViewModel();

        DataContext = _viewModel;
    }

    private void OnPreviewKeyDown(
        object sender,
        KeyEventArgs e)
    {
        Key pressedKey = GetActualKey(e);

        if (pressedKey == Key.Escape)
        {
            _viewModel.ClearKeyboardEventsCommand.Execute(null);

            return;
        }

        _viewModel.RegisterKeyboardEvent(
            "KEY DOWN",
            pressedKey.ToString(),
            "WPF");
    }

    private void OnPreviewKeyUp(
        object sender,
        KeyEventArgs e)
    {
        Key releasedKey = GetActualKey(e);

        _viewModel.RegisterKeyboardEvent(
            "KEY UP",
            releasedKey.ToString(),
            "WPF");
    }

    private void OnWindowActivated(
        object? sender,
        EventArgs e)
    {
        _viewModel.UpdateApplicationStatus(
            "Приложение активно");
    }

    private void OnWindowDeactivated(
        object? sender,
        EventArgs e)
    {
        _viewModel.UpdateApplicationStatus(
            "Приложение неактивно");
    }

    private static Key GetActualKey(KeyEventArgs e)
    {
        if (e.Key == Key.System)
        {
            return e.SystemKey;
        }

        return e.Key;
    }
}
