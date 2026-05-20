using System;

class Connect4
{ // Code to create the board and start the game loop
    static char[,] board = new char[6, 7];

    static void Main()
    {
        InitializeBoard();

        char currentPlayer = 'X';
        bool gameWon = false;

        while (!gameWon)
        {  // Code to clear the console and make the board, then ask the player to choose a where to drop their piece
            Console.Clear();
            PrintBoard();

            Console.WriteLine($"Player {currentPlayer}, choose a column (0-6):");

            int col;
            if (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col > 6)
            {
                Console.WriteLine("Invalid column!");
                Console.ReadKey();
                continue;
            }

            int row = DropPiece(col, currentPlayer);

            if (row == -1)
            {
                Console.WriteLine("Column is full!");
                Console.ReadKey();
                continue;
            }

            if (CheckWin(row, col, currentPlayer))
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine($"Player {currentPlayer} wins!");
                gameWon = true;
            }
            else
            {
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }

        Console.WriteLine("Game Over!");
    }

    static void InitializeBoard()
    { // Code to fill the board with dots to as empty spaces
        for (int r = 0; r < 6; r++)
        {
            for (int c = 0; c < 7; c++)
            {
                board[r, c] = '.';
            }
        }
    }

    static void PrintBoard()
    { // Code to print the board
        for (int r = 0; r < 6; r++)
        {
            for (int c = 0; c < 7; c++)
            {
                Console.Write(board[r, c] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("0 1 2 3 4 5 6");
    }

    static int DropPiece(int col, char player)
    { // Code to drop a dot into the into the spot the player chooses
        for (int r = 5; r >= 0; r--)
        {
            if (board[r, col] == '.')
            {
                board[r, col] = player;
                return r;
            }
        }

        return -1;
    }

    static bool CheckWin(int row, int col, char player)
    { // Code to check if the player has won
        return Count(row, col, 1, 0, player) + Count(row, col, -1, 0, player) > 2 || 
               Count(row, col, 0, 1, player) + Count(row, col, 0, -1, player) > 2 || 
               Count(row, col, 1, 1, player) + Count(row, col, -1, -1, player) > 2 || 
               Count(row, col, 1, -1, player) + Count(row, col, -1, 1, player) > 2;   
    }

    static int Count(int row, int col, int rowDir, int colDir, char player)
    { // Code to count the number of pieces in diffrent directions
        int count = 0;

        int r = row + rowDir;
        int c = col + colDir;

        while (r >= 0 && r < 6 && c >= 0 && c < 7 && board[r, c] == player)
        {
            count++;
            r += rowDir;
            c += colDir;
        }

        return count;
    }
}
