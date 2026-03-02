namespace Territory;

public class Cell
{
    public int Row { get; set; }
    public int Column { get; set; }
    public Player? Owner { get; set; } // 0 -> Empty , 1 -> Player1 , 2 -> Player2, etc
}