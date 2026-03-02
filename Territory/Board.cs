using System.Collections.Generic;
using System.Threading;

namespace Territory;

public class Board
{
    public List<Cell> Cells { get; set; } = new();

    public Board(int Rows, int Columns)
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Cells.Add(new Cell{Row = i, Column = j});
            }
        }
    }
}