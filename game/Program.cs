using System;

char[,] board = new char[6, 7];

// Fill board
for (int r = 0; r < 6; r++)
{
    for (int c = 0; c < 7; c++)
    {
        board[r, c] = '.';
    }
}

char player = 'X';
bool win = false;

while (win == false)
{
    Console.Clear();

    // Print board
    for (int r = 0; r < 6; r++)
    {
        for (int c = 0; c < 7; c++)
        {
            Console.Write(board[r, c] + " ");
        }

        Console.WriteLine("");
    }

    Console.WriteLine("0 1 2 3 4 5 6");
    Console.WriteLine("Player " + player + ", choose column:");

    // Input
    int col;

    if (int.TryParse(Console.ReadLine(), out col) == false || col < 0 || col > 6)
    {
        continue;
    }

    // Drop piece
    int row = -1;

    for (int r = 5; r >= 0; r--)
    {
        if (board[r, col] == '.')
        {
            board[r, col] = player;
            row = r;
            break;
        }
    }

    // Full column
    if (row == -1)
    {
        continue;
    }

    // Horizontal
    for (int r = 0; r < 6; r++)
    {
        for (int c = 0; c < 4; c++)
        {
            if (board[r, c] == player &&
                board[r, c + 1] == player &&
                board[r, c + 2] == player &&
                board[r, c + 3] == player)
            {
                win = true;
            }
        }
    }

    // Vertical
    for (int r = 0; r < 3; r++)
    {
        for (int c = 0; c < 7; c++)
        {
            if (board[r, c] == player &&
                board[r + 1, c] == player &&
                board[r + 2, c] == player &&
                board[r + 3, c] == player)
            {
                win = true;
            }
        }
    }

    // Diagonal \
    for (int r = 0; r < 3; r++)
    {
        for (int c = 0; c < 4; c++)
        {
            if (board[r, c] == player &&
                board[r + 1, c + 1] == player &&
                board[r + 2, c + 2] == player &&
                board[r + 3, c + 3] == player)
            {
                win = true;
            }
        }
    }

    // Diagonal /
    for (int r = 3; r < 6; r++)
    {
        for (int c = 0; c < 4; c++)
        {
            if (board[r, c] == player &&
                board[r - 1, c + 1] == player &&
                board[r - 2, c + 2] == player &&
                board[r - 3, c + 3] == player)
            {
                win = true;
            }
        }
    }

    // Winner
    if (win == true)
    {
        Console.Clear();

        for (int r = 0; r < 6; r++)
        {
            for (int c = 0; c < 7; c++)
            {
                Console.Write(board[r, c] + " ");
            }

            Console.WriteLine("");
        }

        Console.WriteLine("Player " + player + " wins!");
    }
    else
    {
        // Change player
        if (player == 'X')
        {
            player = 'O';
        }
        else
        {
            player = 'X';
        }
    }
}

Console.WriteLine("Game Over");
