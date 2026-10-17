using System;

public struct Board
{
    public char[,] grid;

    public Board()
    {
        grid = new char[5, 5];
        for (int i = 0; i < 5; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j % 2 == 0)
                    {
                        grid[i, j] = ' ';
                    }
                    else
                    {
                        grid[i, j] = '|';
                    }
                }
            }
            else
            {
                for (int j = 0; j < 5; j++)
                {
                    grid[i, j] = '-';
                }
            }
        }

    }

    public void Display()
    {
        Console.WriteLine("--- TickTackToe Game ---");
        Console.WriteLine("Current board:");
        Console.WriteLine("  1   2   3");
        for (int i = 0; i < 5; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(i / 2 + 1 + " ");
            }
            else
            {
                Console.Write("  ");
            }
            for (int j = 0; j < 5; j++)
            {
                Console.Write(grid[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public bool isBoardFull(char[,] grid)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (grid[i, j] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }
}

public struct Player
{
    public int Id;
    public char symbol;

    public Player(int id)
    {
        Id = id;
    }
    public void SetSymbol()
    {
        do
        {
            Console.WriteLine("Enter a symbol (X or O):");
            symbol = char.Parse(Console.ReadLine());
            if (symbol != 'X' && symbol != 'O')
            {
                Console.WriteLine("Invalid symbol. Please enter X or O.");
            }
        } while (symbol != 'X' && symbol != 'O');
    }
    public void MakeMove(int row, int col, char[,] grid)
    {
        if (grid[row, col] == ' ')
        {
            grid[row, col] = symbol;
        }
        else
        {
            Console.Clear();
            board.Display();
            Console.WriteLine("Invalid move. Cell is already occupied.");
            Console.WriteLine("input again");
            (int r, int c) = Program.GetMove();
            MakeMove(r, c, grid);
        }
    }
    public bool CheckWin(char symbol, char[,] grid)
    {
        // horizontal
        for (int i = 0; i < 3; i++)
        {
            if (grid[i*2, 0] == symbol && grid[i*2, 2] == symbol && grid[i*2, 4] == symbol)
            {
                return true;
            }
        }
        // vertical
        for (int i = 0; i < 3; i++)
        {
            if (grid[0, i*2] == symbol && grid[2, i*2] == symbol && grid[4, i*2] == symbol)
            {
                return true;
            }
        }
        // diagonal
        if (grid[0, 0] == symbol && grid[2, 2] == symbol && grid[4, 4] == symbol)
        {
            return true;
        }
        if (grid[0, 2] == symbol && grid[2, 1] == symbol && grid[4, 0] == symbol)
        {
            return true;
        }
        return false;
    }
}


class Program
{
    public static (int, int) GetMove()
    {
        int r, c;
        do
        {
            Console.WriteLine("Enter row (1-3):");
            while (!int.TryParse(Console.ReadLine(), out  r))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            }
            Console.WriteLine("Enter column (1-3):");
            while (!int.TryParse(Console.ReadLine(), out  c))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            }
        } while (r < 1 || r > 3 || c < 1 || c > 3);
        // minus 1 to convert to 0-based index, then multiply by 2 to get the cell index
        return ((r - 1)*2, (c - 1)*2);
    }

    public static void Main()
    {
        var player1 = new Player(1);
        var player2 = new Player(2);
        // Get unique symbols for both players
        do
        {
            player1.SetSymbol();
            player2.SetSymbol();
            if (player1.symbol == player2.symbol)
            {
                Console.WriteLine("Symbols cannot be the same. Please enter a different symbol.");
            }
        } while (player1.symbol == player2.symbol);

        // Initialize the board and start the game
        var board = new Board();

        while (true)
        {
            Console.Clear();
            board.Display();
            Console.WriteLine($"{player1.symbol}'s move:");
            var (row, col) = GetMove();
            player1.MakeMove(row, col, board.grid);
            Console.Clear();
            board.Display();
            if (player1.CheckWin(player1.symbol, board.grid))
            {
                Console.WriteLine("Player 1 wins!");
                break;
            }
            else if (board.isBoardFull(board.grid))
            {
                Console.WriteLine("It's a tie!");
                break;
            }
            Console.WriteLine($"{player2.symbol}'s move:");
            var (row2, col2) = GetMove();
            player2.MakeMove(row2, col2, board.grid);
            Console.Clear();
            board.Display();
            if (player2.CheckWin(player2.symbol, board.grid))
            {
                Console.WriteLine("Player 2 wins!");
                break;
            }
            else if (board.isBoardFull(board.grid))
            {
                Console.WriteLine("It's a tie!");
                break;
            }
        }
    }
}
