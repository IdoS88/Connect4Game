// Model.cs
using Client;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

public class Model
{
    private const int Rows = 6;
    private const int Columns = 7;
    public Cell[,] board = new Cell[Rows, Columns];
    private const int CellSize = 80;

    public event EventHandler<int[,]> BoardUpdated;
    public event EventHandler<int> WinnerFound;

    public int GetCurrentPlayer()
    {
        int count = 0;
        for (int r = Rows - 1; r >= 0; r--)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (board[r, c].Player == 0)
                    count++;
            }
        }

        return (count % 2) + 1;
    }

    public bool IsColumnFull(int column)
    {
        return board[0, column].Player != 0;
    }

    public Rectangle[,] GetBoardRectangles()
    {
        Rectangle[,] rectangles = new Rectangle[Rows, Columns];
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                rectangles[r, c] = new Rectangle(c * CellSize, r * CellSize, CellSize, CellSize);
            }
        }
        return rectangles;
    }

    public int MakeMove(int column)
    {
        for (int r = Rows - 1; r >= 0; r--)
        {
            if (board[r, column].Player == 0)
            {
                int currentPlayer = GetCurrentPlayer();
                board[r, column].Player = currentPlayer;
                if (CheckWin(r, column))
                {
                    WinnerFound?.Invoke(this, currentPlayer);
                }
                else
                {
                    int[,] updatedBoard = new int[Rows, Columns];
                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            updatedBoard[i, j] = board[i, j].Player;
                        }
                    }
                    BoardUpdated?.Invoke(this, updatedBoard);
                }
                return currentPlayer;
            }
        }
        return -1; // Column is full
    }

    private bool CheckWin(int row, int col)
    {
        int player = board[row, col].Player;

        // Check vertical
        int count = 0;
        for (int r = row; r < Rows && board[r, col].Player == player; r++)
            count++;
        for (int r = row - 1; r >= 0 && board[r, col].Player == player; r--)
            count++;
        if (count >= 4)
            return true;

        // Check horizontal
        count = 0;
        for (int c = col; c < Columns && board[row, c].Player == player; c++)
            count++;
        for (int c = col - 1; c >= 0 && board[row, c].Player == player; c--)
            count++;
        if (count >= 4)
            return true;

        // Check diagonal (top-left to bottom-right)
        count = 0;
        for (int i = -3; i <= 3; i++)
        {
            int r = row + i;
            int c = col + i;
            if (r >= 0 && r < Rows && c >= 0 && c < Columns && board[r, c].Player == player)
                count++;
            else
                count = 0;

            if (count >= 4)
                return true;
        }

        // Check diagonal (bottom-left to top-right)
        count = 0;
        for (int i = -3; i <= 3; i++)
        {
            int r = row - i;
            int c = col + i;
            if (r >= 0 && r < Rows && c >= 0 && c < Columns && board[r, c].Player == player)
                count++;
            else
                count = 0;

            if (count >= 4)
                return true;
        }

        return false;
    }

    public void ResetBoard()
    {
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                board[r, c] = new Cell(new Rectangle(c * CellSize, r * CellSize, CellSize, CellSize));
            }
        }
        BoardUpdated?.Invoke(this, new int[Rows, Columns]);
    }
}

