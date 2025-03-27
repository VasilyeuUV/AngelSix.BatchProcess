using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AngelSix.BatchProcess.ViewModels._Test;

/// <summary>
/// Тестовая вьюмодель без библиотек.
/// </summary>
public class MyViewModel : INotifyPropertyChanged
{
    private string _myStringFullProperty = "Это строка из полного свойства.";

    public string MyString { get; set; } = "Это тестовая строка.";


    public string MyStringFullProperty
    {
        get => _myStringFullProperty;
        set
        {
            if (_myStringFullProperty == value)
            {
                return;
            }
            _myStringFullProperty = value;
            OnPropertyChanged(); // указывать nameof(MyStringFullProperty) не нужно, т.к. есть [CallerMemberName]
        }
    }


    public MyViewModel()
    {
        //// Это имитация действий во View":
        //var dataContext = this;
        //dataContext.PropertyChanged += (_, args) =>
        //{
        //    // Действия при изменении свойства.
        //};

        Task.Run(async () =>
        {
            await Task.Delay(2000);
            MyString = "Строка изменена.";
            OnPropertyChanged(nameof(MyString));

            await Task.Delay(2000);
            MyStringFullProperty = "Вторая строка изменена.";
        });
    }


    //##################################################################################
    #region INotifyPropertyChanged
    
    public event PropertyChangedEventHandler? PropertyChanged;

    #endregion // INotifyPropertyChanged


    /// <summary>
    /// Срабатывает при изменении свойства.
    /// </summary>
    /// <param name="propertyName"></param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    /// <summary>
    /// Оптимизация установки значения свойству.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="field"></param>
    /// <param name="value"></param>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

}
