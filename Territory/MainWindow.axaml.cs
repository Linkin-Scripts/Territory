using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Territory;

public partial class MainWindow : Window
{
    public Player Player1 { get; }
    public Player Player2 { get; }
    private Player _currentPlayer;
    public List<Player> Players { get; set; }

    public Board Board { get; set; }

    public ColourConverter colourConverter { get; set; }
    public int Turn { get; set; } = 0;
    public bool firstTurn = true;

    public MainWindow()
    {
        InitializeComponent();

        Player1 = new("0");
        Player2 = new("1");
        Players = [Player1, Player2];
        
        Board = new(5, 5);

        colourConverter = new();


        DataContext = this;
    }

    public void CellCLick(object? sender, RoutedEventArgs e)
    {
        foreach(Player player in Players)
        {
            if (int.Parse(player.Id) == Turn)
            {
                _currentPlayer = player;
            }
        }

        if (sender is Button clickedButton && clickedButton.Tag is Cell clickedCell)
        {
            int row = clickedCell.Row;
            int column = clickedCell.Column;
        
            clickedCell.Owner = _currentPlayer;
            clickedButton.Background = (IBrush?) colourConverter.Convert(clickedCell.Owner.Id, typeof(IBrush), null, null);
        }
    }
}