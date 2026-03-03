using System.ComponentModel;

namespace Territory;

public class Cell : INotifyPropertyChanged
{
    public int Row { get; set; }
    public int Column { get; set; }

    private Player? _owner;
    public Player? Owner
    {
        get => _owner;
        set
        {
            if (_owner != value)
            {
                _owner = value;
                OnPropertyChanged(nameof(Owner));
                OnPropertyChanged(nameof(OwnerId));
            }
        }
    } // 0 -> Empty , 1 -> Player1 , 2 -> Player2, etc

    // handy string for binding
    public string OwnerId => _owner?.Id ?? "";

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
}