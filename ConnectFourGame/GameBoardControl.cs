using Client.Models.Extentions;
using Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public delegate void PlayerWinEventHandler(string playerName, int gameDuration);

    public partial class GameBoardControl : UserControl
    {
        public const int Rows = 6;
        public const int Columns = 7;
        public const int CellSize = 60;
        public const int Padding = 10;
        

        private int[,] board; // 2D array to keep track of the state of each cell
        public int currentPlayer = 1;
        private Stopwatch gameTimer;

        private int MoveCount = 1;

        //animation
        public bool isAnimating { get; set; }
        private int animationRow = 6;
        private int animationColumn = 7;

        //timer
        private Timer animationTimer;
        private Timer computerMoveTimer;

        public bool gameEnded { get; set; }
        private DateTime gameStartTime;

        List<int> colMoves = new List<int>();
        string[] moves;
        public int realID { get; set; }

        private const int AnimationInterval = 100; // Adjust this value for the animation speed
        string connectionString = "Data Source = localhost\\MSSQLSERVER01;Initial Catalog = ServerDB; Integrated Security = True";

        //services
        GameService gameService;


        public GameBoardControl()
        {
            Uri url = new Uri("https://localhost:7151/");
            gameService = new GameService(url);
            // Calculate the size of the game board
            int boardWidth = Columns * (CellSize + Padding) - Padding;
            int boardHeight = Rows * (CellSize + Padding) - Padding;

            this.Width = boardWidth;
            this.Height = boardHeight;
            this.currentPlayer = currentPlayer;
            isAnimating = false;

            board = new int[Rows, Columns];
            DoubleBuffered = true;
            this.ResizeRedraw = true;
            gameTimer = new Stopwatch();
            gameTimer.Start();

            animationTimer = new Timer();
            animationTimer.Interval = AnimationInterval;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();

            computerMoveTimer = new Timer();
            computerMoveTimer.Interval = 100; // Set the interval (1 second in this example)
            computerMoveTimer.Tick += ComputerMoveTimer_Tick;
            computerMoveTimer.Start();

            gameStartTime = DateTime.Now;


        }



        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (gameEnded)
            {
                return;
            }
            // Update the animation position and invalidate to trigger redraw
            if (isAnimating)
            {
                // Calculate the target row position where the disc should land
                int targetRow = GetNextAvailableRow(animationColumn);

                // Check if the animation has reached the target position
                if (animationRow == targetRow)
                {
                    // Animation complete, update the board and stop the animation
                    isAnimating = false;
                    board[animationRow, animationColumn] = (MoveCount % 2 == 0) ? 1 : 2;
                    Invalidate();
                }
                else
                {
                    // Continue animation by moving the disc one row down or up
                    if (animationRow < targetRow)
                    {
                        animationRow++;
                    }
                    else
                    {
                        animationRow--;
                    }
                    // Invalidate to continue animation
                    Invalidate();
                }
            }

        }

        private async void ComputerMoveTimer_Tick(object sender, EventArgs e)
        {
            if (gameEnded)
            {
                return;
            }
            // Check if it's currently the computer's turn
            if (currentPlayer == 2)
            {

                //isAnimating = true;
                //animationRow = 0;

                // Make a move for the computer player
                int computerMove = await GetRandomComputerMove();
                while (computerMove == -1)
                    computerMove = await GetRandomComputerMove();

                if (computerMove != -1)
                {

                    DropDisc(computerMove, "Computer", realID);

                }
                else
                {
                    // The computer cannot make a move, display a message or take appropriate action
                    MessageBox.Show("The computer cannot make a move. The game is a draw.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reset the game or take any other necessary actions
                    return;
                }
            }
        }


        private double GetGameDuration()
        {
            return gameTimer.Elapsed.TotalSeconds;
        }


        private async Task<int> GetRandomComputerMove()
        {
            int move = await gameService.GetComputerMove();
            if (GetNextAvailableColumn(move) != -1)
                return move;
            return -1;
        }

        private int GetNextAvailableColumn(int col)
        {
            for (int row = Rows - 1; row >= 0; row--)
            {
                if (board[row, col] == 0)
                {
                    return col;
                }
            }
            return -1; // Column is full, no available row
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            // Calculate the horizontal and vertical offsets for centering the board
            int horizontalOffset = (this.Width - (Columns * (CellSize + Padding) - Padding)) / 2;
            int verticalOffset = (this.Height - (Rows * (CellSize + Padding) - Padding)) / 2;



            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    // Calculate the position and size of the rectangle for each cell
                    int x = horizontalOffset + col * (CellSize + Padding);
                    int y = verticalOffset + row * (CellSize + Padding);
                    Rectangle rect = new Rectangle(x, y, CellSize, CellSize);

                    // Draw the rectangle for each cell with the appropriate color
                    if (board[row, col] == 0)
                    {
                        // Empty cell
                        g.FillRectangle(Brushes.LightGray, rect);
                    }
                    else if (board[row, col] == 1)
                    {
                        // Player 1's disc (e.g., red)
                        g.FillEllipse(Brushes.Red, rect);
                    }
                    else if (board[row, col] == 2)
                    {
                        // Player 2's disc (e.g., yellow)
                        g.FillEllipse(Brushes.Yellow, rect);
                    }

                    // Draw cell borders
                    g.DrawRectangle(Pens.Black, rect);
                }
            }

            // Draw the animated disc if it's in the middle of an animation
            if (isAnimating && !gameEnded)
            {
                int x = horizontalOffset + animationColumn * (CellSize + Padding);
                int y = verticalOffset + animationRow * (CellSize + Padding);
                Rectangle rect = new Rectangle(x, y, CellSize, CellSize);

                // Draw the disc based on the current player
                if (MoveCount % 2 == 0)
                {
                    // Player 1's disc (e.g., red)
                    g.FillEllipse(Brushes.Red, rect);

                }
                else
                {
                    // Player 2's disc (e.g., yellow)
                    g.FillEllipse(Brushes.Yellow, rect);
                }
            }
        }

        public void SaveGameRecord(GameRecords gameRecord, string status)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO GameRecords (PlayerID, StartTime, Duration, GameMoves) " +
                               "VALUES (@PlayerID, @StartTime, @Duration, @GameMoves)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlayerID", gameRecord.PlayerID);
                    command.Parameters.AddWithValue("@StartTime", gameRecord.StartTime);
                    command.Parameters.AddWithValue("@Duration", gameRecord.Duration);
                    command.Parameters.AddWithValue("@GameMoves", gameRecord.GameMoves);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void StoreGameDuration(double gameDuration)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Create the SQL query to insert the data into the table
                    string query = "INSERT INTO Game (PlayerId,DateInit,TimePlayed,GameStatus) VALUES (@PlayerId,@DateInit,@TimePlayed,@GameStatus)";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@PlayerId", 1);
                        command.Parameters.AddWithValue("@DateInit", gameStartTime);
                        command.Parameters.AddWithValue("@TimePlayed", gameDuration);
                        command.Parameters.AddWithValue("@GameStatus", "WINS");
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the game time: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public async void DropDisc(int column, string name, int id)
        {
            if (isAnimating || column < 0 || column >= Columns)
            {
                // Animation is already in progress, invalid column index, or game has ended, do nothing
                return;
            }
            Console.WriteLine(id);

            // Find the next available row in the specified column
            int row = GetNextAvailableRow(column);
            if (row == -1)
            {
                // The column is already full, do nothing
                return;
            }


            // Determine the current player (assuming player 1 goes first, and then players alternate)
            currentPlayer = (MoveCount % 2 == 0) ? 1 : 2;
            Console.WriteLine("Current Player: " + currentPlayer); // Add this line

            // Record the move in colMoves
            colMoves.Add(column);

            // Start the animation
            gameEnded = false;
            isAnimating = true;
            animationRow = 0;
            animationColumn = column;

            // Trigger the Paint event to redraw the game board
            Invalidate();

            string loadChecker = "loadGame";

            // Check for a win after updating the board and recording the move
            if (name != loadChecker && CheckWin(currentPlayer))
            {
                gameEnded = true;

                string winner = (currentPlayer == 1) ? "Player 1" : "Computer";
                MessageBox.Show($"{winner} wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                double gameDuration = GetGameDuration();
               // StoreGameDuration(gameDuration);

                string gameMovesString = string.Join(",", colMoves);
                GameRecords gameRecord = new GameRecords
                {
                    PlayerID = id,
                    StartTime = DateTime.Now,
                    Duration = (int)gameDuration,
                    GameMoves = gameMovesString

                };

                SaveGameRecord(gameRecord, winner);
                await gameService.AddGame(gameRecord.ToDto(winner));
                ResetGame();
                colMoves.Clear();

            }
            MoveCount++;
        }

        internal string[] GetGameBoardState(int gameId)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT GameMoves FROM GameRecords WHERE GameRecordId = @GameRecordId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GameRecordId", gameId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string gameMoves = reader.GetString(0);

                            // Split the GameMoves string to get individual moves
                            moves = gameMoves.Split(',');
                        }
                        return moves;
                    }
                }
            }
        }


        // Helper method to find the next available row in a column
        private int GetNextAvailableRow(int column)
        {
            if (column < 0 || column >= Columns)
            {
                // Column index is out of bounds, return an error code or handle as needed
                return -1;
            }
            for (int row = Rows - 1; row >= 0; row--)
            {
                if (board[row, column] == 0)
                {
                    return row;
                }
            }
            return -1; // Column is full
        }

        public void ResetGame()
        {
            // Clear the game board
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    board[row, col] = 0;
                }
            }
            MoveCount = 0;
            currentPlayer = 1;
            gameEnded = true;
            isAnimating = false;
            colMoves.Clear();

            // Trigger repaint to update the UI
            Invalidate();
        }

        public bool CheckWin(int player)
        {
            // Check for horizontal win
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns - 3; col++)
                {
                    if (board[row, col] == player &&
                        board[row, col + 1] == player &&
                        board[row, col + 2] == player &&
                        board[row, col + 3] == player)
                    {

                        return true;
                    }
                }
            }

            // Check for vertical win
            for (int row = 0; row < Rows - 3; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (board[row, col] == player &&
                        board[row + 1, col] == player &&
                        board[row + 2, col] == player &&
                        board[row + 3, col] == player)
                    {
                        return true;
                    }
                }
            }

            // Check for diagonal-up win
            for (int row = 3; row < Rows; row++)
            {
                for (int col = 0; col < Columns - 3; col++)
                {
                    if (board[row, col] == player &&
                        board[row - 1, col + 1] == player &&
                        board[row - 2, col + 2] == player &&
                        board[row - 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check for diagonal-down win
            for (int row = 0; row < Rows - 3; row++)
            {
                for (int col = 0; col < Columns - 3; col++)
                {
                    if (board[row, col] == player &&
                        board[row + 1, col + 1] == player &&
                        board[row + 2, col + 2] == player &&
                        board[row + 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void GameBoardControl_Load(object sender, EventArgs e)
        {

        }
    }
}
