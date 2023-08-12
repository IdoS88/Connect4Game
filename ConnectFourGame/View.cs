using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
// View.cs

namespace Client
{
    public partial class View : Form
    {
        private bool isFirstRun = true;
        private bool isMouseDown = false;
        public bool isEnterPressed = false;

        string name = null;
        int id;
        string connString = null;
        private Stopwatch gameTimer;
        string connectionString = "Data Source = localhost\\MSSQLSERVER01;Initial Catalog = ServerDB; Integrated Security = True";

        public View()
        {
            InitializeComponent();
            gameTimer = new Stopwatch();
        }

        private void AddButtonsToPanel(int colLoad ,string name)
        {
            int loadCol = colLoad;
            if (!String.IsNullOrEmpty(name) || name == "loadGame")
            {
                for (int col = 0; col < GameBoardControl.Columns; col++)
                {
                    Button button = new Button();
                    button.Text = "Drop";
                    button.Size = new Size(48, 35);
                    button.Location = new Point(col * (GameBoardControl.CellSize + GameBoardControl.Padding), 0);

                    button.Click += (sender, e) =>
                    {
                        int column = Array.IndexOf(pnlButtons.Controls.OfType<Button>().ToArray(), (Button)sender);

                        gameBoardControl1.DropDisc(column, name);    
                    };
                    // Add the button to the panel
                    pnlButtons.Controls.Add(button);
                }
            }
            if (colLoad != -1)
            {
                gameBoardControl1.DropDisc(loadCol, "loadGame");
            }

        }



        private bool IsNameAlreadyExists(string name, int ID)
        {
            // Set up a connection to your database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Write the query to check if the name exists
                string query = "SELECT COUNT(*) FROM Player WHERE Id = @Id";

                // Create a command object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the name parameter to the command
                    command.Parameters.AddWithValue("@Id", ID);

                    // Execute the query and retrieve the result
                    int count = (int)command.ExecuteScalar();

                    // Check if the name already exists
                    return count > 0;
                }
            }
        }





        private void View_Load(object sender, EventArgs e)
            {
                
            }

        private void gameBoardControl1_Load(object sender, EventArgs e)
        {

        }

        private void pnlButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadGame_Click(object sender, EventArgs e)
        {
            using (var loadGameForm = new LoadGames())
            {
                var result = loadGameForm.ShowDialog(); // Open the LoadGame form
                

                if (result == DialogResult.OK)
                {
                    
                    // Get the selected game data from the LoadGame form
                    string[] selectedGameBoardState = loadGameForm.SelectedGameBoardState;
                    foreach (var gameBoardState in selectedGameBoardState)
                    {

                        int column = int.Parse(gameBoardState);
                        //gameBoardControl1.MoveCount++;
                        if (gameBoardControl1.currentPlayer == 1)
                        {
                            AddButtonsToPanel(column, "loadGame");
                        }
                        else
                        {
                            gameBoardControl1.DropDisc(column, "loadGame");
                        }
                        
                    }                   
                }
            }
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            if (isFirstRun || gameBoardControl1.gameEnded == true)
            {
                gameBoardControl1.gameEnded = false;
                isFirstRun = false;
                // Create an instance of the input form
                InputForm inputForm = new InputForm();

                // Show the input form as a dialog (modal)
                DialogResult result = inputForm.ShowDialog();

                // Check if the user clicked the OK button on the input form
                if (result == DialogResult.OK)
                {
                    // Retrieve the input from the input form
                    name = inputForm.GetName();
                    id = inputForm.getID();

                    // Validate the input
                    if (!string.IsNullOrEmpty(name) && name.Length > 0 && !int.TryParse(name, out _))
                    {
                        // Check if the name already exists
                        if (IsNameAlreadyExists(name,id))
                        {
                            isFirstRun = true;
                            // Prompt for a different name
                            MessageBox.Show("Name already exists. Please enter a different name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Start the game or perform further actions with the name
                            AddButtonsToPanel(-1,name);
                        }
                    }
                    else
                    {
                        isFirstRun = true;
                        // Show an error message if the input is empty or contains only whitespace
                        MessageBox.Show("Name should contain at least one character.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

             AddButtonsToPanel(-1,name);
             
              
        }
        private void NewGame_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
    }
}

