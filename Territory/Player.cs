namespace Territory;

using System.ComponentModel;

public class Player : INotifyPropertyChanged
{
    private string _name = "";
    private string _color = "";

    public string Id { get; set; }

    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
    }

    // Color as hex string, e.g. #FF0000
    public string Color
    {
        get => _color;
        set
        {
            if (_color != value)
            {
                _color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }
    }

    public Player(string id)
    {
        Id = id;
        Name = $"Player {id}";
        Color = string.Empty;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}