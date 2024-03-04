﻿using System.Windows.Input;

namespace Avalonia.Notification.Controls;

public class CloseCommand(Action<object> execute, Func<object, bool>? canExecute = null) : ICommand
{
    private readonly Action<object> execute = execute ?? throw new ArgumentNullException(nameof(execute));

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return canExecute == null || canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        execute(parameter);
    }

    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
