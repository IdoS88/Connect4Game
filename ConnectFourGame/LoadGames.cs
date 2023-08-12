using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LoadGames : Form
    {
         public string[] SelectedGameBoardState { get; private set; }

        public LoadGames()
        {
            InitializeComponent();
            listBoxGames.FormattingEnabled = true;  // improved text formatting
            listBoxGames.HorizontalScrollbar = true; //  horizontal scrollbar 
            listBoxGames.IntegralHeight = true; //fit content
            gameBoardControl.Visible = false;
            LoadGameRecords();
            
        }

        private void LoadGameRecords()
        {
            string connectionString = "Data Source = localhost\\MSSQLSERVER01;Initial Catalog = ServerDB; Integrated Security = True";
            List<GameRecords> gameRecords = GameRecords.GetGameRecords(connectionString);
            foreach (var gameRecord in gameRecords)
            {
                listBoxGames.Items.Add($"Game ID: {gameRecord.GameRecordId}, Start Time: {gameRecord.StartTime}, Duration: {gameRecord.Duration}");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadGames_Load(object sender, EventArgs e)
        {

        }

        private void listBoxGames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (listBoxGames.SelectedItem != null)
            {
                // Parse the selected game record to get the GameId
                string selectedText = listBoxGames.SelectedItem.ToString();
                int gameId = int.Parse(selectedText.Substring("Game ID: ".Length, selectedText.IndexOf(",") - "Game ID: ".Length));

                // Retrieve game board state and animation details using gameId
                string[] gameBoardState = gameBoardControl.GetGameBoardState(gameId);

                if (gameBoardState != null)
                {
                    SelectedGameBoardState = gameBoardState;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Unable to retrieve game state for replay.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a game to replay.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gameBoardControl_Load(object sender, EventArgs e)
        {

        }
    }
}
