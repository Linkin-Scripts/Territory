using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Territory;

public class Board
{
    public int Rows { get; }
    public int Columns { get; }

    public List<Cell> Cells { get; set; } = new();

    public Board(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Cells.Add(new Cell { Row = i, Column = j });
            }
        }
    }
    public IEnumerable<Cell> LegalMoves(Player player)
    {
        // first move for this player: any empty spot
        if (!Cells.Any(c => c.Owner == player))
            return Cells.Where(c => c.Owner == null);

        var moves = new HashSet<Cell>();
        foreach (var c in Cells.Where(c => c.Owner == player))
        {
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0) continue;
                    int nr = c.Row + dr;
                    int nc = c.Column + dc;
                    if (nr >= 0 && nr < Rows && nc >= 0 && nc < Columns)
                    {
                        var neighbor = Cells.FirstOrDefault(x => x.Row == nr && x.Column == nc);
                        if (neighbor != null && neighbor.Owner == null)
                            moves.Add(neighbor);
                    }
                }
            }
        }
        return moves;
    }
}