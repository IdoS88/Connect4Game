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
// View.cs

namespace Client
{
    public partial class View : Form
    {
        private bool isFirstRun = true;
        private bool isMouseDown = false;
        public bool isEnterPressed = false;

        string name = null;
        string connString = null;
        private Stopwatch gameTimer;
        string connectionString = "Data Source = localhost\\MSSQLSERVER01;Initial Catalog = ServerDB; Integrated Security = True";

        public View()
        {

            InitializeComponent();
            
            gameTimer = new Stopwatch();



        }

        private void AddButtonsToPanel(string name)
        {
            if (!String.IsNullOrEmpty(name))
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
                        // The column variable will give you the index of the clicked button
                        // Call a method in the GameBoardControl to handle disc dropping

                        gameBoardControl1.DropDisc(column, name);


                    };

                    // Add the button to the panel
                    pnlButtons.Controls.Add(button);
                }
            }
            
        }



        private bool IsNameAlreadyExists(string name)
        {
            // Set up a connection to your database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Write the query to check if the name exists
                string query = "SELECT COUNT(*) FROM Player WHERE Name = @Name";

                // Create a command object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the name parameter to the command
                    command.Parameters.AddWithValue("@Name", name);

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

        private async void LoadGame_Click(object sender, EventArgs e)
        {
            using (var loadGameForm = new LoadGames())
            {
                var result = loadGameForm.ShowDialog(); // Open the LoadGame form

                if (result == DialogResult.OK)
                {
                    // Get the selected game data from the LoadGame form
                    GameBoardState selectedGameBoardState = loadGameForm.SelectedGameBoardState;

                    // Restore the selected game on the GameBoardControl
                    await gameBoardControl1.RestoreGameAndAnimateMoves(selectedGameBoardState);
                }
            }
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            if (isFirstRun)
            {
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

                    // Validate the input
                    if (!string.IsNullOrEmpty(name) && name.Length > 0 && !int.TryParse(name, out _))
                    {
                        // Check if the name already exists
                        if (IsNameAlreadyExists(name))
                        {
                            isFirstRun = true;
                            // Prompt for a different name
                            MessageBox.Show("Name already exists. Please enter a different name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Start the game or perform further actions with the name
                            AddButtonsToPanel(name);
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

             AddButtonsToPanel(name);
             
              
        }
        private void NewGame_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
    }
}

