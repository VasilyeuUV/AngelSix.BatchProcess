﻿using System;
using AngelSix.BatchProcess.ViewModels;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace AngelSix.BatchProcess;

internal class ViewLocator : IDataTemplate
{
    //################################################################################
    #region IDataTemplate

    public Control? Build(object? data)
    {
        if (data is null)
        {
            return default;
        }

        string viewName = data.GetType().FullName!
            .Replace("ViewModel", "View", System.StringComparison.InvariantCulture);
        Type? type = Type.GetType(viewName);

        if (type is null)
        {
            return default;
        }

        Control control = (Control)Activator.CreateInstance(type)!;
        control.DataContext = data;
        return control;
    }

    public bool Match(object? data)
        => data is ViewModelBase;

    #endregion // IDataTemplate
}
